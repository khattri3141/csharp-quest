namespace Level04.Tests;

using NUnit.Framework;

[TestFixture]
public class ProblemsTests
{
    [TestCase(1, true)]
    [TestCase(2, true)]
    [TestCase(3, true)]
    [TestCase(4, false)]
    [TestCase(7, true)]
    [TestCase(8, false)]
    public void CanWinNim_is_false_only_on_multiples_of_four(int n, bool expected)
    {
        Assert.That(Problems.CanWinNim(n), Is.EqualTo(expected),
            "You can win unless n is a multiple of 4. Return n % 4 != 0.");
    }
}
