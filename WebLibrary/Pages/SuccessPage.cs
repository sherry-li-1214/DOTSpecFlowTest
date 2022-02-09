using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;

namespace WebLibrary.Pages
{
    public class SuccessPage : PageBase
    {
        public SuccessPage(IWebDriver webDriver) : base(webDriver)
        {
        }
        #region WebElement

        private IWebElement statusCompleted
            => Driver.FindElement(By.XPath("//*[contains(text(),'Completed')]"));
        
       
        
        #endregion
         
       
         
        public IWebElement confirmSuccess( )
        {
            return statusCompleted;
        }

        
        protected override bool EvaluateLoadedStatus()
        {
            try
            {
                WaitForElement(statusCompleted);
                return true;
            }
            catch
            {
                throw new Exception("page not load");
            }    
        }
    }
}
