namespace Level03.Tests;

using NUnit.Framework;
using System.IO;

[TestFixture]
public class InteractionTests
{
    [Test]
    public void Greet_builds_the_exact_welcome_line()
    {
        Assert.That(Interaction.Greet("Sam"), Is.EqualTo("Hello, Sam! Welcome to C# Quest."),
            "Use string interpolation: $\"Hello, {name}! Welcome to C# Quest.\"");
    }

    [Test]
    public void Greet_uses_the_argument_not_a_hardcoded_name()
    {
        Assert.That(Interaction.Greet("Alex"), Is.EqualTo("Hello, Alex! Welcome to C# Quest."),
            "Your greeting must use the name argument, not a hardcoded value.");
    }

    [Test]
    public void DoubleIt_parses_text_and_doubles_it()
    {
        Assert.That(Interaction.DoubleIt("21"), Is.EqualTo(42),
            "Convert the text to an int with int.Parse, then multiply by 2.");
    }

    [Test]
    public void DoubleIt_works_for_zero()
    {
        Assert.That(Interaction.DoubleIt("0"), Is.EqualTo(0));
    }

    [Test]
    public void ReadAndGreet_greets_whatever_the_user_typed()
    {
        var originalIn = Console.In;
        try
        {
            Console.SetIn(new StringReader("Jordan\n"));
            Assert.That(Interaction.ReadAndGreet(), Is.EqualTo("Hello, Jordan! Welcome to C# Quest."),
                "Use Console.ReadLine() to capture the typed line, then pass it to Greet().");
        }
        finally
        {
            Console.SetIn(originalIn);
        }
    }
}
