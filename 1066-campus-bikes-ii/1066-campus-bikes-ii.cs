public class Solution {
    private int _smallestDistance;
    private bool[] _visited;

    public int AssignBikes(int[][] workers, int[][] bikes) {
        _smallestDistance = Int32.MaxValue;
        _visited = new bool[bikes.Length];
        FindSmallest(workers, bikes, 0, 0);
        return _smallestDistance;
    }

    private void FindSmallest(int[][] workers, int[][] bikes, int workerId, int currDistanceSum)
        {
            if (workerId >= workers.Length)
            {
                _smallestDistance = Math.Min(_smallestDistance, currDistanceSum);
                return;
            }
            if (currDistanceSum >= _smallestDistance)
                return;
            for (var i = 0; i < bikes.Length; i++) {
                if (_visited[i])
                    continue;
                _visited[i] = true;
                var currDistance = Math.Abs(workers[workerId][0] - bikes[i][0]) + Math.Abs(workers[workerId][1] - bikes[i][1]);
                FindSmallest(workers, bikes, workerId+1, currDistanceSum + currDistance);
                _visited[i] = false;
            }
        }
}