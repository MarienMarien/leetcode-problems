public class Solution {
    public int TotalFruit(int[] fruits) {
        if (fruits.Length == 0)
                return 0;
            var maxFruits = 1;
            var start = 0;
            var end = 1;
            var tree1 = start;
            int tree2 = -1;
            var nextId = -1;
            while(end < fruits.Length)
            {
                if (tree2 < 0 && fruits[end] != fruits[start]) { 
                    tree2 = end;
                }
                if (tree2 >= 0 && fruits[end] != fruits[tree1] && fruits[end] != fruits[tree2]) {
                    maxFruits = Math.Max(maxFruits, end - start);
                    start = nextId;
                    tree1 = start;
                    tree2 = end;
                }
                if (nextId < 0 || fruits[end] != fruits[nextId])
                    nextId = end;
                
                end++;
            }
            maxFruits = Math.Max(maxFruits, end - start);
            return maxFruits;
    }
}