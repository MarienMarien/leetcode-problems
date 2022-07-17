public class Solution {
    
    public int BombsCnt { get; set; }
    public ISet<int> Detonated { get; set; }
    
    public int MaximumDetonation(int[][] bombs) {
           // sort by x
            bombs = bombs.OrderBy(x => x[0]).ToArray();
            var maxDetBombs = 0;
            BombsCnt = bombs.Count();
            for (var i = 0; i < bombs.Length; i++)
            {
                Detonated = new HashSet<int>();
                Detonated.Add(i);
                var detBombs = CountDetonatedBombsDfs(bombs, i) + 1;
                if (detBombs > maxDetBombs)
                    maxDetBombs = detBombs;
                if (detBombs == BombsCnt)
                    break;
            }
            return maxDetBombs;
        }

        public int CountDetonatedBombsDfs(int[][] bombs, int currBombIndex) {
            var res = 0;
            // stop condition
            if (Detonated.Count == BombsCnt)
                return res;
            for (var i = 0; i < bombs.Count(); i++) {
                if (i == currBombIndex)
                    continue;
                var diameter = Math.Sqrt(Math.Pow(Math.Abs(bombs[currBombIndex][0] - bombs[i][0]), 2) + Math.Pow(Math.Abs(bombs[currBombIndex][1] - bombs[i][1]), 2));
                if (diameter <= bombs[currBombIndex][2] && !Detonated.Contains(i))
                {
                    Detonated.Add(i);
                    res += CountDetonatedBombsDfs(bombs, i) + 1;
                }
               
            }
            return res;
        }
}