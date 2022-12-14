public class RandomizedSet {

    private Dictionary<int, int> _set;
    private IList<int> _list;
    private Random _rand;
    public RandomizedSet()
    {
        _set = new Dictionary<int, int>();
        _list = new List<int>();
        _rand = new Random();
    }

    public bool Insert(int val)
    {
        if (_set.TryAdd(val, _list.Count)) {
            _list.Add(val);
            return true;
        }
        return false;
    }

    public bool Remove(int val)
    {
        if (_set.TryGetValue(val, out int id))
        {
            _set[_list[^1]] = id;
            _set.Remove(val);
            _list[id] = _list[^1];
            _list.RemoveAt(_list.Count - 1);
            return true;
        }
        return false;
    }

    public int GetRandom()
    {
        var rnd = _rand.Next(_list.Count);
        return _list[rnd];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */