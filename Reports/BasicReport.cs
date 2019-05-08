//using NUnit.Framework;
//using NUnit.Framework.Interfaces;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.IE;
//using RelevantCodes.ExtentReports;
//using System;
//using System.Collections.Generic;

//namespace RegressionTestingFF
//{
//    public abstract class BasicReport
//    {
//        public ExtentReports extent;
//        public ExtentTest test;
//        protected IWebDriver driver;

//        public void Setup(String browserName)
//        {


//            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\Users\baybayal\Downloads\gecko64");

//            if (browserName.Equals("firefox"))

//                driver = new FirefoxDriver(service);

//            else if (browserName.Equals("chrome"))
//                driver = new ChromeDriver();
//            else
//                driver = new InternetExplorerDriver();


//            driver.Manage().Window.Maximize();
//            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

//        }
//        //[TearDown]
//        //public void Cleanup()
//        //{
//        //    driver.Quit();
//        //}

//        public static IEnumerable<String> BrowserToRunWith()
//        {
//            String[] browsers = BrowserSettings.BrowserToRunWith.Split(',');
//            foreach (String b in browsers)
//            {
//                yield return b;
//            }
//        }

//        [OneTimeSetUp]
//        public void StartReport()
//        {
//            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
//            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
//            string projectPath = new Uri(actualPath).LocalPath;
//            string reportPath = projectPath + "Reports\\MemberPortalReport.html";

//            extent = new ExtentReports(reportPath, true);
//            extent
//            .AddSystemInfo("Host Name", "Allen")
//            .AddSystemInfo("Environment", "QA")
//            .AddSystemInfo("User Name", "Allen");
//            extent.LoadConfig(projectPath + "extent-config.xml");
//        }

//        [Test]
//        public void DemoReportPass()
//        {
//            test = extent.StartTest("DemoReportPass");
//            Assert.IsTrue(true);
//            test.Log(LogStatus.Pass, "Assert Pass as condition is True");
//        }

//        [Test]
//        public void DemoReportFail()
//        {
//            test = extent.StartTest("DemoReportFail");
//            Assert.IsTrue(false);
//            test.Log(LogStatus.Pass, "Assert Fail as condition is False");
//        }

//        [TearDown]
//        public void GetResult()
//        {
//            var status = TestContext.CurrentContext.Result.Outcome.Status;
//            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
//            var errorMessage = TestContext.CurrentContext.Result.Message;

//            if (status == TestStatus.Failed)
//            {
//                test.Log(LogStatus.Fail, stackTrace + errorMessage);
//            }
//            extent.EndTest(test);
//        }

//        [OneTimeTearDown]
//        public void EndReport()
//        {
//            extent.Flush();
//            extent.Close();
//        }





//    }
//}