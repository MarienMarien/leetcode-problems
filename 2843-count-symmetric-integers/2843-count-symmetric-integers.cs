public class Solution {
    public int CountSymmetricIntegers(int low, int high) {
        var count = 0;
        for(var num = low; num <= high; num++)
        {
            switch(num)
            {
                case < 100:
                {
                    if(num % 11 == 0)
                        count++;
                    break;
                }
                case > 1000:
                {    
                    var left = num / 100;
                    var leftSum = left / 10 + left % 10;
                    var right = num % 100;
                    var rightSum = right / 10 + right % 10;
                    if(leftSum == rightSum)
                        count++;
                    break;
                }
                default:
                    break;
            }

        }

        return count;
    }
}