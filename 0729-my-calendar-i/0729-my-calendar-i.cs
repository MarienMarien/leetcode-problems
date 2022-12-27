public class MyCalendar {

    private IDictionary<int, int> _calendar;
    public MyCalendar()
    {
        _calendar = new SortedDictionary<int, int>();
    }

    public bool Book(int start, int end)
    {
        if (_calendar.Count == 0) { 
            _calendar.Add(start, end);
            return true;
        }
        foreach (var b in _calendar) {
            if ((b.Key <= start && b.Value > start) || (start <= b.Key && end > b.Key))
                return false;
        }
        _calendar.Add(start, end);
        return true;
    }
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */