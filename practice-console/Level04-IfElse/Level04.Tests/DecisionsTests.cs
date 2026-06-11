namespace Level04.Tests;

using NUnit.Framework;

[TestFixture]
public class DecisionsTests
{
    [TestCase(100, "A")]
    [TestCase(90, "A")]
    [TestCase(89, "B")]
    [TestCase(80, "B")]
    [TestCase(75, "C")]
    [TestCase(60, "D")]
    [TestCase(59, "F")]
    [TestCase(0, "F")]
    public void Grade_maps_score_to_the_right_letter(int score, string expected)
    {
        Assert.That(Decisions.Grade(score), Is.EqualTo(expected),
            "Check thresholds from highest to lowest in an if / else if chain.");
    }

    [TestCase(2000, true)]
    [TestCase(1900, false)]
    [TestCase(2024, true)]
    [TestCase(2023, false)]
    [TestCase(2400, true)]
    public void IsLeapYear_follows_the_400_year_rule(int year, bool expected)
    {
        Assert.That(Decisions.IsLeapYear(year), Is.EqualTo(expected),
            "Divisible by 4, but century years must also be divisible by 400.");
    }
}
