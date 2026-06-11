namespace Level04;

// =======================================================
// Practice problems — LeetCode style.
//
// Solve here, prove it with `dotnet test`, then open the
// linked problem on LeetCode and submit the same idea there.
// =======================================================
public static class Problems
{
    // Problem: Nim Game  (LeetCode #292, Easy)
    // https://leetcode.com/problems/nim-game/
    //
    // You and a friend take turns removing 1 to 3 stones from a
    // heap of `n`. Whoever removes the last stone wins, and you
    // move first. Return true if you can guarantee a win.
    //
    // The whole game collapses to ONE condition: you lose only
    // when n is a multiple of 4. So return whether n is NOT
    // divisible by 4.
    //   1 -> true   3 -> true   4 -> false   8 -> false   7 -> true
    public static bool CanWinNim(int n)
    {
        return false; // change me
    }
}
