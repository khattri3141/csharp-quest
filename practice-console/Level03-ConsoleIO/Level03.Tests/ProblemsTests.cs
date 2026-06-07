namespace Level03.Tests;

using NUnit.Framework;

[TestFixture]
public class ProblemsTests
{
    [Test]
    public void DefangIp_replaces_every_dot()
    {
        Assert.That(Problems.DefangIp("1.1.1.1"), Is.EqualTo("1[.]1[.]1[.]1"),
            "Replace each \".\" with \"[.]\".");
    }

    [Test]
    public void DefangIp_handles_multi_digit_octets()
    {
        Assert.That(Problems.DefangIp("255.100.50.0"), Is.EqualTo("255[.]100[.]50[.]0"));
    }
}
