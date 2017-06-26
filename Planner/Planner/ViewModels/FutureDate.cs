using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Planner.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {

            string[] formats = {
                "M/d/yyyy",
                "MM/dd/yyyy",
                "M/dd/yyyy",
                "MM/d/yyyy",
                "d/MMM/yyyy"
            };
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                formats,
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);

            return (isValid && dateTime > DateTime.Now);
        }
    }
}