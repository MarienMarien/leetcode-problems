public class Solution {
    public bool IsNumber(string s) {
        Predicate<char> isDot = ch => ch == '.';
        Predicate<char> isSign = ch => ch == '-' || ch == '+';
        Predicate<char> isE = ch => ch == 'e' || ch == 'E';
        var dotFound = false;
        var eFound = false;
        var hasDigitsAfterE = false;
        var hasAtLeast1Digit = false;
        for (var i = 0; i < s.Length; i++) {
            if (char.IsLetter(s[i]) && !isE(s[i]))
                return false;
            if (isDot(s[i])) {
                if (dotFound || eFound)
                    return false;
                dotFound = true;
                continue;
            }
            if (isSign(s[i])) {
                if (i > 0 && !isE(s[i - 1]))
                    return false;
                continue;
            }
            if (isE(s[i]))
            {
                if (!hasAtLeast1Digit || eFound)
                    return false;
                eFound = true;
                continue;
            }
            if (eFound)
                hasDigitsAfterE = true;
            else
                hasAtLeast1Digit = true;
        }
        return hasAtLeast1Digit && (eFound ? hasDigitsAfterE : true);
    }
}