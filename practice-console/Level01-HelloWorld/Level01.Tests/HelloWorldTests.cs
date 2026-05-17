namespace Level01.Tests;

using NUnit.Framework;
using System.IO;

[TestFixture]
public class HelloWorldTests
{
    private StringWriter _stdout = null!;
    private TextWriter _originalOut = null!;

    [SetUp]
    public void RedirectConsole()
    {
        _originalOut = Console.Out;
        _stdout = new StringWriter();
        Console.SetOut(_stdout);
    }

    [TearDown]
    public void RestoreConsole()
    {
        Console.SetOut(_originalOut);
        _stdout.Dispose();
    }

    [Test]
    public void Run_prints_exact_text_Hello_World()
    {
        HelloProgram.Run();
        var output = _stdout.ToString().TrimEnd('\r', '\n');
        Assert.That(output, Is.EqualTo("Hello, World!"),
            "Your output should be exactly: Hello, World!  (capital H, capital W, comma, exclamation)");
    }

    [Test]
    public void Run_writes_a_newline_at_the_end()
    {
        HelloProgram.Run();
        var output = _stdout.ToString();
        Assert.That(output.EndsWith("\n") || output.EndsWith(Environment.NewLine), Is.True,
            "Use Console.WriteLine (not Console.Write) so the line ends with a newline.");
    }
}
