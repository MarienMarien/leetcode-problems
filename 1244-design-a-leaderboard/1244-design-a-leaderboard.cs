public class Leaderboard {

    private IDictionary<int, int> _board;// player, score
    private IDictionary<int, int> _leaderboard;// score, player count
    public Leaderboard()
    {
        _board = new Dictionary<int, int>();
        _leaderboard = new SortedDictionary<int, int>(Comparer<int>.Create((x, y) => { return y - x; }));
    }

    public void AddScore(int playerId, int score)
    {
        if (_board.TryAdd(playerId, score))
        {
            if (!_leaderboard.TryAdd(score, 1)) {
                _leaderboard[score]++;
            }
        }
        else {
            var prevScore = _board[playerId];
            if (_leaderboard.ContainsKey(prevScore)) { 
                _leaderboard[prevScore]--;
                if(_leaderboard[prevScore] <= 0)
                    _leaderboard.Remove(prevScore);
            }
            _board[playerId] += score;
            if (!_leaderboard.TryAdd(_board[playerId], 1))
                _leaderboard[_board[playerId]]++;
        }
    }

    public int Top(int K)
    {
        var sum = 0;
        foreach (var s in _leaderboard) {
            if (K <= 0)
                break;
            var count = K - s.Value >= 0 ? s.Value : K;
            sum += s.Key * count;
            K-= s.Value;
        }
        return sum;
    }

    public void Reset(int playerId)
    {
        // remove from leaderboard
        var playerScore = _board[playerId];
        _leaderboard[playerScore]--;
        if (_leaderboard[playerScore] <= 0)
            _leaderboard.Remove(playerScore);
        // reset value in board
        _board[playerId] = 0;
        if (!_leaderboard.TryAdd(0, 1)) {
            _leaderboard[0]++;
        }
    }
}

/**
 * Your Leaderboard object will be instantiated and called as such:
 * Leaderboard obj = new Leaderboard();
 * obj.AddScore(playerId,score);
 * int param_2 = obj.Top(K);
 * obj.Reset(playerId);
 */