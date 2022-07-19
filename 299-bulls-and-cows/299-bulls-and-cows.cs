public class Solution {
    public string GetHint(string secret, string guess) {
        if (secret.Length == 0 || guess.Length == 0 || secret.Length != guess.Length)
            return string.Empty;
        var map = new Dictionary<char, int>();
        var bulls = 0;
        var cows = 0;
        for (var i = 0; i < secret.Length; i++) {
            if (!map.ContainsKey(secret[i]))
                map.Add(secret[i], 1);
            else
                map[secret[i]]++;
            if (secret[i] == guess[i])
            {
                bulls++;
                map[secret[i]]--;
            }
        }

        for (var i = 0; i < guess.Length; i++) {
            if (secret[i] != guess[i] && map.ContainsKey(guess[i]) && map[guess[i]] > 0)
            {
                cows++;
                map[guess[i]]--;
            }
        }
        return $"{bulls}A{cows}B";
    }
}