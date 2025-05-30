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
    public ListNode DeleteNodes(ListNode head, int m, int n) {
        var curr = head;
        while(curr != null)
        {
            for(var i = 0; i < m - 1 & curr != null; i++)
            {
                curr = curr.next;
            }

            var nextNode = curr?.next;
            for(var i = 0; i < n & nextNode != null; i++)
            {
                nextNode = nextNode.next;
            }
            if(curr == null)
                continue;
            curr.next = nextNode;
            curr = curr.next;

        }
        return head;
    }
}