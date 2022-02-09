using OpenQA.Selenium;
using System;

namespace WebLibrary.Pages
{
    public class HomePage : PageBase
    {
        public HomePage(IWebDriver webDriver) : base(webDriver)
        {
        }
  
        private IWebElement bookAppointmentLink
            => Driver.FindElement(By.LinkText("Book an appointment"));

        private IWebElement existedHomeLoansRadio 
            => Driver.FindElement(By.Id("servicing"));
     
        private IWebElement nextButton
            => Driver.FindElement(By.XPath("//*[contains(text(),'Next')]"));
       
        


      public void go_to_book_appointment()
        {
            WaitForElement(bookAppointmentLink);
            bookAppointmentLink.Click();
        }
      
       
        protected override bool EvaluateLoadedStatus()
        {
            try
            {
                WaitForElement(bookAppointmentLink);
                return true;
            }
            catch
            {
                throw new Exception("page not load");
            }    
        }
    }
}
