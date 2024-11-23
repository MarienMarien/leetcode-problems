public class Solution {
    public char[][] RotateTheBox(char[][] box) {
        var rotated = new char[box[0].Length][];
        for (var i = 0; i < rotated.Length; i++)
        {
            rotated[i] = new char[box.Length];
        }

        var rotatedCol = box.Length - 1;
        for (var boxRow = 0; boxRow < box.Length; boxRow++)
        {
            var emptySpaceId = -1;
            for (var boxCol = box[0].Length - 1; boxCol >= 0;  boxCol--)
            {
                switch (box[boxRow][boxCol])
                {
                    case '.':
                        if (emptySpaceId < 0)
                            emptySpaceId = boxCol;
                        rotated[boxCol][rotatedCol] = '.';
                        break;
                    case '#':
                        var rotatedRow = boxCol;
                        if (emptySpaceId >= 0)
                        {
                            rotatedRow = emptySpaceId;
                            rotated[boxCol][rotatedCol] = '.';
                            emptySpaceId--;
                        }
                        rotated[rotatedRow][rotatedCol] = '#';
                        break;
                    case '*':
                        emptySpaceId = -1;
                        rotated[boxCol][rotatedCol] = '*';
                        break;
                    default: break;
                }
            }
            rotatedCol--;
        }

        return rotated;
    }
}