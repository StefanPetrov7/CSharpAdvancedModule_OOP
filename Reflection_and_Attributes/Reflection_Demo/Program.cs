using System;
using System.Linq;
using System.Reflection;

namespace Reflection_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //string type = Console.ReadLine();

            // Compile time obtaining Type data.
            //Type testType = typeof(TestClass);

            // Run Time Obtaining Type Data;
            // GetType(type) is excpecting string => full name => namespace etc... => Reflection_Demo.TestClass
            // Always add check for null after.
            //Type testType = Type.GetType(type);
            //Console.WriteLine($"{Type.GetType(type)?.Name}");


            // Creating Instance
            // return type object
            // need explisit cast
            // With object[] we are passing params to ctor, can be any types this is why is an object[].
            // ctor params need to be in the correct order, or exception will be thrown.
            //var testType = Type.GetType("Reflection_Demo.TestClass");
            //TestClass instance = (TestClass)Activator.CreateInstance(testType, new object[] {"Pesho", 25});



            // Working with fields and prop

            var testType = Type.GetType("Reflection_Demo.TestClass");

            // returns [] from FieldsInfo
            // to return all private,public etc we need to use bitywise operation => Binding.Flags
            var fieldsPublic = testType.GetFields();

            // below will return all props and fields.
            var fieldsPublicAll = testType
                .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

            // return specific field and it's type.
            // We need to use BindingFlags other wise it will return only the public ones, null exception must be considered as always.
            var field = testType.GetField("name");
            Type fieldType = field.GetType();

            // Manipulating fields, we need instance of the object.
            // We use binding flags since the field is private.
            // Encapsulation is broken.
            TestClass instance = (TestClass)Activator.CreateInstance(testType, new object[] { "Pesho", 25 });
            var filed2 = testType.GetField("secret", BindingFlags.NonPublic | BindingFlags.Instance);
            filed2.SetValue(instance, "manipulated");


            // Getting Ctor.
            // It's called over the Type it self not the instance.
            // We can use the immedeate window to check individual ctor params
            TestClass instance2 = (TestClass)Activator.CreateInstance(testType, new object[] { "Pesho", 25 });
            ConstructorInfo[] cinfo = testType.GetConstructors();

            // Getting particular ctor => we need as argument Type[] from his parameters.
            //ConstructorInfo cinfo = testType.GetConstructor(xxxxxxxx);

            // Using Invoke method to call a specific ctor, knowing his specific params and giving them as an object [].
            // Invoke is returning object, we still need to cast. 
            var instance3 = (TestClass)cinfo[1].Invoke(new object[] { "Stefan" });



            // Methods access.
            // Again we need the testType, not concret instance.
            // Again we need to use BindingFlags for all type of methods etc... private, public...
            // We can use Invoke on a specific instance to call method and to use it.
            MethodInfo[] methods = testType.GetMethods();
            // Calling method 1 [Age], on instance 3,  and seting it to 30. !!!!
            // Get and Set are numbered as different methods [1] is Set for teh Age.
            methods[1].Invoke(instance3, new object[] { 30 });

            // Calling specific method and Invoke on a specific Type.
            // Adding ? incase of null reference.
            MethodInfo who = testType.GetMethod("WhoAmI");
            who?.Invoke(instance3, new object[] { });


            // Attributes
            var attr = who.GetCustomAttributes().Where(a => a.GetType() == typeof(AuthorAttribute));





        }
    }
}
