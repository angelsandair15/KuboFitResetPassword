using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestKuboFit.Pages
{
    class LoginPage
    {

        protected IWebDriver driver;

        [FindsBy(How = How.XPath, Using = ".//*[@id='okta-signin-username']")]
        public IWebElement Username { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='okta-signin-password']")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='okta-signin-submit']")]
        public IWebElement SubmitButton { get; set; }


        [FindsBy(How = How.XPath, Using = ".//*[@class='to-animate intro-animate-2']")]
        public IWebElement SucessLogin { get; set; }

        public void VerifyLogin()
        {

            var ResetText = "Stay on track every step of the way.";
            Assert.AreEqual(ResetText, SucessLogin.Text);


        }



    }
}
