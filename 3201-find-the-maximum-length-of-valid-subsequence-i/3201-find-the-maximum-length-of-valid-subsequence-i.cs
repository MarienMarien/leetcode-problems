public class Solution {
    public int MaximumLength(int[] nums) {
        var oddCount = 0;
        var oddAltCount = 0;
        var evenCount = 0;
        var evenAltCount = 0;
        var oddAltIsOdd = true;
        var evenAltIsOdd = false;
        for(var i = 0; i < nums.Length; i++)
        {
            var isOddNum = nums[i] % 2 == 1;
            if(isOddNum)
            {
                oddCount++;
                if(oddAltIsOdd)
                {
                    oddAltCount++;
                    oddAltIsOdd = !oddAltIsOdd;
                }
                if(evenAltIsOdd)
                {
                    evenAltCount++;
                    evenAltIsOdd = !evenAltIsOdd;
                }
            } 
            else 
            {
                evenCount++;
                if(!evenAltIsOdd)
                {
                    evenAltCount++;
                    evenAltIsOdd = !evenAltIsOdd;
                }
                if(!oddAltIsOdd)
                {
                    oddAltCount++;
                    oddAltIsOdd = !oddAltIsOdd;
                }
            }
        }
        
        return Math.Max(Math.Max(oddCount, oddAltCount), Math.Max(evenCount, evenAltCount));
    }
}