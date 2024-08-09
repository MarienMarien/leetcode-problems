public class Solution {
    private DoublyLinkedListNode _list;
    private int[] _listSource = { 2, 9, 4, 3, 8, 1, 6, 7 };
    private IDictionary<int, DoublyLinkedListNode> _map;
    private int[][] _directions = new int[][] {
            new int[] { 0, 1 }, new int[] { 1, 0 },
            new int[] { 0, -1 }, new int[] { -1, 0 }
        };

    public int NumMagicSquaresInside(int[][] grid)
    {
        var count = 0;
        if (grid.Length < 3 || grid[0].Length < 3)
            return count;

        _list = new DoublyLinkedListNode();
        var curr = _list;
        _map = new Dictionary<int, DoublyLinkedListNode>();

        foreach (var el in _listSource)
        {
            var newNode = new DoublyLinkedListNode(el, curr);
            curr.next = newNode;

            _map.Add(el, newNode);
            curr = curr.next;
        }
        _list = _list.next;
        curr.next = _list;
        _list.prev = curr;

        for (var row = 0; row < grid.Length - 2; row++)
        {
            for (var col = 0; col < grid[0].Length - 2; col++)
            {
                if (grid[row][col] == 5 || grid[row][col] > 9 || grid[row][col] == 0)
                    continue;
                if (IsMagicSqare(grid, row, col))
                {
                    col++;
                    count++;
                }
            }
        }

        return count;
    }

    private bool IsMagicSqare(int[][] grid, int row, int col)
    {
        if (grid[row + 1][col + 1] != 5)
            return false;

        var currListEl = _map[grid[row][col]];
        var isClockwise = grid[row][col + 1] == currListEl.next.val ? true : false;
        currListEl = isClockwise ? currListEl.next : currListEl.prev;

        foreach (var d in _directions) {
            for (var i = 0; i < 2; i++)
            {
                row += d[0];
                col += d[1];
                if (grid[row][col] != currListEl.val)
                    return false;

                currListEl = isClockwise ? currListEl.next : currListEl.prev;
            }
        }

        return true;
    }

    public class DoublyLinkedListNode
    {
        public int val;
        public DoublyLinkedListNode prev;
        public DoublyLinkedListNode next;

        public DoublyLinkedListNode(int val = 0, DoublyLinkedListNode prev = null, DoublyLinkedListNode next = null)
        {
            this.val = val;
            this.prev = prev;
            this.next = next;
        }
    }
}