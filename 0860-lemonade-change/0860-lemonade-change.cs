public class Solution {
    public bool LemonadeChange(int[] bills) {
        var cash5 = 0;
        var cash10 = 0;
        foreach (var b in bills)
        {
            switch (b)
            {
                case 5:
                    cash5++;
                    break;
                case 10:
                    if (cash5 == 0)
                        return false;
                    cash5--;
                    cash10++;
                    break;
                default:
                    var change = 15;
                    if (cash10 > 0)
                    {
                        change -= 10;
                        cash10--;
                    }
                    if (cash5 == 0 || change / 5 > cash5)
                        return false;
                    cash5 -= change / 5;
                    break;
            }
        }

        return true;
    }
}