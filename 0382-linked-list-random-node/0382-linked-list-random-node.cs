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
    private IList<ListNode> _list;
    public Solution(ListNode head) {
        _list = new List<ListNode>();
        var id = 0;
        while (head != null) {
            _list.Add(head);
            head = head.next;
            id++;
        }
    }

    public int GetRandom()
    {
        var rand = new Random();
        var randItem = rand.Next(_list.Count);
        return _list[randItem].val;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(head);
 * int param_1 = obj.GetRandom();
 */