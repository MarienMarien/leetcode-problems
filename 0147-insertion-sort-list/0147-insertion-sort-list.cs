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
    public ListNode InsertionSortList(ListNode head) {
        var ans = head;
        var sortedStack = new Stack<ListNode>();
        
        while (head != null) {
            if (sortedStack.Count == 0) { 
                sortedStack.Push((ListNode)head);
                head = head.next;
                continue;
            }
            if (sortedStack.Peek().val <= head.val) {
                sortedStack.Push((ListNode)head);
                head = head.next;
                continue;
            }
            var tmpStack = new Stack<ListNode>();
            while (sortedStack.Count > 0 && sortedStack.Peek().val > head.val) { 
                tmpStack.Push(sortedStack.Pop());
            }
            var tmpNext = head.next;
            if (sortedStack.Count > 0)
            {
                sortedStack.Peek().next = head;
            }
            else {
                ans = head;
            }
            head.next = tmpStack.Count > 0 ? tmpStack.Peek() : null;
            sortedStack.Push((ListNode)head);
            while (tmpStack.Count > 0) {
                sortedStack.Push(tmpStack.Pop());
            }
            sortedStack.Peek().next = tmpNext;
            head = tmpNext;
        }

        return ans;
    }
}