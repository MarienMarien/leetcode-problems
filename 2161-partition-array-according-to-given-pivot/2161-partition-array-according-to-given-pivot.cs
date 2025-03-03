public class Solution {
    public int[] PivotArray(int[] nums, int pivot) {
        var larger = new List<int>();
        var smallerId = 0;
        var pivotValCount = 0;
        for(var curr = 0; curr < nums.Length; curr++)
        {
            if(nums[curr] >= pivot)
            {
                if(nums[curr] == pivot)
                    pivotValCount++;
                else 
                    larger.Add(nums[curr]);

                continue;
            }
            
            nums[smallerId] = nums[curr];
            smallerId++;
        }

        for(var i = 0; i < pivotValCount; i++)
        {
            nums[smallerId] = pivot;
            smallerId++;
        }

        foreach(var large in larger)
        {
            nums[smallerId] = large;
            smallerId++;
        }

        return nums;
    }
}