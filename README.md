# C# Quest

Learn C# .NET like a game — designed for **a teacher and a beginner working together**.

- **learn-web/** — Open `learn-web/index.html` in a browser. Theory, analogies, code, quizzes.
- **practice-console/** — One folder per level. A console app to edit + NUnit tests that prove it works.

## How a session works

1. Teacher opens `learn-web/index.html` and turns on **Teacher: ON** in the top bar — extra notes appear inside each lesson (lesson plan, talking points, common mistakes to watch for, questions to ask).
2. Click **Level 1**. Read the lesson together. Have the beginner take the short quiz at the bottom — all answers must be correct.
3. Open `practice-console/Level01-HelloWorld/` in VS Code.
4. Walk through the `TODO` comments together.
5. Run `dotnet test` from inside the level folder. Green tests = challenge passed.
6. Back in the browser, tick the **"I ran `dotnet test` and tests passed"** honor checkbox.
7. Click **Mark Level Complete**. Confetti. Level 2 unlocks.

Beginner can use this solo too — Teacher mode just hides extras. Honor checkbox keeps everyone honest about doing the code part.

## Requirements

- .NET 8 SDK ([download](https://dotnet.microsoft.com/download))
- VS Code with C# Dev Kit extension
- A modern browser (Chrome, Edge, Firefox)

## Levels (prototype: 1 & 2 done)

1. Hello World
2. Variables & Types
3. Console Input/Output *(coming soon)*
4. If/Else
5. Loops
6. Methods
7. Arrays & List
8. Classes
9. Properties & Encapsulation
10. Inheritance
11. Exception Handling
12. Mini-Project: Number Guessing Game
