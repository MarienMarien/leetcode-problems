public class Solution {
    private IList<IList<string>> _partitions;
    public IList<IList<string>> Partition(string s)
    {
        _partitions = new List<IList<string>>();
        FindPartitions(s, 0, new List<string>());
        return _partitions;
    }

    private void FindPartitions(string s, int start, List<string> list)
    {
        if (start >= s.Length)
        {
            _partitions.Add(new List<string>(list));
            return;
        }
        for (var id = start; id < s.Length; id++) {
            if (IsPalindrome(start, id, s)) {
                list.Add(s[start..(id + 1)]);
                FindPartitions(s, id + 1, list);
                list.RemoveAt(list.Count - 1);
            }
        }
    }

    private bool IsPalindrome(int start, int end, string s)
    {
        while (start < end) {
            if (s[start++] != s[end--])
                return false;
        }
        return true;
    }
}