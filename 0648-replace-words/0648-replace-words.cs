public class Solution {
    public string ReplaceWords(IList<string> dictionary, string sentence)
    {
        var trie = new Trie();
        foreach (var d in dictionary) {
            trie.Insert(d);
        }

        var words = sentence.Split(' ');
        var sb = new StringBuilder();

        var lastId = words.Length - 1;

        for(var i = 0; i < words.Length; i++)
        {
            var root = trie.GetRoot(words[i]);
            if (string.IsNullOrEmpty(root))
                sb.Append(words[i]);
            else { 
                sb.Append(root);
            }

            if (i != lastId)
                sb.Append(' ');
        }

        return sb.ToString();
    }
    class Trie {
        private TrieNode _root;
        public Trie()
        {
            _root = new TrieNode();
        }

        public void Insert(string word) {
            TrieNode node = _root;
            for (var i = 0; i < word.Length; i++)
            {
                var currCh = word[i];
                if (!node.ContainsKey(currCh)) {
                    node.Put(currCh, new TrieNode());
                }

                node = node.Get(currCh);
            }
            node.SetEnd();
            node.SetWord(word);
        }

        public string GetRoot(string word) {
            var node = _root;
            for (var i = 0; i < word.Length; i++) {
                var currCh = word[i];
                if (node.ContainsKey(currCh))
                {
                    node = node.Get(currCh);
                    if (node.IsEnd())
                    {
                        return node.GetWord();
                    }
                }
                else {
                    break;
                }
            }

            return null;
        }
    }

    class TrieNode {
        private TrieNode[] _links;
        private bool _isEnd;
        private const int _linksCount = 26;
        private string _wholeWord;

        public TrieNode()
        {
            _links = new TrieNode[_linksCount];
        }

        public bool ContainsKey(char ch) {
            return _links[ch - 'a'] != null;
        }

        public void Put(char ch, TrieNode node) {
            _links[ch - 'a'] = node;
        }

        public TrieNode Get(char ch)
        {
            return _links[ch - 'a'];
        }

        public bool IsEnd() {
            return _isEnd;
        }

        public void SetEnd() {
            _isEnd = true;
        }

        public void SetWord(string word) {
            _wholeWord = word;
        }

        public string GetWord() {
            return _wholeWord;
        }
    }
}