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
        var slow = head;
        var fast = head;
        while(fast != null && fast.next != null){
            slow = slow.next;
            fast = fast.next?.next;
            if(fast == slow){
                var slow2 = head;
                while(slow != slow2){
                    slow = slow.next;
                    slow2 = slow2.next;
                }
                return slow;
            }
        }
        return null;
    }
}