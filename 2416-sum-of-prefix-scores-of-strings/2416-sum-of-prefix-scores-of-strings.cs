public class Solution {
    public int[] SumPrefixScores(string[] words)
    {
        var trie = new Trie();
        foreach (var w in words)
        {
            trie.Insert(w);
        }

        var ans = new int[words.Length];
        for (var i = 0; i < ans.Length; i++)
        {
            ans[i] = trie.GetWordScore(words[i]);
        }

        return ans;
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
            var curr = _root;
            foreach (var ch in word)
            {
                if (!curr.ContainsKey(ch))
                {
                    curr.Put(ch, new TrieNode());
                }
                curr = curr.Get(ch);
                curr.AddScore();
            }
        }

        public int GetWordScore(string word)
        {
            var curr = _root;
            var wordScore = 0;
            foreach (var ch in word)
            {
                curr = curr.Get(ch);
                wordScore += curr.GetScore();
            }

            return wordScore;
        }
    }

    public class TrieNode
    {
        private int _score;
        private TrieNode[] _links;
        private const int _size = 26;

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

        public int GetScore()
        {
            return _score;
        }

        public void AddScore()
        {
            _score++;
        }
    }
}