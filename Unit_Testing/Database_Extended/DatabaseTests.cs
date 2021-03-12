using System;
using NUnit.Framework;

namespace Tests
{
    // Test need to be refered to Database.cs and to be adjuste to Database.Database due to similarity of the namespaces.

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        private readonly int[] integers = new int[] { 1, 2, };  // Count = 2;
        private const int MAX_CAPACITY_TEST = 17;

        [SetUp]
        public void Setup()
        {
            this.database = new Database(integers);
        }

        [TestCase(new int[] { 1, 2, 3, 4 })]    // => Different casses.
        [TestCase(new int[] { })]               // => Different casses.
        public void TestIfCtorWorkesCorrectly(int[] dataTest)
        {
            int EXPECTED_COUNT = dataTest.Length;
            this.database = new Database(dataTest);
            Assert.That(this.database.Count, Is.EqualTo(EXPECTED_COUNT), "Ctor is not working");
            //Assert.AreEqual(EXPECTED_COUNT, this.database.Count, "Ctor is not working");  // => Syntaxis difference.
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        public void CtorShouldThrowExceptionIfInitialCapacityIsGrater(int[] dataTest)
        {

            // Diffierent Syntaxis.
            //Assert.Throws<InvalidOperationException>(() =>
            //{
            //    this.database = new Database.Database(dataTest);
            //});

            Assert.That(() =>   // Anonym func. 
            {
                this.database = new Database(dataTest);
            },
                Throws.InvalidOperationException.With.Message
                .EqualTo("Array's capacity must be exactly 16 integers!"), "Ctor is not working with initial capacity");
        }

        [Test]
        public void TestDataBaseCapacity()
        {
            this.database = new Database();
            Assert.That(() =>   // Anonym func. 
            {
                for (int i = 0; i < MAX_CAPACITY_TEST; i++)
                {
                    this.database.Add(i);
                }
            },
                 Throws.InvalidOperationException.With.Message
                .EqualTo("Array's capacity must be exactly 16 integers!"), "Max Capacity Exceeded");
        }

        [Test]
        public void TestAddOperatioToIncreaseCount()
        {
            int ellement = 1;
            int EXPECTED_COUNT = 3;
            this.database.Add(ellement);
            //Assert.AreEqual(EXPECTED_COUNT, this.database.Count, "Adding element is not working");
            Assert.That(this.database.Count, Is.EqualTo(EXPECTED_COUNT), "Adding element is not working");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void TestAddShouldThrowException(int[] maxedCapacity)
        {
            int ellement = 1;
            this.database = new Database(maxedCapacity);
            //Assert.That(() => this.database.Add(ellement),
            //    Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"),
            //    "Operation should throw exception");
            Assert.Throws<InvalidOperationException>(() => this.database.Add(ellement),"Should throw exception");
        }

        [Test]
        public void TestRemoveOperatio()
        {
            int EXPECTED_COUNT = 1;
            this.database.Remove();
            //Assert.AreEqual(EXPECTED_COUNT, database.Count, "Adding element is not working");
            Assert.That(this.database.Count, Is.EqualTo(EXPECTED_COUNT), "Adding element is not working");
        }

        [Test]
        public void TestRemoveItemExceptionForEmptyCollection()
        {
            this.database.Remove();
            this.database.Remove();
            Assert.Throws<InvalidOperationException>(() => this.database.Remove(), "Should throw exception");
        }

        [TestCase(new int[] {1,2,3,4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        [TestCase(new int[] { })]
        public void TestFetchMethodToCopyDatabase(int[] expectedData)
        {
            this.database = new Database(expectedData);
            int[] fetched = this.database.Fetch();
            CollectionAssert.AreEqual(expectedData, fetched, "Database is not copied");
        }

        
    }
}