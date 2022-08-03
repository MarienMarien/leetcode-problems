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
    public ListNode SortList(ListNode head) {
        var root = head;
        var prev = head;
        var current = head?.next;
        ListNode toInsert;
        while (current != null) {
            if (current.val < prev.val) { 
                toInsert = current;
                prev.next = current.next;
                if (current.val < root.val)
                {
                    current.next = root;
                    root = current;
                }
                else {
                    var localPrev = root;
                    var localCurr = root.next;
                    while (localCurr != null && localCurr.val < toInsert.val) {
                        localPrev = localPrev.next;
                        localCurr = localCurr.next;
                    }
                    localPrev.next = toInsert;
                    toInsert.next = localCurr;
                }
                current = prev.next;
                continue;
            }
            current = current.next;
            prev = prev.next;
        }

        return root;
    }
}