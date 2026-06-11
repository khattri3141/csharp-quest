namespace Level04;

// =======================================================
// Level 4 — If / Else
//
// Make decisions: pick a branch based on a condition.
// =======================================================
public static class Decisions
{
    // TODO #1
    // Turn a 0-100 test score into a letter grade:
    //   90 or above -> "A"
    //   80 to 89    -> "B"
    //   70 to 79    -> "C"
    //   60 to 69    -> "D"
    //   below 60    -> "F"
    // Use an if / else if / else chain. Order matters:
    // check the highest threshold first.
    public static string Grade(int score)
    {
        return ""; // change me
    }

    // TODO #2
    // Return true if the year is a leap year, otherwise false.
    // Rule: a year is a leap year if it is divisible by 4,
    // EXCEPT century years (divisible by 100), which must ALSO
    // be divisible by 400 to count.
    //   2000 -> true    1900 -> false    2024 -> true    2023 -> false
    // Hint: the % operator gives the remainder. (year % 4 == 0)
    public static bool IsLeapYear(int year)
    {
        return false; // change me
    }
}
