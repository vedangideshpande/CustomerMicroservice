using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerMicroservice.Models;

namespace CustomerMicroservice.Data
{
    public static class CustomerDbHelper
    {
        public static List<Customer> customers = new List<Customer>()
        {
            new Customer(){CustomerId = 10, FirstName = "Rohini", LastName = "Thorat", Address = "Mumbai", DateOfBirth = new DateTime(1999,02,02), PanNumber = "MFPFS10001A", Password = "ABCa12345" },
            new Customer(){CustomerId = 11, FirstName = "Vedangi", LastName = "Deshpande", Address = "Mumbai", DateOfBirth = new DateTime(1998,07,20), PanNumber = "MFPFS10002B", Password = "ABCa12354" },
            new Customer(){CustomerId = 12, FirstName = "Nivedita", LastName = "T", Address = "Chennai", DateOfBirth = new DateTime(1998,04,15), PanNumber = "MFPFS10003C", Password = "ABCa12346" },
            new Customer(){CustomerId = 13, FirstName = "Suriyakumar", LastName = "S", Address = "Erode", DateOfBirth = new DateTime(1998,08,25), PanNumber = "MFPFS10004B", Password = "ABCa12342" }
        };
    }
}
