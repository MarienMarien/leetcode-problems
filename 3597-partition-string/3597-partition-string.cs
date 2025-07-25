public class Solution {
    public IList<string> PartitionString(string s) {
        var trie = new TrieNode();
        var node = trie;
        var segments = new List<string>();
        var segment = new StringBuilder();
        foreach(var ch in s)
        {
            segment.Append(ch);
            if(node.ContainsKey(ch))
            {
                node = node.Get(ch);
                continue;
            }

            node.Put(ch, new TrieNode());
            node = trie;
            segments.Add(segment.ToString());
            segment.Clear();
        }
        return segments;
    }

    class TrieNode 
    {
        private TrieNode[] _links;
        private const int SIZE = 26;

        public TrieNode()
        {
            _links = new TrieNode[SIZE];
        }

        public bool ContainsKey(char ch)
        {
            return _links[ch - 'a'] != null;
        }

        public void Put(char ch, TrieNode node)
        {
            _links[ch - 'a'] = node;
        }

        public TrieNode Get(char ch)
        {
            return _links[ch - 'a'];
        }

    }
}