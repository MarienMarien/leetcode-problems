/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public int[] NodesBetweenCriticalPoints(ListNode head) {
        var criticalPointsIds = new List<int>();
        var prev = head.val;
        var curr = head?.next;
        var count = 2;
        while (curr != null && curr.next != null)
        {
            if ((prev < curr.val && curr.val > curr.next.val) || (prev > curr.val && curr.val < curr.next.val))
            {
                criticalPointsIds.Add(count);
            }

            prev = curr.val;
            count++;
            curr = curr.next;
        }

        var ans = new int[2] { -1, -1 };
        if (criticalPointsIds.Count > 1)
        {
            ans[0] = int.MaxValue;
            for (var i = 1; i < criticalPointsIds.Count; i++) {
                ans[0] = Math.Min(ans[0], criticalPointsIds[i] - criticalPointsIds[i - 1]);
            }
            ans[1] = criticalPointsIds[^1] - criticalPointsIds[0];
        }

        return ans;
    }
}