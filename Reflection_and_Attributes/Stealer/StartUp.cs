using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();

            //string result = spy.AnalyzeAcessModifiers("Stealer.Hacker");
            //Console.WriteLine(result);

            //string resultMethods = spy.RevealPrivateMethods("Stealer.Hacker");
            //Console.WriteLine(resultMethods);

            string returnTypes = spy.CollectGettersAndSetters("Stealer.Hacker");
            Console.WriteLine(returnTypes);
        }
    }
}
