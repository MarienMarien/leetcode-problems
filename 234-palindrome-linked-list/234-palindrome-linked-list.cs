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
    public bool IsPalindrome(ListNode head) {
         if (head == null || head.next == null)
                return true;
            ListNode center = GetSecondPartStart(head);
            var reverced = ReverseList(center.next);
            var res = true;
            var start = head;
            var end = reverced;
            while (res && end != null)
            {
                if (start.val != end.val) res = false;
                start = start.next;
                end = end.next;
            }
            center.next = ReverseList(reverced);

            return res;
        }

        public static ListNode GetSecondPartStart(ListNode node) {
            ListNode fast = node;
            ListNode slow = node;
            while (fast.next != null && fast.next.next != null) {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }
        public static ListNode ReverseList(ListNode node) {
            var curr = node;
            var head = node;
            ListNode prev = null;
            while (head != null) {
                head = head.next;
                curr.next = prev;
                prev = curr;
                curr = head;
            }
            return prev;
    }
}