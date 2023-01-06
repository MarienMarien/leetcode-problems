public class Solution {
    public int MaxIceCream(int[] costs, int coins) {
        Array.Sort(costs);
        var count = 0;
        var cId = 0;
        while(cId < costs.Length){
            if(coins - costs[cId] < 0)
                break;
            coins -= costs[cId];
            count++;
            cId++;
        }
        return count;
    }
}