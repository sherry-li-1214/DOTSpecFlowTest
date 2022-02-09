using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;

namespace WebLibrary.Pages
{
    public class ContactInfoPage : PageBase
    {
        public ContactInfoPage(IWebDriver webDriver) : base(webDriver)
        {
        }
        #region WebElement

        private IWebElement firstNameField
            => Driver.FindElement(By.Id("firstName"));
        private IWebElement lastNameField
            => Driver.FindElement(By.Id("lastName"));

        private IWebElement preferredNameField
            => Driver.FindElement(By.Id("preferredName"));
        
        private IWebElement mobileField
            => Driver.FindElement(By.Id("mobile"));
        private IWebElement emailAddressField
            => Driver.FindElement(By.Id("email"));
        private IWebElement NabIDField
            => Driver.FindElement(By.Id("nabId"));
        private IWebElement submitButton
            => Driver.FindElement(By.Id("page-Page1-btnGroup-submitBtn"));
       
        private IWebElement nextButton
            => Driver.FindElement(By.XPath("//*[contains(text(),'Next')]"));


        private IWebElement confirmButton
            => Driver.FindElement(By.XPath("//button[contains(text(),'Confirm & book appointment')]"));
        
        #endregion
         
       
         
        public void caputureClientInfor(string firstname,string lastname,string preferredname,string email,string phone,string nabID)
        {
            firstNameField.SendKeys(firstname);
            lastNameField.SendKeys(lastname);
            preferredNameField.SendKeys(preferredname);
            emailAddressField.SendKeys(email);
            mobileField.SendKeys(phone);
            NabIDField.SendKeys(nabID);
       }

        public void submit()
        {
           // caputureClientInfor();
            nextButton.Click();
        }

        public void confirmAndBook()
        {
            checkTheContentInformation();
            confirmButton.Click();
        }

        public void checkTheContentInformation()
        {
            
        }
        protected override bool EvaluateLoadedStatus()
        {
            try
            {
                WaitForElement(submitButton);
                return true;
            }
            catch
            {
                throw new Exception("page not load");
            }    
        }
    }
}
