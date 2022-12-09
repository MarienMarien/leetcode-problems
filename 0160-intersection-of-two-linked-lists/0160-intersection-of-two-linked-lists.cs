/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        var stackA = new Stack<ListNode>();
        var stackB = new Stack<ListNode>();
        ListNode previousCommon = null;
        // check if can do this
        while (headA != null) {
            stackA.Push(headA);
            headA = headA.next;
        }
        while (headB != null)
        {
            stackB.Push(headB);
            headB = headB.next;
        }
        //if (stackA.Peek() != stackB.Peek())
        //    return null;
        while (stackA.Count > 0 && stackB.Count > 0 && stackA.Peek() == stackB.Peek()) { 
            previousCommon = stackA.Pop();
            stackB.Pop();
        }
        return previousCommon;
    }
}