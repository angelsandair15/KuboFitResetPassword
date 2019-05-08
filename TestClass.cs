using NUnit.Framework;
using System;
using System.Diagnostics;
using TestKuboFit.Pages;
using OpenQA.Selenium.Support.PageObjects;
using TestKuboFit;
using OpenQA.Selenium;
using System.Linq;
using RelevantCodes.ExtentReports;

namespace TestKuboFit

{
    [TestFixture()]
    [Parallelizable]
    public class TestClass:TestBase 

    {
        [Test, Order(1)]
        [TestCaseSource(typeof(TestBase), "BrowserToRunWith")]
        public void TestLogin(String browserName)
        {

            ExcelOperations.ClearData();
            ExcelOperations.PopulateInCollection(@"C:\Users\baybayal\source\repos\KuboFitResetPassword\KuboFitResetPassword\TestData.xlsx");
            string email = ExcelOperations.ReadData(1, "email");
            string password = ExcelOperations.ReadData(8, "password");
            string confirmpassword = ExcelOperations.ReadData(8, "confirmpassword");
            string scenario = ExcelOperations.ReadData(8, "scenario");

            test = extent.StartTest("[" + (browserName) + "]" + "KuboFit Reset Password Report - " + scenario);

            Setup(browserName);
            int minTestimonialCount = 10;

            //IWebDriver driver = new ChromeDriver();
            driver.Url = "https://account-test.kubofit.com/request-password-reset";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            //Go to KuboFit Reset Password Page
            ResetPasswordPage RPPage = new ResetPasswordPage();
            PageFactory.InitElements(driver, RPPage);
            RPPage.EmailAddress.SendKeys(email);
            RPPage.ResetButton.Click();

            //Mailinator
            driver.Url = "https://www.mailinator.com/";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            RPPage.EmailMailinator.SendKeys(email);
            RPPage.GoButton.Click();
            RPPage.PassResetRequestButton.Click();
            IWebElement detailFrame = RPPage.ClickIframe;
            driver.SwitchTo().Frame(detailFrame);
            RPPage.ClickBG.Click();
            RPPage.ResetPasswordButton.Click();

            //Reset Password Page
            WaitOnPage(2);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            RPPage.Password.SendKeys(password);
            RPPage.ConfirmPassword.SendKeys(confirmpassword);
            RPPage.SubmitButton.Click();
            WaitOnPage(1);


            //Login Page
            driver.Url = "https://id.dev.kubofit.com/";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            LoginPage Login_Page = new LoginPage();
            PageFactory.InitElements(driver, Login_Page);

            Login_Page.Username.SendKeys(email);
            Login_Page.Password.SendKeys(password);
            Login_Page.SubmitButton.Click();
            Login_Page.VerifyLogin();

            test.Log(LogStatus.Pass, scenario + " -Passed");
            extent.EndTest(test);


            DriverQuit();
        }

        [Test,Order(2)]
        [TestCaseSource(typeof(TestBase), "BrowserToRunWith")]
        public void TestResetPassword(String browserName)
        {

            for (int i = 1; i < 8; i++)
            {
                ExcelOperations.ClearData();
                ExcelOperations.PopulateInCollection(@"C:\Users\baybayal\source\repos\KuboFitResetPassword\KuboFitResetPassword\TestData.xlsx");
                string email = ExcelOperations.ReadData(1, "email");
                string password = ExcelOperations.ReadData(i, "password");
                string confirmpassword = ExcelOperations.ReadData(i, "confirmpassword");
                string scenario = ExcelOperations.ReadData(i, "scenario");

                test = extent.StartTest("["+(browserName)+"]"+"KuboFit Reset Password Report - " + scenario);

                Setup(browserName);
                int minTestimonialCount = 10;

                //IWebDriver driver = new ChromeDriver();
                driver.Url = "https://account-test.kubofit.com/request-password-reset";
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

                //Go to KuboFit Reset Password Page
                ResetPasswordPage RPPage = new ResetPasswordPage();
                PageFactory.InitElements(driver, RPPage);
                RPPage.EmailAddress.SendKeys(email);
                RPPage.ResetButton.Click();

                //Mailinator
                driver.Url = "https://www.mailinator.com/";
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

                RPPage.EmailMailinator.SendKeys(email);
                RPPage.GoButton.Click();
                RPPage.PassResetRequestButton.Click();
                IWebElement detailFrame = RPPage.ClickIframe;
                driver.SwitchTo().Frame(detailFrame);
                RPPage.ClickBG.Click();
                RPPage.ResetPasswordButton.Click();

            //Reset Password Page
                WaitOnPage(2);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                RPPage.Password.SendKeys(password);
                RPPage.ConfirmPassword.SendKeys(confirmpassword);
                RPPage.SubmitButton.Click();
                WaitOnPage(2);
                RPPage.VerifyResetPassword();
                test.Log(LogStatus.Pass, scenario + " -Passed");
                extent.EndTest(test);
                DriverQuit();
            }
        }

        [Test,Order(3)]
        [TestCaseSource(typeof(TestBase), "BrowserToRunWith")]
        public void TestResetPasswordErrors(String browserName)
        {

            ExcelOperations.ClearData();
            ExcelOperations.PopulateInCollection(@"C:\Users\baybayal\source\repos\KuboFitResetPassword\KuboFitResetPassword\TestData.xlsx");
            string email = ExcelOperations.ReadData(1, "email");



            //test = extent.StartTest("[" + (browserName) + "]" + "KuboFit Reset Password Report - " + scenario);

            Setup(browserName);
            int minTestimonialCount = 10;

            //IWebDriver driver = new ChromeDriver();
            driver.Url = "https://account-test.kubofit.com/request-password-reset";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            //Go to KuboFit Reset Password Page
            ResetPasswordPage RPPage = new ResetPasswordPage();
            PageFactory.InitElements(driver, RPPage);
            RPPage.EmailAddress.SendKeys(email);
            RPPage.ResetButton.Click();

            //Mailinator
            driver.Url = "https://www.mailinator.com/";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            RPPage.EmailMailinator.SendKeys(email);
            RPPage.GoButton.Click();
            RPPage.PassResetRequestButton.Click();
            IWebElement detailFrame = RPPage.ClickIframe;
            driver.SwitchTo().Frame(detailFrame);
 
            RPPage.ClickBG.Click();
            RPPage.ResetPasswordButton.Click();

            //Reset Password Page
            WaitOnPage(2);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            for (int i = 11; i < 16; i++)
            {
                string password = ExcelOperations.ReadData(i, "password");
                string confirmpassword = ExcelOperations.ReadData(i, "confirmpassword");
                string scenario = ExcelOperations.ReadData(i, "scenario");
                test = extent.StartTest("[" + (browserName) + "]" + "KuboFit Reset Password Report - " + scenario);
                RPPage.Password.SendKeys(password);
                RPPage.ConfirmPassword.SendKeys(confirmpassword);
                RPPage.SubmitButton.Click();
                WaitOnPage(1);
                Assert.AreEqual(scenario, RPPage.Errors.Text);

                test.Log(LogStatus.Pass, scenario + " -Passed");
                extent.EndTest(test);
            }

            //Invalid Token Scenario
            var ErrorText = "Invalid token provided (401, E0000011)";
            test = extent.StartTest("[" + (browserName) + "]" + "KuboFit Reset Password Report - " + ErrorText);
            driver.Url = "https://www.mailinator.com/";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            RPPage.EmailMailinator.SendKeys(email);
            RPPage.GoButton.Click();
            RPPage.PassResetRequestButton2.Click();
            IWebElement detailFrame1 = RPPage.ClickIframe;
            driver.SwitchTo().Frame(detailFrame1);
            RPPage.ClickBG.Click();
            RPPage.ResetPasswordButton.Click();
          
            Assert.AreEqual(ErrorText, RPPage.InvalidToken.Text);

            test.Log(LogStatus.Pass, ErrorText + " -Passed");
            extent.EndTest(test);
            DriverQuit();

        }


        [Test,Order(4)]
        [TestCaseSource(typeof(TestBase), "BrowserToRunWith")]
        public void TestNonExistentEmail(String browserName)
        {

            ExcelOperations.ClearData();
            ExcelOperations.PopulateInCollection(@"C:\Users\baybayal\source\repos\KuboFitResetPassword\KuboFitResetPassword\TestData.xlsx");
            string email = ExcelOperations.ReadData(9, "email");
            string scenario = ExcelOperations.ReadData(9, "scenario");

            test = extent.StartTest("[" + (browserName) + "]" + "KuboFit Reset Password Report - " + scenario);

            Setup(browserName);
            int minTestimonialCount = 10;

            //IWebDriver driver = new ChromeDriver();
            driver.Url = "https://account-test.kubofit.com/request-password-reset";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            //Go to KuboFit Reset Password Page
            ResetPasswordPage RPPage = new ResetPasswordPage();
            PageFactory.InitElements(driver, RPPage);
            RPPage.EmailAddress.SendKeys(email);
            RPPage.ResetButton.Click();
            RPPage.VerifyEmailResetMessage();
            WaitOnPage(2);

            //Mailinator
            driver.Url = "https://www.mailinator.com/";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            RPPage.EmailMailinator.SendKeys(email);
            RPPage.GoButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            RPPage.Inbox.Click();
            RPPage.VerifyEmail();

            test.Log(LogStatus.Pass, scenario + " Passed");

            DriverQuit();
        }

       
        public void WaitOnPage(int seconds)
        {
            System.Threading.Thread.Sleep(seconds * 1000);
        }

        public void DriverQuit()
        {
            Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");

            foreach (var chromeDriverProcess in chromeDriverProcesses)
            {
                chromeDriverProcess.Kill();
            }
        }

      
    }





}
