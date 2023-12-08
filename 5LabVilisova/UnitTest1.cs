using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace _5LabVilisova
{
    public class Tests
    {
        public IWebDriver _driver;
        [SetUp]
        public void Setup()
        {
            PageObjectModel operations = new PageObjectModel(_driver);
            ChromeOptions options = new ChromeOptions(); // экземпл€р браузера
            options.AddArgument("--headless"); //аргумент чтобы не запускалс€
            _driver = new ChromeDriver(options); //создали объект и передали параметры
            _driver.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/"); //передали ссылку
        }

        [Test]
        public void Test1()
        {
            PageObjectModel operations = new PageObjectModel(_driver);
            operations.EnterPlusA();
            string result = operations.GetResult();
            Assert.AreEqual("1", result);
        }
        [Test]
        public void Test2()
        {
            PageObjectModel operations = new PageObjectModel(_driver);
            operations.EnterPlusB();
            string result = operations.GetResult();
            Assert.AreEqual("1", result);
        }
        [Test]
        public void Test3()
        {
            PageObjectModel operations = new PageObjectModel(_driver);
            operations.A("100");
            operations.EnterMinusA();
            string result = operations.GetResult();
            Assert.AreEqual("99", result);
        }
        [Test]
        public void Test4()
        {
            PageObjectModel operations = new PageObjectModel(_driver);
            operations.B("100");
            operations.EnterMinusB();
            string result = operations.GetResult();
            Assert.AreEqual("99", result);
        }
       
        [TestCase("6", "5","1")]
        [TestCase("6", "12", "-6")]
        [TestCase("-1", "3", "-4")]


        public void Test5( string a, string b, string c)
        {
            PageObjectModel operations = new PageObjectModel(_driver);
            operations.A(a);
            operations.B(b);
            operations.EnterOperation("-");
            string result = operations.GetResult();
            Assert.AreEqual(c, result);
        }
        [TestCase("1", "5", "5")]
        [TestCase("6", "100", "600")]
        [TestCase("-1", "3", "-3")]
        public void Test6(string a, string b, string c)
        {
            PageObjectModel operations = new PageObjectModel(_driver);
            operations.A(a);
            operations.B(b);
            operations.EnterOperation("*");
            string result = operations.GetResult();
            Assert.AreEqual(c, result);
        }
        [TestCase("1", "5", "0.2")]
        [TestCase("1.3", "5", "0.26")]
        [TestCase("4", "1", "4")]
        public void Test7(string a, string b, string c)
        {
            PageObjectModel operations = new PageObjectModel(_driver);
            operations.A(a);
            operations.B(b);
            operations.EnterOperation("/");
            string result = operations.GetResult();
            Assert.AreEqual(c, result);
        }
        [TestCase("1", "5", "6")]
        [TestCase("-6", "100", "94")]
        [TestCase("-1", "-5", "-6")]
        public void Test8(string a, string b, string c)
        {
            PageObjectModel operations = new PageObjectModel(_driver);
            operations.A(a);
            operations.B(b);
            operations.EnterOperation("+");
            string result = operations.GetResult();
            Assert.AreEqual(c, result);
        }

        [Test]
        public void Test9()
        {
                PageObjectModel operations = new PageObjectModel(_driver);
            operations.A("-12");
            string result = operations.GetResultA();
            Assert.AreEqual("-12", result);
        }
        [Test]
        public void Test10()
        {
            PageObjectModel operations = new PageObjectModel(_driver);
            operations.B("-678");
            string result = operations.GetResultB();
            Assert.AreEqual("-678", result);
        }
        [Test]
        public void Test11()
        {
            PageObjectModel operations = new PageObjectModel(_driver);
            operations.EnterOperation("*");
            string result = operations.GetResultOperation();
            Assert.AreEqual("*", result);
        }

        [TestCase("1", "0")]
        [TestCase("-10", "0")]
        [TestCase("10.6", "0")]

        public void Test12 (string a, string b)
        {
            PageObjectModel operations = new PageObjectModel(_driver);
            operations.A(a);
            operations.B(b);
            operations.EnterOperation("/");
            string result = operations.GetResult();
            Assert.AreEqual("null", result);
        }
        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
