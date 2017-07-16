using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerFormatProviders;
using Customers;

namespace NUnit.TestsCustomer
{
    [TestFixture]
    public class TestCustomer
    {
        [TestCase("G", ExpectedResult = "Customer record: Tom, 100000$, +1(234)5678")]
        [TestCase("P", ExpectedResult = "Customer record: +1(234)5678")]
        [TestCase("N", ExpectedResult = "Customer record: Tom")]
        [TestCase("R", ExpectedResult = "Customer record: 100000$")]
        [TestCase("NR", ExpectedResult = "Customer record: Tom, 100000$")]
        public string TestTostring (string str)
        {
            Customer customer = new Customer("Tom", "12345678", 100000);
            return customer.ToString(str);
        }
    }
}
