using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace lesson_22.DataValidation
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class OtherAttribute : ValidationAttribute
	{
		public string OtherProperty { get; }

		public OtherAttribute(string otherProperty)
		{
			if (otherProperty == null)
				throw new ArgumentNullException("Other property");

			OtherProperty = otherProperty;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			PropertyInfo otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);

			if (otherPropertyInfo == null)
				return new ValidationResult($"Can not find the property having name \"{OtherProperty}\"");

			object otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

			if (Equals(value, otherPropertyValue))
				return new ValidationResult($"{validationContext.MemberName} should not be the same as {OtherProperty}");

			return null;
		}
	}
}
