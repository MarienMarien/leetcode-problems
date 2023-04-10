public class Solution {
    private IList<string> _result;
    public IList<string> FindWords(char[][] board, string[] words)
    {
        _result = new List<string>();
        var root = BuildTrie(words);
        
        for (var row = 0; row < board.Length; row++) {
            for (var col = 0; col < board[0].Length; col++) {
                if (root.ContainsKey(board[row][col]))
                    SearchWords(board, row, col, root);
            }
        }
        return _result;
    }

    private void SearchWords(char[][] board, int row, int col, TrieNode node)
    {
        var currCh = board[row][col];
        var currNode = node.Get(currCh);
        if (currNode.GetWord() != null) {
            _result.Add(currNode.GetWord());
            currNode.SetWord(null);
        }
        var rowStep = new int[] { -1, 0, 1, 0 };
        var colStep = new int[] { 0, 1, 0, -1 };
        board[row][col] = '-';
        for (var i = 0; i < rowStep.Length; i++) {
            var nextRow = row + rowStep[i];
            var nextCol = col + colStep[i];
            if (nextRow < 0 || nextRow >= board.Length || nextCol < 0 || nextCol >= board[0].Length)
                continue;
            if (currNode.ContainsKey(board[nextRow][nextCol]))
                SearchWords(board, nextRow, nextCol, currNode);
        }

        board[row][col] = currCh;
    }

    public TrieNode BuildTrie(string[] words)
    {
        var root = new TrieNode();
        foreach (var w in words)
        {
            var node = root;
            foreach (var ch in w)
            {
                if (!node.ContainsKey(ch))
                {
                    node.Put(ch, new TrieNode());
                }
                node = node.Get(ch);
            }
            node.SetWord(w);
        }
        return root;
    }

    public class TrieNode
    {
        private IDictionary<char, TrieNode> _children;
        private string _word;
        public TrieNode()
        {
            _children = new Dictionary<char, TrieNode>();
        }

        public bool ContainsKey(char ch)
        {
            return _children.ContainsKey(ch);
        }

        public void Put(char ch, TrieNode node)
        {
            _children.Add(ch, node);
        }

        public TrieNode Get(char ch)
        {
            return _children[ch];
        }

        public void SetWord(string word)
        {
            _word = word;
        }

        public string GetWord()
        {
            return _word;
        }

        public bool IsLeaf() { 
            return _children.Count == 0;
        }

        public void Remove(char ch) { 
            _children.Remove(ch);
        }
    }
}