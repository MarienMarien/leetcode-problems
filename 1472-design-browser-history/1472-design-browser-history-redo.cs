public class BrowserHistory {

    private IList<string> _history;
    private int _currentPageId;
    public BrowserHistory(string homepage)
    {
        _history = new List<string>() { homepage };
    }

    public void Visit(string url)
    {
        var newId = _currentPageId + 1;
        if (newId >= _history.Count)
        {
            _history.Add(url);
        }
        else {
            while (_history.Count - 1 > newId) 
            {
                _history.RemoveAt(_history.Count - 1);
            }
            _history[newId] = url;
        }
        _currentPageId = newId;
    }

    public string Back(int steps)
    {
        var newId = Math.Max(0, _currentPageId - steps);
        _currentPageId = newId;
        return _history[_currentPageId];
    }

    public string Forward(int steps)
    {
        var newId = Math.Min(_history.Count - 1, _currentPageId + steps);
        _currentPageId = newId;
        return _history[_currentPageId];
    }
}

/**
 * Your BrowserHistory object will be instantiated and called as such:
 * BrowserHistory obj = new BrowserHistory(homepage);
 * obj.Visit(url);
 * string param_2 = obj.Back(steps);
 * string param_3 = obj.Forward(steps);
 */