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

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IntegerValue : ValidationAttribute
    {
        public string IsInt { get; }

        public IntegerValue(string isInt)
        {
            if (isInt == null)
                throw new ArgumentNullException("Other property");

            IsInt = isInt;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo otherPropertyInfo = validationContext.ObjectType.GetProperty(IsInt);

            if (otherPropertyInfo == null)
                return new ValidationResult($"Can not find the property having name \"{IsInt}\"");

            if (!(Equals(value.GetType(), typeof(int))))
                return new ValidationResult($" {validationContext.DisplayName} 'Number of points of interest' field should be int value");

            return null;
        }

    }
}
