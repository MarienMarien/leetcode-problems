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
    public bool HasCycle(ListNode head) {
        var turtle = head;
        var hare = head;
        while(turtle != null && hare != null)
        {
            turtle = turtle.next;
            hare = hare.next?.next;
            if(turtle == hare && turtle != null)
                return true;
        }

        return false;
    }
}