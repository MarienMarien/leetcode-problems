public class Logger {

    private Dictionary<string, int> _messagesCache;
    private const int _messageTimeout = 10;
    public Logger()
    {
        _messagesCache = new Dictionary<string, int>();// msg, next available time
    }

    public bool ShouldPrintMessage(int timestamp, string message)
    {
        if (_messagesCache.ContainsKey(message))
        {
            if (timestamp < _messagesCache[message])
                return false;
            _messagesCache[message] = timestamp + _messageTimeout;
        }
        else {
            _messagesCache.Add(message, timestamp + _messageTimeout);
        }
        return true;
    }
}

/**
 * Your Logger object will be instantiated and called as such:
 * Logger obj = new Logger();
 * bool param_1 = obj.ShouldPrintMessage(timestamp,message);
 */