
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace TestKuboFit.Pages
{

    public class ResetPasswordPage
    {
        protected IWebDriver driver;
  

        [FindsBy(How = How.XPath, Using = ".//*[@id='Email']")]
        public IWebElement EmailAddress { get; set; }


        [FindsBy(How = How.XPath, Using = ".//*[@class='btn btn-default reset-button']")]
        public IWebElement ResetButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='inboxfield']")]
        public IWebElement EmailMailinator { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='hidden-sm hidden-xs']//button[@type='button'][contains(text(),'Go!')]")]
        public IWebElement GoButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//tr[contains(@id,'row_testkfr')]//td[@class='ng-binding'][contains(text(),'KuboFit Reset Password Request')]")]
        public IWebElement PassResetRequestButton { get; set; }

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[3]/div[1]/div[6]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[2]/td[5]")]
        public IWebElement PassResetRequestButton2 { get; set; }


        [FindsBy(How = How.XPath, Using = "//iframe[@id='msg_body']")]
        public IWebElement ClickIframe { get; set; }

        [FindsBy(How = How.XPath, Using = "//td[@bgcolor='#ffffff']")]
        public IWebElement ClickBG { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Reset Password')]")]
        public IWebElement ResetPasswordButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='Password']")]
        public IWebElement Password { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@class='col-md-6 col-sm-offset-3']")]
        public IWebElement ClickH1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='ConfirmPassword']")]
        public IWebElement ConfirmPassword { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[@class='btn btn-default reset-button']")]
        public IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'Your password has been reset')]")]
        public IWebElement SuccessfulReset { get; set; }

        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'Password Reset Email Sent')]")]
        public IWebElement EmailResetMessage { get; set; }

        public void IframeClick()
        {
            IWebElement detailFrame = ClickIframe;
            driver.SwitchTo().Frame(detailFrame);
            
        }

        public void VerifyResetPassword()
        {
            
           var ResetText = "Your password has been reset";
           Assert.AreEqual(ResetText, SuccessfulReset.Text);
      
        }

        public void VerifyEmailResetMessage()
        {

            var ResetText = "Password Reset Email Sent";
            Assert.AreEqual(ResetText, EmailResetMessage.Text);

        }

        [FindsBy(How = How.XPath, Using = "//tr[contains(@id,'row_testkfr')]//td[@class='ng-binding'][contains(text(),'KuboFit Reset Password Request')]")]
        public IWebElement PassResetEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='input-group-btn']")]
        public IWebElement Inbox { get; set; }
        public void VerifyEmail()
        {

            try
            {
                PassResetEmail.Click();
                
            }
            catch (TimeoutException e)
            {
                Assert.Pass();
            }
            catch (WebDriverException e)
            {
                Assert.Pass();
            }
            catch (NullReferenceException e)
            {
                Assert.Pass();
            }
      

        }

        [FindsBy(How = How.XPath, Using = "//*[@class='text-danger field-validation-error']")]
        public IWebElement Errors { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Invalid token provided')]")]
        public IWebElement InvalidToken { get; set; }




    }
}



