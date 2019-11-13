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
		private string _baseWebApiUrl;
		private HttpClient _httpClient;

		public ReminderStorageWebApiClient(string baseWebApiUrl)
		{
			_baseWebApiUrl = baseWebApiUrl;
			_httpClient = HttpClientFactory.Create();
		}

		public void Add(ReminderItem reminderItem)
		{
			var model = new ReminderItemAddModel(reminderItem);
			string content = JsonConvert.SerializeObject(model);

			// send request
			HttpResponseMessage response = SendRequestBefore(
				content,
				"POST",
				_baseWebApiUrl);

			// analyse response
			SendRequestAfter(response, HttpStatusCode.Created);
		}

		public ReminderItem Get(Guid id)
		{
			HttpResponseMessage response = SendRequestBefore(
				_baseWebApiUrl + $"/{id}",
				"GET",
				null);

			if (response.StatusCode == HttpStatusCode.NotFound)
				return null;

			SendRequestAfter(
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
			HttpResponseMessage response = SendRequestBefore(
				_baseWebApiUrl + $"?[filter]{status}",
				"GET",
				null);

			SendRequestAfter(
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
			HttpResponseMessage response = SendRequestBefore(
				content,
				"PATCH",
				_baseWebApiUrl + $"/{id}");

			// analyse response
			SendRequestAfter(response, HttpStatusCode.NoContent);
		}

		public HttpResponseMessage SendRequestBefore(
			string content,
			string httpMethodString,
			string requestUri)
		{
			HttpMethod httpMethod = new HttpMethod(httpMethodString);

			HttpRequestMessage request = new HttpRequestMessage(
				httpMethod,
				requestUri);

			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("/*"));

			if (content != null)
			{
				request.Content = new StringContent(
					content,
					Encoding.UTF8,
					"application/json");
			}

			return _httpClient.SendAsync(request).Result;
		}

		public void SendRequestAfter(
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
