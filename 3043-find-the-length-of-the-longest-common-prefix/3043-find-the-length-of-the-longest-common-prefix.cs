public class Solution {
    public int LongestCommonPrefix(int[] arr1, int[] arr2)
    {
        var maxCommon = 0;
        var trie = new Trie();
        foreach (var n in arr1) {
            trie.Insert(n);
        }

        foreach (var n in arr2) {
            var comm = trie.CommonLength(n);
            Console.WriteLine($"Comm for {n} is {comm}");
            maxCommon = Math.Max(maxCommon, comm);
        }

        return maxCommon;
    }

    class Trie {
        private TrieNode _root;
        public Trie()
        {
            _root = new TrieNode();
        }

        public void Insert(int n) {
            var nStr = n.ToString();
            var node = _root;
            foreach (var ch in nStr) {
                var d = Int32.Parse(ch.ToString());
                if (!node.ContainsKey(d)) {
                    node.Put(d, new TrieNode());
                }
                node = node.Get(d);
            }
        }

        public int CommonLength(int n) {
            var nStr = n.ToString();
            var node = _root;
            var len = 0;

            foreach (var ch in nStr) {
                var d = Int32.Parse(ch.ToString());
                if (!node.ContainsKey(d))
                {
                    break;
                }
                node = node.Get(d);
                len++;
            }

            return len;
        }
    }

    class TrieNode {
        private TrieNode[] _links;
        private const int _linksCount = 10;
        private bool _isEnd;

        public TrieNode()
        {
            _links = new TrieNode[_linksCount];
        }

        public bool ContainsKey(int key) {
            return _links[key] != null;
        }

        public void Put(int key, TrieNode node) {
            _links[key] = node;
        }

        public TrieNode Get(int key) {
            return _links[key];
        }
    }
}