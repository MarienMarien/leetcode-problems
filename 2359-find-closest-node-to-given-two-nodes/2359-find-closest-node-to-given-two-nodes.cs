public class Solution {
    public int ClosestMeetingNode(int[] edges, int node1, int node2) {
        var distancesNode1 = new int[edges.Length];
        var distancesNode2 = new int[edges.Length];
        Array.Fill(distancesNode1, Int32.MaxValue);
        Array.Fill(distancesNode2, Int32.MaxValue);
        distancesNode1[node1] = 0;
        distancesNode2[node2] = 0;
        FindAllDistances(node1, edges, distancesNode1);
        FindAllDistances(node2, edges, distancesNode2);

        var ans = -1;
        var minDist = Int32.MaxValue;
        for (var node = 0; node < edges.Length; node++) {
            if (minDist > Math.Max(distancesNode1[node], distancesNode2[node])) {
                ans = node;
                minDist = Math.Max(distancesNode1[node], distancesNode2[node]);
            }
        }
        return ans;
    }

    private void FindAllDistances(int node, int[] edges, int[] dist)
    {
        var next = edges[node];
        if (next != -1 && dist[next] > dist[node] + 1) {
            dist[next] = dist[node] + 1;
            FindAllDistances(next, edges, dist);
        }
    }
}