public class RangeModule {
    private SortedSet<Range> _ranges;

    public RangeModule()
    {
        _ranges = new SortedSet<Range>(new RangeComparer());
    }

    public void AddRange(int left, int right)
    {
        var overlaps = _ranges.GetViewBetween(new Range(left - 1, left), new Range(right - 1, right)).ToList();
        if (overlaps.Count == 0)
        {
            _ranges.Add(new Range(left, right - 1));
            return;
        }
        var newLeft = Math.Min(left, overlaps[0].Start);
        var newRight = Math.Max(right - 1, overlaps[^1].End);
        foreach (var r in overlaps)
        {
            _ranges.Remove(r);
        }
        _ranges.Add(new Range(newLeft, newRight));
    }

    public bool QueryRange(int left, int right)
    {
        var rightBound = right - 1;
        var overlap = _ranges.GetViewBetween(new Range(left, left), new Range(rightBound, rightBound));
        if (overlap.Count != 1)
            return false;
        var overlapRange = overlap.First();
        return overlapRange.Start <= left && rightBound <= overlapRange.End;
    }

    public void RemoveRange(int left, int right)
    {
        var overlaps = _ranges.GetViewBetween(new Range(left, left), new Range(right - 1, right - 1)).ToList();
        if (overlaps.Count == 0)
            return;
            
        foreach (var r in overlaps)
        {
            _ranges.Remove(r);
        }

        if (overlaps[0].Start < left)
        {
            _ranges.Add(new Range(overlaps[0].Start, left - 1));
        }

        if (overlaps[^1].End > right)
        {
            _ranges.Add(new Range(right, overlaps[^1].End));
        }
    }

    class Range
    {
        public int Start;
        public int End;
        public Range(int s, int e)
        {
            Start = s;
            End = e;
        }
    }

    class RangeComparer : IComparer<Range>
    {
        public int Compare(Range x, Range y)
        {
            if (x.End < y.Start)
                return -1;
            if (y.End < x.Start)
                return 1;
            return 0;
        }
    }
}

/**
 * Your RangeModule object will be instantiated and called as such:
 * RangeModule obj = new RangeModule();
 * obj.AddRange(left,right);
 * bool param_2 = obj.QueryRange(left,right);
 * obj.RemoveRange(left,right);
 */