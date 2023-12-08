using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace _5LabVilisova
{
    internal class PageObjectModel
    {
        private readonly IWebDriver _driver;

        private readonly By _a = By.XPath("//input[@ng-model='a']");
        private readonly By _aPlus = By.XPath("//button[@ng-click='inca()']");
        private readonly By _aMinus = By.XPath("//button[@ng-click='deca()']");
        private readonly By _b = By.XPath("//input[@ng-model='b']");
        private readonly By _bPlus = By.XPath("//button[@ng-click='incb()']");
        private readonly By _bMinus = By.XPath("//button[@ng-click='decb()']");
        private readonly By _operation = By.TagName("select");
        private readonly By _result = By.TagName("b");

        public PageObjectModel(IWebDriver webDriver)
        {
            _driver = webDriver;
        }
        public PageObjectModel A(string a)
        {
            _driver.FindElement(_a).Clear(); //
            _driver.FindElement(_a).SendKeys(a); //вводит
            return this;
        }
        public PageObjectModel B(string b)
        {
            _driver.FindElement(_b).Clear();
            _driver.FindElement(_b).SendKeys(b);
            return this;
        }
        public PageObjectModel EnterPlusA()
        {
            _driver.FindElement(_aPlus).Click();
            return this;
        }
        public PageObjectModel EnterMinusA()
        {
            _driver.FindElement(_aMinus).Click();
            return this;
        }
        public PageObjectModel EnterPlusB()
        {
            _driver.FindElement(_bPlus).Click();
            return this;
        }
        public PageObjectModel EnterMinusB()
        {
            _driver.FindElement(_bMinus).Click();
            return this;
        }
        public PageObjectModel EnterOperation(string operation)
        {
            _driver.FindElement(_operation).Click();
            _driver.FindElement(By.XPath($".//option[@value='{operation}']")).Click();
            return this;
        }
        public string GetResult()
        {
            return _driver.FindElement(_result).Text.Split(' ').Last();
        }
        public string GetResultA()
        {
            return _driver.FindElement(_result).Text.Split(' ')[0];
        }
        public string GetResultB()
        {
            return _driver.FindElement(_result).Text.Split(' ')[2];
        }
        public string GetResultOperation()
        {
            return _driver.FindElement(_result).Text.Split(' ')[1];
        }

    }
}

