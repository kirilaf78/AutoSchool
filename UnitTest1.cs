using NUnit.Framework.Constraints;

namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("The test is running");
        }

        [Test]
        public void IsStringMatch()
        {
            string pattern_string = "Nix company";
            string string_to_compare = "Nix company";
            StringAssert.IsMatch(pattern_string, string_to_compare, $"{string_to_compare} string doesn't equal to {pattern_string} string");
        }

        [Test, Repeat(2)]
        public void IsListEqual()
        {
            List<string> pattern_list = new List<string> { "some", "random", "words" };
            List<string> list_to_compare = new List<string> { "random", "words", "some", };
            Assert.That(list_to_compare, Is.EquivalentTo(pattern_list), $"{list_to_compare} not equal to {pattern_list}");
        }

        [Test]
        public void IsContainsString()
        {
            List<string> cars = new List<string> { "BMW", "Mercedes", "Renault" };
            string car = "Mercedes";

            CollectionAssert.Contains(cars, car, "The collection doesn't contains an element");
        }

        [Test, MaxTime(1000)]
        public void IsNumberGreater()
        {
            int a = 10;
            int b = 5;
            Assert.That(a, Is.GreaterThan(b), $"Expected number: {a} was less than actual number: {b}");
        }


        [TearDown]
        public void End()
        {
            Console.WriteLine("Test finished");
        }
    }
}