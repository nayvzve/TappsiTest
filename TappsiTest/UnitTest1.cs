using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;

namespace TappsiTest
{
    [TestClass]
    public class UnitTest1
    {
        //crear el Appium_driver 
        AppiumDriver<AppiumWebElement> driver;
         
        [TestMethod]
        public void TestMethodLogin()
        {
            DesiredCapabilities cap = new DesiredCapabilities();
            cap.SetCapability("deviceName", "serranods");
            cap.SetCapability("platformVersion", "6.0.1");
            cap.SetCapability("platformName", "Android");
            cap.SetCapability("appPackage", "appinventor.ai_juansalcedo4");
            cap.SetCapability("appActivity", ".Tappsista");
            
            // Texto a Validar
            var validText = "Su cuenta se encuentra suspendida por razones disciplinarias. ";
            driver = new AndroidDriver<AppiumWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);

            // TextBox de Cedula 
            driver.FindElement(By.Id("appinventor.ai_juansalcedo4.Tappsista:id/txtId")).SendKeys("1075235486");

            // TextBox de Pass
            driver.FindElement(By.Id("appinventor.ai_juansalcedo4.Tappsista:id/txtPassword")).SendKeys("#T4PPS1#");

            // Btn  Login  
             driver.FindElement(By.Id("appinventor.ai_juansalcedo4.Tappsista:id/btnLogin")).Click();

            // Texto del Msj
            var recivedText = driver.FindElement(By.Id("appinventor.ai_juansalcedo4.Tappsista:id/textdisplay")).Text;

            // Validacion
            Assert.AreEqual(validText, recivedText); 
        }

        [TestCleanup]
        public void AfterAll()
        {
            driver.Quit();
        }
    }
}
