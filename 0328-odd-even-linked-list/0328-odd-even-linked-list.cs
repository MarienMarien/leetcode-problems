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
    public ListNode OddEvenList(ListNode head) {
        var odd = new ListNode();
        var newHead = odd;
        var even = new ListNode();
        var evenHead = even;
        var i = 1;
        while (head != null) {
            
            if (i % 2 > 0)
            {
                odd.next = head;
                odd = odd.next;
            }
            else { 
                even.next = head;
                even = even.next;
            }
            head = head.next;
            i++;
        }
        even.next = null;
        odd.next = evenHead.next;
        return newHead.next;
    }
}