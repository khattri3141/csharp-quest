namespace Level05.Tests;

using NUnit.Framework;

[TestFixture]
public class ProblemsTests
{
    [Test]
    public void FizzBuzz_produces_the_full_sequence_up_to_15()
    {
        var expected = new List<string>
        {
            "1", "2", "Fizz", "4", "Buzz",
            "Fizz", "7", "8", "Fizz", "Buzz",
            "11", "Fizz", "13", "14", "FizzBuzz",
        };
        Assert.That(Problems.FizzBuzz(15), Is.EqualTo(expected),
            "Check divisible-by-15 first, then 3, then 5, else the number as text.");
    }

    [Test]
    public void FizzBuzz_returns_a_list_the_length_of_n()
    {
        Assert.That(Problems.FizzBuzz(5), Has.Count.EqualTo(5));
    }

    [TestCase(3, "Fizz")]
    [TestCase(5, "Buzz")]
    [TestCase(15, "FizzBuzz")]
    [TestCase(1, "1")]
    public void FizzBuzz_classifies_the_last_element_correctly(int n, string expectedLast)
    {
        var result = Problems.FizzBuzz(n);
        Assert.That(result[^1], Is.EqualTo(expectedLast));
    }
}
