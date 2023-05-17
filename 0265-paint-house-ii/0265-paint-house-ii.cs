public class Solution {
    public class ValueWithColor { 
        public int Cost { get; set; }
        public int Color { get; set; }
        public ValueWithColor()
        {
            Cost = 0;
            Color = -1;
        }

        public bool HasDefaultValues() {
            return this.Cost == 0;
        }

        public void UpdateValues(int newCost, int newColor) {
            this.Color = newColor;
            this.Cost = newCost;
        }

        public void CopyValues(ValueWithColor copyFrom) { 
            this.Cost = copyFrom.Cost;
            this.Color = copyFrom.Color;
        }

        public bool ShouldUpdate(int cost) {
            return cost < this.Cost || HasDefaultValues();
        }
    }

    public int MinCostII(int[][] costs)
    {
        ValueWithColor min1;
        ValueWithColor min2;
        ValueWithColor currMin1 = new ValueWithColor();
        ValueWithColor currMin2 = new ValueWithColor();
        for (int house = 0; house < costs.Length; house++)
        {
            min1 = currMin1;
            min2 = currMin2;
            currMin1 = new ValueWithColor();
            currMin2 = new ValueWithColor();
            for (int color = 0; color < costs[0].Length; color++)
            {
                int prevMinCost = 0;
                if (color != min1.Color)
                {
                    prevMinCost += min1.Cost;
                }
                else
                {
                    prevMinCost += min2.Cost;
                }
                int currCost = costs[house][color] + prevMinCost;
                if (currMin1.ShouldUpdate(currCost))
                {
                    currMin2.CopyValues(currMin1);
                    currMin1.UpdateValues(currCost, color);
                }
                else if (currMin2.ShouldUpdate(currCost))
                {
                    currMin2.UpdateValues(currCost, color);
                }
            }
        }
        return currMin1.Cost;
    }
}