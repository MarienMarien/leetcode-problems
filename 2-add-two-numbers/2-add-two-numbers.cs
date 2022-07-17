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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
       var res = new ListNode(0);
            var currNode = res;
            var koef = 0;
            while (l1 != null || l2 != null) {
                var l1Val = l1 == null ? 0 : l1.val;
                var l2Val = l2 == null ? 0 : l2.val;
                var newNode = new ListNode((l1Val + l2Val + koef) % 10);
                currNode.next = newNode;
                currNode = currNode.next;
                koef = (l1Val + l2Val + koef) / 10;
                if(l1 != null)
                    l1 = l1.next;
                if (l2 != null)
                    l2 = l2.next;
            }
            if(koef != 0)
                currNode.next = new ListNode(koef % 10);

            return res.next;
    }
}