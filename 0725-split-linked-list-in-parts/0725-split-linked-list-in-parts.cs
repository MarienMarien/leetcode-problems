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
    public ListNode[] SplitListToParts(ListNode head, int k) {
        var n = 0.0;
        var curr = head;
        while (curr != null) {
            n++;
            curr = curr.next;
        }
        var ans = new ListNode[k];
        if (n == 0)
            return ans;
        var nodesPerPart = n < k ? 0 : Math.Ceiling(n / k);
        curr = head;
        var prev = head;
        var prevHead = head;
        var ansId = 0;
        var counter = nodesPerPart;
        var totalCount = n - nodesPerPart;
        while (curr != null) {
            curr = curr.next;
            counter--;
            if (counter <= 0)
            {
                ans[ansId] = prevHead;
                prev.next = null;
                prev = curr;
                prevHead = curr;
                ansId++;
                counter = Math.Ceiling(totalCount / (k - ansId));
                totalCount -= counter;
            }
            else
            {
                prev = prev.next;
            }
            
        }
        return ans;
    }
}