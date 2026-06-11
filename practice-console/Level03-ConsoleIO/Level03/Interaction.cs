namespace Level03;

// =======================================================
// Level 3 — Console I/O
//
// These are PURE methods: given an input, return the right
// output. Program.cs wires them up to REAL keyboard input
// with Console.ReadLine so you can see them work live.
// =======================================================
public static class Interaction
{
    // TODO #1
    // Return a friendly greeting for the given name, EXACTLY:
    //
    //     Hello, {name}! Welcome to C# Quest.
    //
    // For name = "Sam" the result must be:
    //     "Hello, Sam! Welcome to C# Quest."
    // Hint: use a $-prefixed string with {name} in braces.
    public static string Greet(string name)
    {
        return $"Hello, {name}! Welcome to C# Quest.";
        // hello, babinash! welcome to c# quest.
    }

    // TODO #2
    // Input from the keyboard ALWAYS arrives as a string.
    // Convert the text into a whole number and double it.
    //   "21" -> 42      "0" -> 0
    // Hint: int.Parse(numberText) turns the text "21" into the int 21.
    public static int DoubleIt(string numberText)
    {
        return 0; // change me
    }

    // TODO #3
    // Read ONE line the user typed, then greet them.
    // Replace the line below so `typed` holds what Console.ReadLine()
    // returns, then it is passed to Greet(...) above.
    // (Program.cs prints the "Your name:" prompt before calling this.)
    public static string ReadAndGreet()
    {
        string? typed = null; // change me to: Console.ReadLine();
        return Greet(typed ?? "");
    }
}
