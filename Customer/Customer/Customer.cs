using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Customers
{
    public class Customer:IFormattable
    {
        /// <summary>
        /// properties
        /// </summary>
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public decimal Revenue { get; private set; }
        /// <summary>
        /// c-or
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="phone">number phone</param>
        /// <param name="revenue">money</param>
        public Customer(string name, string phone, decimal revenue)
        {
            if (name == null || phone == null) throw new ArgumentNullException();
            Phone = phone;
            Name = name;
            Revenue = revenue;
        }
        /// <summary>
        /// return string format
        /// </summary>
        /// <returns>string format</returns>
        public override string ToString()
        {
            return ToString("G", CultureInfo.CurrentCulture);
        }
        /// <summary>
        /// return string format
        /// </summary>
        /// <param name="format">format</param>
        /// <returns>string format</returns>
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }
        /// <summary>
        /// return string format
        /// </summary>
        /// <param name="format">format</param>
        /// <param name="provider">provider format</param>
        /// <returns>string format</returns>
        public string ToString(string format, IFormatProvider provider)
        {
            if (String.IsNullOrEmpty(format)) format = "G";
            if (provider == null) provider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "G":
                    return String.Format("{0},{1}, +# (###) #### ", $"Customer record: nameof{Name}, nameof{Revenue}, nameof{Phone}");
                case "P":
                    return String.Format(" +# (###) ####", $"Customer record: nameof{Phone}");
                case "NR":
                    return $"Customer record: nameof{Name}, nameof{Revenue}";
                case "N":
                    return $"Customer record: nameof{Name}";
                case "R":
                    return $"Customer record: nameof{Revenue}";

                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }

    }
}
