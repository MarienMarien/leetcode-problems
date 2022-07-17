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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        if (list1 == null)
            return list2;
        if (list2 == null)
            return list1;

        var l1cur = list1;
        var l2cur = list2;

        while (l2cur != null)
        {
            if (l1cur.val <= l2cur.val && l1cur.next == null)
            {
                l1cur.next = l2cur;
                break;
            }
            if (l1cur.val <= l2cur.val && l2cur.val < l1cur.next.val)
            {
                var tmp = l2cur;
                l2cur = l2cur.next;
                tmp.next = l1cur.next;
                l1cur.next = tmp;
                l1cur = l1cur.next;
                continue;
            }
            //when L2 head smaller L1 head case
            if (l2cur.val < l1cur.val)
            {
                var tmp = l2cur;
                l2cur = l2cur.next;
                tmp.next = l1cur;
                // reset list1 head
                list1 = tmp;
                l1cur = list1;
                continue;
            }
            if(l1cur.next != null)
                l1cur = l1cur.next;
        }

        return list1;
    }
}