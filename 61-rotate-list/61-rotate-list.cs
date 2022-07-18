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
    public ListNode RotateRight(ListNode head, int k) {
        if (head == null)
            return null;
        if (k == 0)
            return head;
        var root = head;
        var newHead = head;
        ListNode listEnd = head;
        ListNode shiftEnd = head;
        var windowSize = 1;
        var curr = head.next;
        while (curr != null) {
            shiftEnd = curr;
            if (windowSize == k)
            {
                listEnd = newHead;
                newHead = newHead.next;
            }
            else
            {
                windowSize++;
            }
            curr = curr.next;
        }
        // k > list.len
        if (windowSize > 1 && windowSize < k) {
            var newK = k % windowSize;
            if (newK > 0)
            {
                while (windowSize != newK)
                {
                    listEnd = newHead;
                    newHead = newHead.next;
                    windowSize--;
                }
            }
        }

        // rearrange
        if (listEnd != newHead)
        {
            shiftEnd.next = root;
            listEnd.next = null;
        }

        return newHead;
    }
}