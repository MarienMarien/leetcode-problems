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
    private Dictionary<int, int> map;
    public ListNode DeleteDuplicatesUnsorted(ListNode head)
    {
        var newHead = new ListNode(0, head);
        map = new Dictionary<int, int>();

        RemDuplicates(newHead);

        return newHead.next;
    }

    private void RemDuplicates(ListNode node)
    {
        if (node.next == null)
            return;

        if (!map.TryAdd(node.next.val, 1))
            map[node.next.val]++;
        RemDuplicates(node.next);
        if (map.ContainsKey(node.next.val) && map[node.next.val] > 1)
        {
            node.next = node.next?.next;
        }
    }
}