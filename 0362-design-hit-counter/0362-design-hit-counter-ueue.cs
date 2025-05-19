public class HitCounter {
    private Queue<int> _hits;
    public HitCounter() {
        _hits = new Queue<int>();        
    }
    
    public void Hit(int timestamp) {
        _hits.Enqueue(timestamp);
    }
    
    public int GetHits(int timestamp) {
        var tStart = timestamp - 300;
        while(_hits.Count > 0 && _hits.Peek() <= tStart)
            _hits.Dequeue();
        return _hits.Count;
    }
}

/**
 * Your HitCounter object will be instantiated and called as such:
 * HitCounter obj = new HitCounter();
 * obj.Hit(timestamp);
 * int param_2 = obj.GetHits(timestamp);
 */