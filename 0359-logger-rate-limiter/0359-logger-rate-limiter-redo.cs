public class Logger {
    private IDictionary<string, int> _logs;
    private const int _timeout = 10;

    public Logger() {
        _logs = new Dictionary<string, int>();    
    }
    
    public bool ShouldPrintMessage(int timestamp, string message) {
        if(_logs.ContainsKey(message) && _logs[message] > timestamp)
            return false;
        _logs[message] = timestamp + _timeout;
        return true;
    }
}

/**
 * Your Logger object will be instantiated and called as such:
 * Logger obj = new Logger();
 * bool param_1 = obj.ShouldPrintMessage(timestamp,message);
 */