using System;
namespace Reflection_Demo
{
    [Author("Stefan")]
    public class TestClass
    {
        private string secret = "My secret";

        private bool isCreated = false;

        public string name;

        public TestClass()
        {
            isCreated = true;
        }

        public TestClass(string name) : this()
        {
            this.name = name;
        }

        public TestClass(string name, int age) : this(name)
        {
            this.Age = age;
        }

        public int  Age { get; set; }


        [Author("Lubaka")]
        public void WhoAmI()
        {
            Console.WriteLine(name);
        }


        private void TellMeSecret()
        {
            Console.WriteLine(secret);
        }
    }
}
