public class Solution {
    public string LongestWord(string[] words)
    {
        var trie = new Trie();
        foreach (var w in words)
        {
            trie.Insert(w);
        }

        return trie.GetLongestWordWithAllPrefixes();
    }

    public class Trie 
    {
        private TrieNode _root;

        public Trie()
        {
            _root = new TrieNode();
        }

        public void Insert(string word)
        {
            var node = _root;
            foreach (var ch in word)
            {
                if (!node.ContainsKey(ch))
                {
                    node.Put(ch, new TrieNode());
                }
                node = node.Get(ch);
            }
            node.SetEnd();
        }

        public string GetLongestWordWithAllPrefixes()
        {
            return FindLongestWordWithAllPrefixes(_root, new StringBuilder(), string.Empty);
        }

        private string FindLongestWordWithAllPrefixes(TrieNode node, StringBuilder sb, string longestStr)
        {
            for (var chCode = 0; chCode < 26; chCode++)
            {
                var ch = (char)(chCode + 'a');
                if (!node.ContainsKey(ch))
                    continue;

                var nextNode = node.Get(ch);
                if (!nextNode.IsEnd())
                {
                    if (sb.Length > longestStr.Length)
                    {
                        longestStr = sb.ToString();
                    }
                    continue;
                }

                sb.Append(ch);
                var currLongest = FindLongestWordWithAllPrefixes(nextNode, sb, longestStr);
                if (currLongest.Length > longestStr.Length)
                    longestStr = currLongest;

                sb.Remove(sb.Length - 1, 1);
            }

            if (sb.Length > longestStr.Length)
            {
                longestStr = sb.ToString();
            }

            return longestStr;
        }
    }

    public class TrieNode
    {
        private TrieNode[] _links;
        private const int _size = 26;
        private bool _isEnd;
        public TrieNode()
        {
            _links = new TrieNode[_size];
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

        public bool IsEnd()
        {
            return _isEnd;
        }

        public void SetEnd()
        { 
            _isEnd = true;
        }
    }
}