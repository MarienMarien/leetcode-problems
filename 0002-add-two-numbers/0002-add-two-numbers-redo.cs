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
        var curr1 = l1;
        var curr2 = l2;
        var sum = new ListNode(0);
        var currSum = sum;
        var newVal = 0;
        while(curr1 != null || curr2 != null)
        {
            if(curr1 != null)
            {
                newVal += curr1.val;
                curr1 = curr1.next;
            }
            if(curr2 != null)
            {
                newVal += curr2.val;
                curr2 = curr2.next;
            }

            currSum.next = new ListNode(newVal % 10);
            currSum = currSum.next;
            newVal /= 10;
        }

        if(newVal != 0)
            currSum.next = new ListNode(newVal);

        return sum.next;
    }
}