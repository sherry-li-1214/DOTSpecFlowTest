
using System;
using WebLibrary.Pages;

namespace SeleniumSpecFlow.Utilities
{
    public class ObjectFactory
    {
        protected Lazy<DriverFactory> DriverFactory = new Lazy<DriverFactory>();
        public Lazy<HomePage> HomePage = new Lazy<HomePage>(() => new HomePage(Hooks.Driver));
        public Lazy<QuestionsListPage> QuestionsListPage = new Lazy<QuestionsListPage>(() => new QuestionsListPage(Hooks.Driver));
        public Lazy<ContactInfoPage> ContactInfoPage = new Lazy<ContactInfoPage>(() => new ContactInfoPage(Hooks.Driver));
        public Lazy<SuccessPage> SuccessPage = new Lazy<SuccessPage>(() => new SuccessPage(Hooks.Driver));

    }

}
