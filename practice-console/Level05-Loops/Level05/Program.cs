// =======================================================
// Level 5 — Loops
//
// You do NOT need to change this file.
// All your work happens in Repetition.cs and Problems.cs.
//
// To run: type   dotnet run   in this folder.
// =======================================================

using Level05;

Console.WriteLine($"Sum 1..10 = {Repetition.SumToN(10)}");
Console.WriteLine("Countdown: " + string.Join(", ", Repetition.Countdown(3)));
Console.WriteLine("FizzBuzz 1..15:");
Console.WriteLine(string.Join(" ", Problems.FizzBuzz(15)));
