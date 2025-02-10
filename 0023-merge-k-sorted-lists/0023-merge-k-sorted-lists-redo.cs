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
    public ListNode MergeKLists(ListNode[] lists) {
        var pq = new PriorityQueue<ListNode, int>();
        foreach(var l in lists)
        {
            if(l != null)
                pq.Enqueue(l, l.val);
        }
        var newHead = new ListNode();
        var merged = newHead;
        while(pq.Count > 0)
        {
            var curr = pq.Dequeue();
            merged.next = curr;
            merged = merged.next;
            if(curr.next != null)
            {
                pq.Enqueue(curr.next, curr.next.val);
            }
        }

        return newHead.next;
    }
}