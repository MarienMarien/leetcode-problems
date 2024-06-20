public class Solution {
    public int MaxBoxesInWarehouse(int[] boxes, int[] warehouse) {
        Array.Sort(boxes);
        var left = 0;
        var right = warehouse.Length - 1;
        var boxId = boxes.Length - 1;

        var boxCount = 0;

        while (left <= right && boxId >= 0) 
        {
            if (boxes[boxId] <= warehouse[left])
            {
                boxCount++;
                left++;
            }
            else if (boxes[boxId] <= warehouse[right])
            {
                right--;
                boxCount++;
            }
            boxId--;
        }

        return boxCount;
    }
}