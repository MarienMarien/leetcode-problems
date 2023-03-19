public class WordDictionary {
   public class TrieNode
    {
        public TrieNode[] Children;
        public bool IsEnd;
        public TrieNode()
        {
            Children = new TrieNode[26];
        }
    }

    public TrieNode root;

    public WordDictionary()
    {
        root = new TrieNode();
    }

    public void AddWord(string word)
    {
        var curr = root;
        foreach (char c in word)
        {
            if (curr.Children[c - 'a'] == null)
                curr.Children[c - 'a'] = new TrieNode();

            curr = curr.Children[c - 'a'];
        }

        curr.IsEnd = true;
    }

    public bool Search(string word)
    {
        return Search(word, 0, root);
    }

    public bool Search(string word, int id, TrieNode node)
    {
        if (node == null)
            return false;

        if (id == word.Length)
            return node.IsEnd;

        if (word[id] == '.')
        {
            for (int i = 0; i < node.Children.Length; i++)
            {
                TrieNode curr = node.Children[i];

                if (Search(word, id + 1, curr))
                    return true;
            }
        }
        else
        {
            if (Search(word, id + 1, node.Children[word[id] - 'a']))
                return true;
        }

        return false;
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */