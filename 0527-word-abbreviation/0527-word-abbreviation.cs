public class Solution {
    public record WordWithId(string word, int id);
    public IList<string> WordsAbbreviation(IList<string> words) {
        var wGroups = new Dictionary<string, IList<WordWithId>>();
        for(var i = 0; i < words.Count; i++)
        {
            var word = words[i];
            var abbr = $"{word[0]}{word.Length - 2}{word[^1]}";
            if(!wGroups.TryAdd(abbr, new List<WordWithId> { new WordWithId(word, i) }))
            {
                wGroups[abbr].Add(new WordWithId(word, i));
            }
        }

        var abbreviations = new string[words.Count];
        foreach(var group in wGroups)
        {
            var trie = new Trie();
            foreach(var w in group.Value)
            {
                trie.InsertWord(w.word);
            }

            foreach(var w in group.Value)
            {
                abbreviations[w.id] = trie.GetAbbreviation(w.word);
            }
        }
        return abbreviations.ToList();
    }

    class Trie
    {
        private TrieNode _root;
        public Trie()
        {
            _root = new TrieNode();
        }

        public void InsertWord(string word)
        {
            var node = _root;
            foreach(var ch in word)
            {
                if(!node.ContainsKey(ch))
                    node.Put(ch, new TrieNode());
                node = node.Get(ch);
                node.IncCount();
            }
        }

        public string GetAbbreviation(string word)
        {
            if(word.Length < 4)
                return word;
            var pref = GetUniquePrefix(word);
            var lenDiff = word.Length - pref.Length;
            if(lenDiff < 3)
                return word;
            return $"{pref}{lenDiff - 1}{word[^1]}";
        }

        private string GetUniquePrefix(string word)
        {
            var node = _root;
            var sb = new StringBuilder();
            foreach(var ch in word)
            {
                sb.Append(ch);
                node = node.Get(ch);
                if(node.GetCount() == 1)
                    break;
            }
            return sb.ToString();
        }
    }

    class TrieNode
    {
        private TrieNode[] _links;
        private int _count;
        private const int SIZE = 26;

        public TrieNode()
        {
            _links = new TrieNode[SIZE];
        }

        public bool ContainsKey(char key)
        {
            return _links[key - 'a'] != null;
        }

        public TrieNode Get(char key)
        {
            return _links[key - 'a'];
        }

        public void Put(char key, TrieNode node)
        {
            _links[key - 'a'] = node;
        }

        public void IncCount()
        {
            _count += 1;
        }

        public int GetCount()
        {
            return _count;
        }
    }
}