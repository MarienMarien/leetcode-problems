public class Solution {
    public IList<string> RemoveSubfolders(string[] folder)
    {
        var trie = new Trie();
        foreach (var f in folder)
        {
            trie.Insert(f);
        }
        var res = new List<string>();
        foreach (var f in folder)
        {
            if (!trie.IsSubFolder(f))
                res.Add(f);
        }

        return res;
    }

    public class Trie
    {
        TrieNode _root;

        public Trie()
        {
            _root = new TrieNode();
        }

        public void Insert(string s)
        {
            var curr = _root;
            var folders = s.Split('/');
            for (var i = 1; i < folders.Length; i++)
            {
                if (folders[i] == "")
                    continue;
                if (!curr.ContainsKey(folders[i]))
                {
                    curr.Put(folders[i], new TrieNode());
                }
                curr = curr.Get(folders[i]);
            }
            curr.SetEnd();
        }

        public bool IsSubFolder(string path)
        {
            var folders = path.Split('/');
            var curr = _root;
            for (var i = 1; i < folders.Length; i++)
            {
                curr = curr.Get(folders[i]);
                if (i < folders.Length - 1 && curr.IsEnd())
                    return true;
            }

            return false;
        }
    }

    public class TrieNode
    {
        IDictionary<string, TrieNode> _links;
        bool _isEnd;

        public TrieNode()
        {
            _links = new Dictionary<string, TrieNode>();
        }

        public bool ContainsKey(string key)
        {
            return _links.ContainsKey(key);
        }

        public void Put(string s, TrieNode node)
        {
            _links.Add(s, node);
        }

        public TrieNode Get(string s)
        {
            return _links[s];
        }

        public void SetEnd()
        {
            _isEnd = true;
        }

        public bool IsEnd()
        {
            return _isEnd;
        }
    }
}