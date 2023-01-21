public class Solution {
    private IList<string> _addresses;
    public IList<string> RestoreIpAddresses(string s)
    {
        _addresses = new List<string>();
        if (s.Length < 4 || s.Length > 12)
            return _addresses;
        Restore(s, 0, new List<int>(), 4);
        return _addresses;
    }

    private void Restore(string s, int start, IList<int> parts , int currPartNo)
    {
        if (start >= s.Length)
        {
            if (parts.Count == 4)
                _addresses.Add(string.Join('.', parts));
            return;
        }
        else if (parts.Count == 4) {
            return;
        }
        currPartNo--;
        if (s[start] == '0')
        {
            parts.Add(0);
            Restore(s, start + 1, parts, currPartNo);
            parts.RemoveAt(parts.Count - 1);
        }
        else
        {
            for (var i = 1; i <= Math.Min(3, s.Length - start); i++)
            {
                var currNum = Int32.Parse(s.Substring(start, i));
                if (currNum > 255)
                    break;
                // if ((currPartNo > 0 && s.Length - (start + i - 1) > currPartNo * 3) || s.Length - (start + i - 1) < currPartNo)
                //     continue;
                parts.Add(currNum);
                Restore(s, start + i, parts, currPartNo);
                parts.RemoveAt(parts.Count - 1);
            }
        }
    }
}