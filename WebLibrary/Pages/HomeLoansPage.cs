using OpenQA.Selenium;
using System;

namespace WebLibrary.Pages
{
    public class HomeLoansPage : PageBase
    {
        public HomeLoansPage(IWebDriver webDriver) : base(webDriver)
        {
        }
        #region WebElement

       private IWebElement request_call_back_link
            => Driver.FindElement(By.LinkText("Request a call back"));
   
        #endregion
    
     
       
        public void StartJourney()
        {
            WaitForElement(request_call_back_link);

            request_call_back_link.Click();
        }

        protected override bool EvaluateLoadedStatus()
        {
            try
            {
                WaitForElement(request_call_back_link);
                return true;
            }
            catch
            {
                throw new Exception("page not load");
            }    
        }
    }
}
