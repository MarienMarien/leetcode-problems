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
        var l1Stack = new Stack<int>();
        var l2Stack = new Stack<int>();
        var carry = 0;
        ListNode res = null;
        while (l1 != null)
        {
            l1Stack.Push(l1.val);
            l1 = l1.next;
        }
        while (l2 != null)
        {
            l2Stack.Push(l2.val);
            l2 = l2.next;
        }
        while (l1Stack.Count > 0 || l2Stack.Count > 0) {
            var n1 = l1Stack.Count > 0 ? l1Stack.Pop() : 0;
            var n2 = l2Stack.Count > 0 ? l2Stack.Pop() : 0;
            var sum = n1 + n2 + carry;
            var newNode = new ListNode(sum % 10, res);
            res = newNode;
            carry = sum / 10;
        }
        if (carry > 0)
        {
            var newNode = new ListNode(carry, res);
            res = newNode;
        }
        return res;
    }
}