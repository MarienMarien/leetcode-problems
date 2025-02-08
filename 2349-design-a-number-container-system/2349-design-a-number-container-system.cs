public class NumberContainers {
    private IDictionary<int, int> _indexNumber;
    private IDictionary<int, ISet<int>> _numberIndexes;
    public NumberContainers() {
        _indexNumber = new Dictionary<int, int>();
        _numberIndexes = new Dictionary<int, ISet<int>>();
    }
    
    public void Change(int index, int number) {
        if(_indexNumber.ContainsKey(index))
        {
            var prevIndexNumber = _indexNumber[index];
            _numberIndexes[prevIndexNumber].Remove(index);
            if(_numberIndexes[prevIndexNumber].Count == 0)
                _numberIndexes.Remove(prevIndexNumber);
        }

        _indexNumber[index] = number;
        if(!_numberIndexes.TryAdd(number, new SortedSet<int>{index}))
            _numberIndexes[number].Add(index);
    }
    
    public int Find(int number) {
        return  _numberIndexes.ContainsKey(number) ? _numberIndexes[number].First() : -1;
    }
}

/**
 * Your NumberContainers object will be instantiated and called as such:
 * NumberContainers obj = new NumberContainers();
 * obj.Change(index,number);
 * int param_2 = obj.Find(number);
 */