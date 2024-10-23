public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        var trie = new Trie();
        var shortestStr = strs[0];
        foreach (var s in strs)
        {
            if (s.Length == 0 || s[0] != strs[0][0])
                return "";
            trie.Insert(s);
            if (s.Length < shortestStr.Length)
                shortestStr = s;
        }

        var n = strs.Length;
        var longestCommon = trie.GetLongestCommonPref(shortestStr, n);

        return longestCommon;
    }
}

class Trie
{
    private TrieNode _root;

    public Trie()
    {
        _root = new TrieNode();
    }

    public void Insert(string word)
    {
        var curr = _root;
        foreach (var ch in word)
        {
            if (!curr.ContainsKey(ch))
            {
                curr.Put(ch, new TrieNode());
            }
            curr = curr.Get(ch);
            curr.IncEncounter();
        }
    }

    public string GetLongestCommonPref(string s, int pivotNum)
    {
        var curr = _root;
        var sb = new StringBuilder();
        foreach (var ch in s)
        {
            curr = curr.Get(ch);
            if (curr.GetEncounters() != pivotNum)
                break;
            sb.Append(ch);
        }

        return sb.ToString();
    }
}

class TrieNode
{
    private TrieNode[] _links;
    private int _encounters;

    public TrieNode()
    {
        _links = new TrieNode[26];
    }

    public bool ContainsKey(char key)
    {
        return _links[key - 'a'] != null;
    }

    public TrieNode Get(char key)
    {
        return _links[key - 'a'];
    }

    public void Put(char key, TrieNode node)
    {
        _links[key - 'a'] = node;
    }

    public void IncEncounter() {
        _encounters++;
    }

    public int GetEncounters() { 
        return _encounters;
    }
}