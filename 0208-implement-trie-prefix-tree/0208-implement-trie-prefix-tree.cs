public class Trie {

    private TrieNode _root;
    public Trie() {
        _root = new TrieNode();
    }
    
    public void Insert(string word) {
        var node = _root;
        foreach(var ch in word){
            if(!node.ContainsKey(ch)){
                node.Put(ch, new TrieNode());
            }
            node = node.Get(ch);
        }
        node.SetEnd();
    }

    private TrieNode SearchPrefix(string word){
        var node = _root;
        foreach(var ch in word){
            if(node.ContainsKey(ch)){
                node = node.Get(ch);
            } else {
                return null;
            }
        }
        return node;
    }
    
    public bool Search(string word) {
        var node = SearchPrefix(word);
        return node != null && node.IsEnd();
    }
    
    public bool StartsWith(string prefix) {
        var node = SearchPrefix(prefix);
        return node != null;
    }

    internal class TrieNode{
        private TrieNode[] _links;
        private bool _isEnd;
        private const int _len = 26;

        public TrieNode(){
            _links = new TrieNode[_len];
        }

        public bool ContainsKey(char ch){
            return _links[ch - 'a'] != null;
        }

        public TrieNode Get(char ch){
            return _links[ch - 'a'];
        }

        public void Put(char ch, TrieNode node){
            _links[ch - 'a'] = node;
        }

        public void SetEnd(){
            _isEnd = true;
        }

        public bool IsEnd(){
            return _isEnd;
        }

    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */