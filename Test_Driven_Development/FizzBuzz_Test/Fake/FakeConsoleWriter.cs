using System;
using FizzBuzz_X.Contracts;

namespace FizzBuzz_Test.Fake
{
    public class FakeConsoleWriter : IWriter
    {

        public void WriteLine(string input)
        {
            result += input;
        }

        public string result { get; set; }
    }
}
