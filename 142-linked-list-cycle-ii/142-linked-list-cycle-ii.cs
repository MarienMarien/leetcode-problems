/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public ListNode DetectCycle(ListNode head) {
        var nodeSet = new HashSet<ListNode>();
            while (head != null) {
                if (nodeSet.Contains(head)) {
                    return head;
                }
                nodeSet.Add(head);
                head = (ListNode)head.next;
            }
            return null;
    }
}