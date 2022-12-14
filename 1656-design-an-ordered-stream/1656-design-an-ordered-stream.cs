public class OrderedStream {
    private string[] _stream;
    private int _len;
    private int _pos;
    public OrderedStream(int n)
    {
        _stream = new string[n];
        _len = n;
        _pos = 0;
    }
    public IList<string> Insert(int idKey, string value)
    {
        _stream[idKey - 1] = value;
        
        var list = new List<string>();
        while (_pos < _len && !string.IsNullOrEmpty(_stream[_pos]))
            list.Add(_stream[_pos++]);
        return list;
    }
}

/**
 * Your OrderedStream object will be instantiated and called as such:
 * OrderedStream obj = new OrderedStream(n);
 * IList<string> param_1 = obj.Insert(idKey,value);
 */