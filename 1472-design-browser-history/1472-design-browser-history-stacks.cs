public class BrowserHistory {
    private Stack<string> _back;
    private Stack<string> _forward;
    private string _current;

    public BrowserHistory(string homepage)
    {
        _back = new Stack<string>();
        _forward = new Stack<string>();
        _current = homepage;
    }

    public void Visit(string url)
    {
        _forward = new Stack<string>();
        _back.Push(_current);
        _current = url;
    }

    public string Back(int steps)
    {
        while (steps > 0 && _back.Count > 0)
        {
            _forward.Push(_current);
            _current = _back.Pop();
            steps--;
        }
        return _current;
    }

    public string Forward(int steps)
    {
        while(steps > 0 && _forward.Count > 0)
        {
            _back.Push(_current);
            _current = _forward.Pop();
            steps--;
        }
        return _current;
    }
}

/**
 * Your BrowserHistory object will be instantiated and called as such:
 * BrowserHistory obj = new BrowserHistory(homepage);
 * obj.Visit(url);
 * string param_2 = obj.Back(steps);
 * string param_3 = obj.Forward(steps);
 */