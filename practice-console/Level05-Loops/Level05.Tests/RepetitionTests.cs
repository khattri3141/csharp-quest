namespace Level05.Tests;

using NUnit.Framework;

[TestFixture]
public class RepetitionTests
{
    [TestCase(1, 1)]
    [TestCase(5, 15)]
    [TestCase(10, 55)]
    [TestCase(100, 5050)]
    public void SumToN_adds_every_number_from_1_to_n(int n, int expected)
    {
        Assert.That(Repetition.SumToN(n), Is.EqualTo(expected),
            "Loop from 1 to n, adding each number to a running total.");
    }

    [Test]
    public void Countdown_counts_down_then_says_liftoff()
    {
        Assert.That(Repetition.Countdown(3),
            Is.EqualTo(new List<string> { "3", "2", "1", "Liftoff!" }),
            "Add each number as text from n down to 1, then add \"Liftoff!\".");
    }

    [Test]
    public void Countdown_works_for_a_single_step()
    {
        Assert.That(Repetition.Countdown(1),
            Is.EqualTo(new List<string> { "1", "Liftoff!" }));
    }
}
