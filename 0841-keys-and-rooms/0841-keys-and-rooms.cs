public class Solution {
    public bool CanVisitAllRooms(IList<IList<int>> rooms) {
        var visited = new HashSet<int>();
        var q = new Queue<int>();
        q.Enqueue(0);// start from open 0
        while (q.Count > 0)
        {
            var roomNo = q.Dequeue();
            if (!visited.Contains(roomNo))
            {
                visited.Add(roomNo);
                foreach (var k in rooms[roomNo])
                    q.Enqueue(k);
            }
        }

        return visited.Count == rooms.Count;
    }
}