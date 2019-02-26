using System;
using OpenQA.Selenium;
#if NETFRAMEWORK
using OpenQA.Selenium.Support.PageObjects;
#endif
using Vaft.Framework.Settings;

namespace Vaft.Framework.Core
{
    public abstract class PageBase : WebOperationsBase
    {
        public string BaseUrl;

        protected PageBase(IWebDriver driver)
            : base(driver)
        {
#if NETFRAMEWORK
            PageFactory.InitElements(driver, this);
#endif
            //PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(3)));
        }

        /// <summary>Opens ApplicationBaseUrl defined in app.config</summary>
        [Obsolete("Please use WebDriver extension method: Driver.VaftExt().OpenApplicationBaseUrl()")]
        public PageBase NavigateToUrl()
        {
            Driver.Navigate().GoToUrl(Config.Settings.RuntimeSettings.AppBaseUrl);
            return this;
        }

        /// <summary>Opens ApplicationBaseUrl defined in app.config</summary>
        /// <param name="urlPath">Dynamic part of URL path (excluding base URL).</param>
        [Obsolete("Please use WebDriver extension method: Driver.VaftExt().OpenApplicationBaseUrl()")]
        public PageBase NavigateToUrl(string urlPath)
        {
            Driver.Navigate().GoToUrl(Config.Settings.RuntimeSettings.AppBaseUrl + urlPath);
            return this;
        }
    }
}
