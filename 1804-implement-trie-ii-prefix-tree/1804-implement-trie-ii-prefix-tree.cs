public class Trie {

    private TrieNode _root;

    public Trie()
    {
        _root= new TrieNode();
    }

    public void Insert(string word)
    {
        var curr = _root;
        foreach (var ch in word) {
            if (!curr.ContainsKey(ch))
            {
                curr.Put(ch, new TrieNode());
            }
            curr = curr.Get(ch);
            curr.AddPrefixCount();
        }
        curr.SetEnd();
    }

    public int CountWordsEqualTo(string word)
    {
        var curr = _root;
        foreach (var ch in word) {
            if (!curr.ContainsKey(ch))
                return 0;
            curr = curr.Get(ch);
        }
        return curr.WordCount();
    }

    public int CountWordsStartingWith(string prefix)
    {
        var curr = _root;
        foreach (var ch in prefix)
        {
            if (!curr.ContainsKey(ch))
                return 0;
            curr = curr.Get(ch);
        }
        return curr.PrefixCount();
    }

    public void Erase(string word)
    {
        var node = _root;
        Erase(word, 0, node);
    }

    private void Erase(string word, int i, TrieNode node)
    {
        var isWordEnd = i == word.Length;
        node.Erase(isWordEnd);
        if (!isWordEnd)
        {
            var ch = word[i];
            var nextNode = node.Get(ch);
            Erase(word, i + 1, nextNode);
            if (nextNode.PrefixCount() == 0)
                nextNode = null;
        }
    }
}

internal class TrieNode {
    private TrieNode[] _links;
    private const int N = 26;
    private bool _isEnd;
    private int _wordCount;
    private int _prefixCount;
    public TrieNode() { 
        _links = new TrieNode[N];
    }

    public bool ContainsKey(char ch) {
        return _links[ch - 'a'] != null;
    }

    public TrieNode Get(char ch) {
        return _links[ch - 'a'];
    }

    public void Put(char ch, TrieNode node) {
        _links[ch - 'a'] = node;
    }

    public void SetEnd() {
        _wordCount++;
        _isEnd = true;
    }

    public bool IsEnd() {
        return _isEnd;
    }

    public int WordCount() { 
        return _wordCount;
    }

    public int PrefixCount()
    {
        return _prefixCount;
    }

    public void AddPrefixCount() {
        _prefixCount++;
    }

    public void Erase(bool isWordEnd) {
        if (isWordEnd) {
            _wordCount--;
        }
        _prefixCount--;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * int param_2 = obj.CountWordsEqualTo(word);
 * int param_3 = obj.CountWordsStartingWith(prefix);
 * obj.Erase(word);
 */