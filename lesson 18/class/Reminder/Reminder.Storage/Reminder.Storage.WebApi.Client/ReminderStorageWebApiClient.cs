using Newtonsoft.Json;
using Reminder.Storage.Core;
using Reminder.Storage.WebApi.Core;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Net;
using System.Linq;

namespace Reminder.Storage.WebApi.Client
{
	public class ReminderStorageWebApiClient : IReminderStorage
	{
		private readonly string _baseWebApiUrl;
		private HttpClient _httpClient;

		public ReminderStorageWebApiClient(string baseWebApiUrl)
		{
			_baseWebApiUrl = baseWebApiUrl;
			_httpClient = HttpClientFactory.Create();
		}

		public Guid Add(
            DateTimeOffset date,
            string message,
            string contactId,
            ReminderItemStatus status)
		{
			var model = new ReminderItemAddModel
            {
                Date = date,
                Message = message,
                ContactId = contactId,
                Status = status
            };
			string content = JsonConvert.SerializeObject(model);

			// send request
			HttpResponseMessage response = SendRequest(
                _baseWebApiUrl,
				"POST",
                content);

            // analyse response
            ThrowExceptionIfStatusCodeIsOtherThan(response, HttpStatusCode.Created);

            var body = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<ReminderItemGetModel>(body).Id;
		}

		public ReminderItem Get(Guid id)
		{
			HttpResponseMessage response = SendRequest(
				_baseWebApiUrl + $"/{id}",
				"GET",
				null);

			if (response.StatusCode == HttpStatusCode.NotFound)
				return null;

            ThrowExceptionIfStatusCodeIsOtherThan(
				response,
				HttpStatusCode.OK);

			string content = response.Content.ReadAsStringAsync().Result;
			var model = JsonConvert.DeserializeObject<ReminderItemGetModel>(content);

			return new ReminderItem(
				model.Id,
				model.Date,
				model.Message,
				model.ContactId,
				model.Status);
		}

		public List<ReminderItem> Get(ReminderItemStatus status)
		{
			HttpResponseMessage response = SendRequest(
				_baseWebApiUrl + $"?[filter]status={status}",
				"GET",
				null);

            ThrowExceptionIfStatusCodeIsOtherThan(
				response,
				HttpStatusCode.OK);

			string content = response.Content.ReadAsStringAsync().Result;
			var model = JsonConvert.DeserializeObject<List<ReminderItemGetModel>>(content);

			var result = model
				.Select(x => new ReminderItem(
					x.Id,
					x.Date,
					x.Message,
					x.ContactId,
					x.Status))
				.ToList();

			return result;
		}

		public void Update(Guid id, ReminderItemStatus status)
		{
			var model = new ReminderItemUpdateModel { Status = status };
			string content = JsonConvert.SerializeObject(model);

			// send request
			HttpResponseMessage response = SendRequest(
                _baseWebApiUrl + $"/{id}",
				"PATCH",
                content);

            // analyse response
            ThrowExceptionIfStatusCodeIsOtherThan(response, HttpStatusCode.NoContent);
		}

		private HttpResponseMessage SendRequest(
            string requestUri,
            string httpMethodString,
            string content
			)
		{
			HttpMethod httpMethod = new HttpMethod(httpMethodString);

			HttpRequestMessage request = new HttpRequestMessage(
				httpMethod,
				requestUri);

			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

			if (content != null)
			{
				request.Content = new StringContent(
					content,
					Encoding.UTF8,
					"application/json");
			}

			return _httpClient.SendAsync(request).Result;
		}

		private static void ThrowExceptionIfStatusCodeIsOtherThan(
			HttpResponseMessage response,
			HttpStatusCode statusCode)
		{
			if (response.StatusCode != statusCode)
			{
				throw new Exception(
					$"Status code: {response.StatusCode}.\n" +
					$"Content:\n {response.Content.ReadAsStringAsync().Result}");
			}
		}
	}
}
