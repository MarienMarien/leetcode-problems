public class Solution {
    public bool CanBeValid(string s, string locked) {
        if (s.Length % 2 == 1)
            return false;

        const char ZERO = '0';
        const char OPEN = '(';
        var unlockedCount = new Stack<int>();
        var openLockedBraces = new Stack<int>();
        for (var i = 0; i < s.Length; i++)
        {
            if (locked[i] == ZERO)
            {
                unlockedCount.Push(i);
                continue;
            }

            if (s[i] == OPEN)
            {
                openLockedBraces.Push(i);
                continue;
            }

            if (openLockedBraces.Count > 0)
                openLockedBraces.Pop();
            else if (unlockedCount.Count > 0)
                unlockedCount.Pop();
            else
                return false;
        }

        while (unlockedCount.Count > 0 && openLockedBraces.Count > 0
            && unlockedCount.Peek() > openLockedBraces.Peek())
        {
            unlockedCount.Pop();
            openLockedBraces.Pop();
        }
        return openLockedBraces.Count == 0 && unlockedCount.Count % 2 == 0;
    }
}