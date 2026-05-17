namespace Level02.Tests;

using NUnit.Framework;

[TestFixture]
public class VariablesTests
{
    [Test]
    public void GetMyAge_returns_a_positive_whole_number()
    {
        var age = Variables.GetMyAge();
        Assert.That(age, Is.GreaterThan(0),
            "Return your real age (any positive whole number). The starter 0 is not a real age.");
        Assert.That(age, Is.LessThan(150),
            "That looks too high to be an age in years.");
    }

    [Test]
    public void GetMyName_returns_a_non_empty_string()
    {
        var name = Variables.GetMyName();
        Assert.That(name, Is.Not.Null.And.Not.Empty,
            "Return your name wrapped in double quotes, e.g. return \"Sam\";");
    }

    [Test]
    public void LikesCoffee_can_be_true_or_false_but_must_compile_as_bool()
    {
        // The compiler already guarantees it's a bool. We just ensure
        // the method actually executes without errors.
        Assert.DoesNotThrow(() => Variables.LikesCoffee(),
            "LikesCoffee() should simply return true or false.");
    }

    [Test]
    public void GetPrice_returns_exactly_19_point_99()
    {
        var price = Variables.GetPrice();
        Assert.That(price, Is.EqualTo(19.99).Within(0.0001),
            "Return the value 19.99 (a double — decimals are fine).");
    }

    [Test]
    public void BuildGreeting_matches_the_required_shape()
    {
        var result = Variables.BuildGreeting("Sam", 25);
        Assert.That(result, Is.EqualTo("Hello Sam, you are 25."),
            "Use $\"Hello {name}, you are {age}.\" with curly braces around name and age.");
    }

    [Test]
    public void BuildGreeting_uses_the_arguments_not_hardcoded_values()
    {
        var result = Variables.BuildGreeting("Alex", 40);
        Assert.That(result, Is.EqualTo("Hello Alex, you are 40."),
            "Your method must use the name and age arguments — not hardcoded Sam/25.");
    }
}
