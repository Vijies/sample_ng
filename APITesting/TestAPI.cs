using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using FASSNotaryTests;

namespace APITesting
{
    [TestClass]
    public class FASSTitanAPI: ReportHelper
    {
        ReportHelper Report;
        [TestInitialize]
        public void Initialize()
        {
            this.Report = new ReportHelper();
            _test = _extent.StartTest(TestContext.TestName);
        }
        [TestMethod, TestCategory("API")]
        public void BasicHealthCheck()
        {
            //Creating Client connection 
            RestClient restClient = new RestClient("https://titan-fassnotary-outbound.dev-fams-toh.io/v1/hellotitan");
           
            //const string baseURL = "endpoint";
            //RestClient restClient = new RestClient();
            //restClient.BaseUrl = new Uri(baseURL);

            //Creating request to get data from server
            RestRequest restRequest = new RestRequest(Method.GET);

            // Executing request to server and checking server response for it
            IRestResponse restResponse = restClient.Execute(restRequest);

            // Extracting output data from received response
            string response = restResponse.Content;

            // Verifiying reponse
            if (!response.Contains("Hello Titan!!"))
                Assert.Fail("Response Fail");

            int StatusCode = (int)restResponse.StatusCode;
            Assert.AreEqual(200, StatusCode, "Status code is "+StatusCode);
        }
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}

