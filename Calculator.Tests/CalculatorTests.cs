using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using System.Collections.Generic;

namespace Calculator.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void MethodCalculateTest_TestStringEquationAdd_CorrectResultExpected()
        {
            // Arrange
            string testString = "15+(713-4+(3-2))/(5+(12.5+15.3)*2)+(18-4*2)+1*2";
            Calculator calculator = new Calculator();
            string expected = "38,71617161716172";
            // Act
            string actual = calculator.Calculate(testString);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MethodCalculateTest_TestStringEquationAdd_WrongResultExpected()
        {
            // Arrange
            string testString = "15+713-4+(3-2))/(5+(12.5+15.3)*2)+(18-4*2)+1*2";
            Calculator calculator = new Calculator();
            string expected = "725)/72,6 (Incorect equation)";
            // Act
            string actual = calculator.Calculate(testString);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MethodCalculateTest_TestStringEquationAdd_DivineByZeroResultExpected()
        {
            // Arrange
            string testString = "14/0";
            Calculator calculator = new Calculator();
            string expected = "Error. Division by 0 (Incorect equation)";
            // Act
            string actual = calculator.Calculate(testString);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MethodCalculateTest_TestListEquationAdd_CorrectResultExpected()
        {
            // Arrange
            List<string> testList = new List<string> { new string("12/3") };
            Calculator calculator = new Calculator();
            List<string> expected = new List<string> { new string("4") };
            // Act
            List<string> actual = calculator.Calculate(testList);
            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
    [TestClass]
    public class RepositoryFactoryTests
    {
        [TestMethod]
        public void MethodRepositoryTest_TestStringEquationAdd_ClassConsoleInputExpected()
        {
            // Arrange
            string testString = "15+(713-4+(3-2))/(5+(12.5+15.3)*2)+(18-4*2)+1*2";
            RepositoryFactory repositoryFactory = new RepositoryFactory(testString);
            ConsoleInput expected = new ConsoleInput(testString);
            // Act
            var actual = repositoryFactory.Repository();
            // Assert
            Assert.IsInstanceOfType(actual,expected.GetType());
        }

        [TestMethod]
        public void MethodRepositoryTest_TestFileEquationAdd_ClassFileInputExpected()
        {
            // Arrange
            string testString = "file.txt";
            RepositoryFactory repositoryFactory = new RepositoryFactory(testString);
            // Act
            var actual = repositoryFactory.Repository();
            // Assert
            Assert.IsTrue(actual is FileInput);
        }
    }
    [TestClass]
    public class ConsoleInputTests
    {
        [TestMethod]
        public void MethodGetTest_TestListStringEquationAdd_ListStringEquationExpected()
        {
            // Arrange
            string testString = "15+(713-4+(3-2))/(5+(12.5+15.3)*2)+(18-4*2)+1*2";
            ConsoleInput consoleInput = new ConsoleInput(testString);
            List<string> expected = new List<string>() { new string("15+(713-4+(3-2))/(5+(12.5+15.3)*2)+(18-4*2)+1*2") };
            // Act
            List<string> actual = consoleInput.Get();
            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
    [TestClass]
    public class FileInputTests
    {
        [TestMethod]
        public void MethodGetTest_TestFileEquationAdd_ListEquationExpected()
        {
            // Arrange
            string testString = "file.txt";
            FileInput fileInput = new FileInput(testString);
            List<string> expected = new List<string>() { new string("15+(713-4+(3-2))/(5+(12.5+15.3)*2)+(18-4*2)+1*2"),
                                                         new string("15+713-4+(3-2))/(5+(12.5+15.3)*2)+(18-4*2)+1*2"),
                                                         new string("15/0"),
                                                         new string("(2*2)+(3*3)-(15/3)"),
                                                         new string("not equation"),
                                                         new string("2+11-3"),
                                                         new string("8.5*3-10"),
                                                         new string("2+2*3"),
                                                         new string("1+2*(3+2)"),
                                                         new string("1+2+4"),
                                                         new string("2+15/3+4*2"),
                                                         new string("x-4"),
                                                         new string("1-x"),
                                                         new string("x+4"),
                                                         new string("1+x"),
                                                         new string("x*4"),
                                                         new string("1*x"),
                                                         new string("x/4"),
                                                         new string("1/x"),
                                                         new string("2+x-3"),
                                                         new string("1+x+4")};
            // Act
            List<string> actual = fileInput.Get();
            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
