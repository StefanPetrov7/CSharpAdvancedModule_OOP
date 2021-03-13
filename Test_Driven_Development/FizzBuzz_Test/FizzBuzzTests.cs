using FizzBuzz_Test.Fake;
using FizzBuzz_X;
using FizzBuzz_X.Contracts;
using Moq;
using NUnit.Framework;

namespace FizzBuzz_Test
{

    public class FizzBuzzTests
    {
        private Mock<IWriter> writer;
        private FizzBuzz fizzBuzz;
        private string result;


        [SetUp]
        public void Setup()
        {
            this.writer = new Mock<IWriter>();
            this.writer.Setup(w => w.WriteLine(It.IsAny<string>())).Callback<string>(input => result += input);
            this.fizzBuzz = new FizzBuzz(this.writer.Object);
            this.result = "";
        }

        [Test]
        public void GivenFizzBuzzNumbersAre1to2ThenResultShouldBeCorrect()
        {
            // Mock<IWriter> writer = new Mock<IWriter>();
            fizzBuzz.PrintNumbers(1, 2);
            Assert.AreEqual("12", result);
        }

        [Test]
        public void GivenFizzBuzzNumbersAre1to3ThenResultShouldBeCorrect()
        {
            // Mock<IWriter> writer = new Mock<IWriter>();
            fizzBuzz.PrintNumbers(1, 3);
            Assert.AreEqual("12fizz", result);
        }

        [Test]
        public void GivenFizzBuzzNumbersAre4to6ThenResultShouldBeCorrect()
        {
            // Mock<IWriter> writer = new Mock<IWriter>();
            fizzBuzz.PrintNumbers(4, 6);
            Assert.AreEqual("4buzzfizz", result);
        }

        [Test]
        public void GivenFizzBuzzNumbersAre14to17ThenResultShouldBeCorrect()
        {
            // Mock<IWriter> writer = new Mock<IWriter>();
            fizzBuzz.PrintNumbers(14, 17);
            Assert.AreEqual("14fizzbuzz1617", result);
        }

        [Test]
        public void GivenFizzBuzzNumbersAreMinus5to2ThenResultShouldBeCorrect()
        {
            // Mock<IWriter> writer = new Mock<IWriter>();
            fizzBuzz.PrintNumbers(-5, 2);
            Assert.AreEqual("12", result);
        }
    }
}