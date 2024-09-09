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
    public int[][] SpiralMatrix(int m, int n, ListNode head) {
        var matr = new int[m][];

        for (var row = 0; row < m; row++)
        {
            matr[row] = new int[n];
        }

        (int row, int col, int count) direction = (0, 1, n);
        var currRow = 0;
        var currCol = 0;
        var colPassCout = 1;
        var rowPassCount = 1;
        for (var element = 0; element < m * n; element++)
        {
            matr[currRow][currCol] = -1;
            if (head != null)
            {
                matr[currRow][currCol] = head.val;
                head = head.next;
            }
            
            direction.count--;
            if (direction.count == 0)
            {
                var tmp = direction;
                direction.row = tmp.col;
                direction.col = tmp.row * -1;
                if (direction.row == 0)
                {
                    direction.count = n - colPassCout;
                    colPassCout++;
                }
                else
                {
                    direction.count = m - rowPassCount;
                    rowPassCount++;
                }
            }

            currRow += direction.row;
            currCol += direction.col;
        }

        return matr;
    }
}