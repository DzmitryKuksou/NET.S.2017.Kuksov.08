using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Customers;

namespace CustomerFormatProviders
{
    public class CustomerFormatProvider : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// GetFormat return referenes on object or null
        /// </summary>
        /// <param name="formatType">Type</param>
        /// <returns>object</returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }
        /// <summary>
        /// return object in format string
        /// </summary>
        /// <param name="format">format/param>
        /// <param name="obj">object</param>
        /// <param name="formatProvider">IFormatProvider</param>
        /// <returns>string format</returns>
        public string Format(string format, object obj, IFormatProvider formatProvider)
        {
            if (obj.GetType() != typeof(Customer) || obj == null) 
                {
                    return HandleOtherFormats(format, obj);
                }
            Customer customer = obj as Customer;
            if (customer == null) HandleOtherFormats(format, obj);
            switch (format.ToUpperInvariant())
            {
                case "A":
                    return $"Name is {customer.Name}. Revenue:{customer.Revenue}, Phone{customer.Phone}";
                case "HTML":
                    return $"<html><head></head><body><p>Name is {customer.Name}. Revenue:{customer.Revenue}, Phone{customer.Phone}</p></body>";
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }
        /// <summary>
        /// Handle other Formats
        /// </summary>
        /// <param name="format">string</param>
        /// <param name="arg">object</param>
        /// <returns>string</returns>
        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            else if (arg != null)
                return arg.ToString();
            else
                return String.Empty;
        }
    }
}
