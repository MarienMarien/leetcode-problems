public class Solution {
    public int[] AsteroidCollision(int[] asteroids) {
        var list = new LinkedList<int>(asteroids);
        var currAst = list.First.Next;
        var prev = list.First;
        while (currAst != null){
            if (currAst == prev) {
                currAst = currAst.Next;
                continue;
            }
            if (prev.Value * currAst.Value > 0 || (prev.Value < 0 && currAst.Value > 0))
            {
                prev = prev.Next;
                currAst = currAst.Next;
                continue;
            }
            var toDel = currAst;
            if (Math.Abs(prev.Value) > Math.Abs(currAst.Value)) {

                currAst = currAst.Next;
                list.Remove(toDel);
                continue;
            }
            if (Math.Abs(prev.Value) == Math.Abs(currAst.Value)) {
                currAst = currAst.Next;
                list.Remove(toDel);
            }
            toDel = prev;
            prev = prev.Previous == null ? prev.Next : prev.Previous;
            list.Remove(toDel);

        }
        return list.ToArray();
    }
}