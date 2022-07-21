public class Solution {
    public void Rotate(int[] nums, int k) {
           if (nums == null || nums.Length <= 1 || k <= 0)
            {
                return;
            }

            int len = nums.Length;
            int step = k % len;
            int count = 0;
            for (int start = 0; start < len; start++)
            {
                int hold = nums[start];
                int position = start;
                do
                {
                    position = (position + step) % len;
                    int tmp = hold;
                    hold = nums[position];
                    nums[position] = tmp;
                    count++;
                } while (position != start);

                if (count == len)
                {
                    break;
                }
            }
    }
}