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
        Console.WriteLine($"Test Start"); 
        var pq = new PriorityQueue<ListNode, int>();
        var index = 0;
        while(index < lists.Length){
            var l = lists[index];
            while (l != null) {
                pq.Enqueue(l, l.val);
                l = l.next;
            }
            index++;
        }
        var result = new ListNode();
        var curr = result;
        while (pq.Count > 0) {
            Console.WriteLine($"pq.Count = {pq.Count}"); 
            curr.next = pq.Dequeue();
            curr = curr.next;
            Console.WriteLine($"curr val = {curr.val}");
        }
        curr.next = null;
        return result.next;
    }
}