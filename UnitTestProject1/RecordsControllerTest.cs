using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using test;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Net;

namespace UnitTestProject1
{
    [TestClass]
    public class RecordsControllerTest
    {
        [TestMethod]
        public void Get_ValidResponse_SortFieldExists()
        {
            var controller = new RecordsController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Get("Gender");

            Assert.AreEqual(response.IsSuccessStatusCode , true);
        }

        [TestMethod]
        public void Get_InvalidResponse_SortFieldDoesntExists()
        {
            var controller = new RecordsController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Get("Unkown");

            Assert.AreEqual(response.IsSuccessStatusCode, false);
        }
    }
}

