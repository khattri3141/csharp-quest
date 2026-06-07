// =======================================================
// Level 3 — Console I/O
//
// You do NOT need to change this file.
// All your work happens in Interaction.cs and Problems.cs.
//
// To run: type   dotnet run   in this folder, then type
// answers when it asks. This is REAL keyboard input.
// =======================================================

using Level03;

Console.Write("Your name: ");
string name = Console.ReadLine() ?? "";
Console.WriteLine(Interaction.Greet(name));

Console.Write("Pick a whole number: ");
string numberText = Console.ReadLine() ?? "0";
Console.WriteLine($"Double that is: {Interaction.DoubleIt(numberText)}");

Console.WriteLine($"Defanged 1.1.1.1 -> {Problems.DefangIp("1.1.1.1")}");
