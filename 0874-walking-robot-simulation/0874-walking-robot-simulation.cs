public class Solution {
    private const int HASH_MULT = 60001;
    public int RobotSim(int[] commands, int[][] obstacles)
    {
        var obstaclesSet = new HashSet<int>();
        var maxEuclidDist = 0;

        var directions = CreateDirectionsDLL();

        var directionCoord = new Dictionary<char, int[]> {
            { 'N', new int[] { 0, 1 } },
            { 'E', new int[] { 1, 0 } },
            { 'S', new int[] { 0, -1 } },
            { 'W', new int[] { -1, 0 } }
        };

        foreach (var o in obstacles)
        {
            obstaclesSet.Add(GetHash(o[0], o[1]));
        }

        var row = 0;
        var col = 0;

        foreach (var c in commands)
        {
            
            switch (c)
            {
                case -1:
                    directions = directions.next;
                    break;
                case -2:
                    directions = directions.prev;
                    break;
                default:
                    var coefs = directionCoord[directions.val];
                    for (var step = 0; step < c; step++)
                    {
                        var nextRow = row + coefs[0];
                        var nextCol = col + coefs[1];
                        if (obstaclesSet.Contains(GetHash(nextRow, nextCol)))
                            break;
                        row = nextRow;
                        col = nextCol;
                    }

                    
                    maxEuclidDist = Math.Max(maxEuclidDist, Math.Abs(row * row + col * col));
                    break;
            }
        }

        return maxEuclidDist;
    }

    private int GetHash(int row, int col)
    {
        return row + HASH_MULT * col;
    }

    private DoublyLinkedListNode CreateDirectionsDLL()
    {
        var head = new DoublyLinkedListNode('f');
        var curr = head;
        var directions = new char[] { 'N', 'E', 'S', 'W' };
        foreach (var d in directions)
        {
            var node = new DoublyLinkedListNode(d, curr);
            curr.next = node;
            curr = curr.next;
        }
        var tmp = curr;
        head.next.prev = tmp;
        curr.next = head.next;
        return curr.next;
    }

    public class DoublyLinkedListNode
    {
        public char val;
        public DoublyLinkedListNode prev;
        public DoublyLinkedListNode next;

        public DoublyLinkedListNode(char val, DoublyLinkedListNode prev = null, DoublyLinkedListNode next = null)
        {
            this.val = val;
            this.prev = prev;
            this.next = next;
        }
    }
}