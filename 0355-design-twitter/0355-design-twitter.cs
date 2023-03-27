public class Twitter {
    private IDictionary<int, ISet<int>> _follow;
    private LinkedList<(int userId, int tweetId)> _newsfeed;
    private const int _feedCount = 10;
    public Twitter()
    {
        _follow = new Dictionary<int, ISet<int>>();
        _newsfeed = new LinkedList<(int, int)>();
    }

    public void PostTweet(int userId, int tweetId)
    {
        _newsfeed.AddFirst((userId, tweetId));
    }

    public IList<int> GetNewsFeed(int userId)
    {
        var userNewsfeed = new List<int>();
        var count = _feedCount;
        foreach (var item in _newsfeed) {
            if ((_follow.ContainsKey(userId) && _follow[userId].Contains(item.userId)) || userId == item.userId)
            {
                count--;
                userNewsfeed.Add(item.tweetId);
            }
            if (count == 0)
                break;
        }
        return userNewsfeed;
    }

    public void Follow(int followerId, int followeeId)
    {
        if (!_follow.TryAdd(followerId, new HashSet<int> { followeeId }))
            _follow[followerId].Add(followeeId);
    }

    public void Unfollow(int followerId, int followeeId)
    {
        if (_follow.ContainsKey(followerId) && _follow[followerId].Contains(followeeId))
            _follow[followerId].Remove(followeeId);
    }
}

/**
 * Your Twitter object will be instantiated and called as such:
 * Twitter obj = new Twitter();
 * obj.PostTweet(userId,tweetId);
 * IList<int> param_2 = obj.GetNewsFeed(userId);
 * obj.Follow(followerId,followeeId);
 * obj.Unfollow(followerId,followeeId);
 */