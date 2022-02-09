using ApiLibrary;
using ApiLibrary.Models;
using ApiLibrary.RequestDTO;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using SeleniumSpecFlow;
using SeleniumSpecFlow.Utilities;
using System;
using System.Collections.Generic;
using System.Text.Json;
using TechTalk.SpecFlow;
using TestLibrary.Utilities;

namespace TestLibrary.Steps
{
    [Binding]
    public class ApiTestSteps : ObjectFactory
    {
        private readonly RestClient _restClient = Hooks.restClient;
        private readonly string _newRandomUserName = Util.RandomString();
        private readonly Random _latestScore = new Random();
        private string _resource;
        public IRestResponse restResponse { get; private set; }

     

        [When(@"I requested ""(.*)"" operation and fetch the response")]
        public void WhenIRequestedFor(string method)
                => restResponse = ApiHelper.CreateRequest(string.Empty, method, _restClient, _resource);

        [Then(@"I should see the status of pull request list (.*)")]
        public void ThenIValidateStatusShouldBe(string status)
        {
            string Status = restResponse.StatusCode.ToString();
            Assert.AreEqual(status, Status, "Status code is not " + status);
        }

        [Then(@"I should see the (.*) status code")]
        public void ThenIValidateResponseStatusShouldBe(int status)
        {
           int StatusCode = (int)restResponse.StatusCode;
            Assert.AreEqual(status, StatusCode, "Status code is not " + status);
        }
 
   
        [Given(@"I go to the Disruption API portal")]
        public void GivenIGoToTheDisruptionApiPortal()
        {
            _resource = "";
        }

        [Then(@"I get the total numbers of disruptions with following criteria")]
        public void ThenIGetTheTotalNumbersOfDisruptionsWithFollowingCriteria(Table table)
        {
            var disruptionList = JArray.Parse(restResponse.Content).ToObject<List<UsersResponse>>();
            if (disruptionList == null)
            {
                throw new ArgumentNullException(nameof(disruptionList));
            }
            else
            {
                foreach (var disrupt in disruptionList)
                {
                    // Assert.Greater(user.UserId, 0, "Verify the UserId doesnt have positive integer");
                    //Assert.GreaterOrEqual(user.Score, 0, "Verify the Score should be always greater than or equal to zero");
                    //Assert.IsNotEmpty(user.UserName, "UserName should be empty");
                    Console.WriteLine(disrupt);
                
                }
                Console.WriteLine("total number is:" + disruptionList.Count);
            }

    
        }

        [When(@"I requested ""(.*)"" operation with following criteria and fetch the response")]
        public void WhenIRequestedOperationWithFollowingCriteriaAndFetchTheResponse(string method, Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
           restResponse = ApiHelper.CreateRequest(JsonConvert.SerializeObject(dictionary), method, _restClient, _resource);

        }
    }
    }