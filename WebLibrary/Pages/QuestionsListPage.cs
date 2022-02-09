using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebLibrary.Pages
{
    public class QuestionsListPage : PageBase
    {
        public QuestionsListPage(IWebDriver webDriver) : base(webDriver)
        {
        }
        #region WebElement

        private IWebElement what_you_want_to_talk
            => Driver.FindElement(By.XPath("//*[contains(.,'What would you like to talk about')]"));
        private IList<IWebElement> talk_about_reasons
            => Driver.FindElements(By.CssSelector("self-serve-appointment-booking /deep/ a.ListItemA-iShZcF"));
                //Driver.FindElements(By.CssSelector("svg.Iconstyle__StyledIcon-sc-82cwdi-0"));  //[div[@aria-label='Buying a property']]")); //*[@id="wrapper"]/div/div/div[3]/div/div/mini-app-loader/self-serve-appointment-booking//div/div/div/div/div[2]/div[1]/a[1]/div/div/div
            //"div[class='menu-panel right']"
        //private IWebElement reason_buying_a_property
        //    => Driver.FindElement(By.PartialLinkText("Buying a property"));
        
        private IList<IWebElement> applicants_Radio
            => Driver.FindElements(By.Name("applicants"));
        
        private IList<IWebElement> income_from_chxbox
            => Driver.FindElements(By.Name("income"));

        private IList<IWebElement> deposit_from_chxbox
            => Driver.FindElements(By.Name("deposit"));
        private IWebElement post_code_text
            => Driver.FindElement(By.Id("location"));

        private IList<IWebElement> appointment_type
            => Driver.FindElements(By.CssSelector("a.ListItemA-pGNES"));
        
        private IWebElement nextButton
            => Driver.FindElement(By.XPath("//*[contains(text(),'Next')]"));
       
        private IWebElement previousButton
            => Driver.FindElement(By.XPath("//*[contains(text(),'Previous')]"));

        private IWebElement autoSuggestCode
            => Driver.FindElement(By.Id("autosuggest-listbox-location-0"));
   
        #endregion

        public void FillInOptions(string reason, string applicantNumbers,string incomeFrom,string depositComeFrom)
        {
           // WaitForElement(nextButton);
            //WaitForElement(reason_buying_a_property);
            WaitForElement(what_you_want_to_talk);
            Console.WriteLine("successful");
            //Console.WriteLine("reason size is:"+talk_about_reasons.Count);
           // string[] cssselectors= {"self-serve-appointment-booking","a:first of type"};
           // var element = GetElementFromShadowDom(_driver,cssselectors);
           /* var shadowHost = _driver.FindElement(By.XPath("//self-serve-appointment-booking"));
            var js = ((IJavaScriptExecutor)_driver);

            var shadowRoot = (IWebElement)js.ExecuteScript("return arguments[0].shadowRoot", shadowHost);
            var shadowContent = shadowRoot.FindElement(By.CssSelector("a:first of type "));
            */
           // Console.WriteLine(element.GetAttribute("href"));
             
             foreach (var elem in talk_about_reasons)
            {
                if(elem.FindElement(By.XPath(".//div")).GetAttribute("aria-label").Equals(reason))
                {
                   // Console.WriteLine(reason+ ": is selected");
                    Console.WriteLine(elem.GetAttribute("href"));
                    elem.Click();
                    
               }

            }
          
           WaitForElement(nextButton);
           //select the applicants number by its value
           foreach (var elem in applicants_Radio)
           {
               if (elem.GetProperty("text").Equals(applicantNumbers))
               {
                   elem.Click();
               }
           }
            
            nextButton.Click();
            
            WaitForElement(nextButton);
            //select the income come from checkbox by its value
            foreach (var elem in income_from_chxbox)
            {
                if (elem.GetProperty("text").Equals(incomeFrom))
                {
                    elem.Click();
                }
            }
            
            nextButton.Click();
            
            WaitForElement(nextButton);
            //select the deposit come from checkbox by its value
            foreach (var elem in deposit_from_chxbox)
            {
                if (elem.GetProperty("text").Equals(depositComeFrom))
                {
                    elem.Click();
                }
            }
            
            nextButton.Click();
            //put into postcode
            post_code_text.SendKeys("3133"); 
            nextButton.Click();
           
    
        }

        /*
         * fill in post code
         */
        public void fillPostCode()
        {
            post_code_text.SendKeys("3133");
            WaitForElement(autoSuggestCode);
            autoSuggestCode.Click();
            nextButton.Click();
            
        }

        public void selectAppointmentType(string appointmentType)
        {
            foreach (var elem in talk_about_reasons)
            {
                if(elem.FindElement(By.XPath(".//div")).GetAttribute("aria-label").Equals(appointmentType))
                {
                    // Console.WriteLine(reason+ ": is selected");
                    Console.WriteLine(elem.GetAttribute("href"));
                    elem.Click();
                }

            }
        }
        public void selectAppointmentTime(string appointmentDate,string appointmentTime)
        {
            IWebElement btnAppointmentDate = Driver.FindElement(By.Id("date-"+appointmentDate));
            btnAppointmentDate.Click();
            IWebElement btnAppointmentTime=Driver.FindElement(By.XPath("//button[@text()='"+appointmentTime+"'"));
            btnAppointmentTime.Click();
            nextButton.Click();
        }
        
        protected override bool EvaluateLoadedStatus()
        {
            try
            {
                //WaitForElement(talk_about_reasons[0]);
                return true;
            }
            catch
            {
                throw new Exception("page not load");
            }    
        }
    }
    


}
