public class Codec {

    private const string DELIMITER = "/:";
    // Encodes a list of strings to a single string.
    public string encode(IList<string> strs)
    {
        var sb = new StringBuilder();
        foreach (var s in strs) {
            sb.Append(s.Length).Append(DELIMITER).Append(s);
        }

        return sb.ToString();
    }

    // Decodes a single string to a list of strings.
    public IList<string> decode(string s)
    {
        const char delimiterStart = '/';
        var res = new List<string>();
        var i = 0;
        var chunkStartPos = 0;
        while (i < s.Length) {
            if (s[i] == delimiterStart && s[i..(i + 2)] == DELIMITER) {
                if (!Int32.TryParse(s[chunkStartPos..i], out int strLen))
                    throw new Exception("Wrong index calculations");
                i += 2;
                res.Add(s[i..(i + strLen)]);
                chunkStartPos = i + strLen;
                i += strLen;
                continue;
            }
            i++;
        }

        return res;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(strs));