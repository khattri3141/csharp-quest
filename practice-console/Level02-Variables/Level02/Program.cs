// =======================================================
// Level 2 — Variables & Types
//
// You do NOT need to change this file.
// All your work happens in Variables.cs.
//
// To run: type   dotnet run   in this folder.
// =======================================================

using Level02;

Console.WriteLine($"My name: {Variables.GetMyName()}");
Console.WriteLine($"My age:  {Variables.GetMyAge()}");
Console.WriteLine($"Coffee?  {Variables.LikesCoffee()}");
Console.WriteLine($"Price:   {Variables.GetPrice()}");
Console.WriteLine();
Console.WriteLine(Variables.BuildGreeting(Variables.GetMyName(), Variables.GetMyAge()));
