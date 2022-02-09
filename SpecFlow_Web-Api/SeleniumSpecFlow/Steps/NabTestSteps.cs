using System;
using AngleSharp.Common;
using Gherkin.Events.Args.Pickle;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using OpenQA.Selenium;
using RazorEngine.Compilation.ImpromptuInterface;
using SeleniumSpecFlow.Utilities;
using TechTalk.SpecFlow;
using TestLibrary.Entitiy;
using TestLibrary.Utilities;
using WebLibrary.Pages;

namespace TestLibrary.Steps
{
    [Binding]
    public  class NabTestSteps : ObjectFactory
    {
        private readonly HomePage _homePage;
       private readonly QuestionsListPage _questionsListPage;
        private readonly ContactInfoPage _contactInfoPage;
        private readonly SuccessPage _successPage;
        public NabTestSteps(HomePage loginPage,
            QuestionsListPage questionsListPage,
            ContactInfoPage contactInfoPage)
        {
            _homePage = loginPage;
            _questionsListPage = questionsListPage;
            _contactInfoPage = contactInfoPage;

        }

        [Given(@"I enter into Nab Website")]
        public void GivenIEnterIntoNabWebsite()
        {
            //
       }
        [Then(@"I want to book an appointment")]
        public void ThenIWantToBookAnAppointment()
        {
            _homePage.go_to_book_appointment();
            
        }

   
        [Then(@"I should go to confirmation page with ""(.*)""")]
        public void ThenIShouldGoToConfirmationPageWith(string p0)
        {
            string ExpectedText ="We have received your feedback";
            IWebElement body = _homePage._driver.FindElement(By.TagName("body"));

            Assert.IsTrue(body.Text.Contains(ExpectedText));
        }

    

        [Then(@"I need choose the options for questions on the page")]
        public void ThenINeedChooseTheOptionsForQuestionsOnThePage(Table table)
        {
            foreach (var row in table.Rows)
            {
                Console.WriteLine("The reason  = {0}", row[0]);
                _questionsListPage.FillInOptions(row[0], row[1], row[2], row[3]);
            }

        }
            
        [Then(@"I fill in suburb information")]
        public void ThenIFillInSuburbInformation()
        {
            _questionsListPage.fillPostCode();
        }
        
        [Then(@"I select my preferred appointment type with (.*)")]
        public void ThenISelectMyPreferredAppointmentType(string appointmentType)
        {
             _questionsListPage.selectAppointmentType(appointmentType);
        }
        
        [Then(@"I select appointment date with following information")]
        public void ThenISelectAppointmentDateWithFollowingInformation(Table table)
        {
            var row = table.Rows[0];
            _questionsListPage.selectAppointmentTime(row[0],row[1]);
        }
        
        [Then(@"I fill in my detailed contact information for the appointment")]
        public void ThenIFillInMyDetailedContactInformationForTheAppointment()
        {
           // ScenarioContext.StepIsPending();
            _contactInfoPage.submit();
        }
        
        [Then(@"I confirm and book the appointment with the information from (.*)")]
        public void ThenIConfirmAndBookTheAppointmentWithTheInformationFromTestdata(string excel)
        {
            Contact contact = Util.parseContactInfo(excel).GetItemByIndex(0);
            _contactInfoPage.caputureClientInfor(contact.firstname,contact.lastname,contact.preferredName, contact.email,contact.mobile,contact.nabID);
            _contactInfoPage.submit();
            _contactInfoPage.checkTheContentInformation();
            _contactInfoPage.confirmAndBook();
        }
        
        [Then(@"I should go to confirmation page with appointment details")]
        public void ThenIShouldGoToConfirmationPageWithAppointmentDetails()
        {
            string ExpectedText ="We have received your feedback";
            IWebElement element = _successPage.confirmSuccess(); 

            Assert.IsTrue(element.Displayed);

        }
    }
}