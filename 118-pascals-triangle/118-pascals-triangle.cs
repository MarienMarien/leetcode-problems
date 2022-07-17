public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        IList<IList<int>> res = new List<IList<int>>();
            if (numRows < 1)
                return res;
            
            const int defaultElement = 1;
            IList<int> firstRow = new List<int>();
            firstRow.Add(defaultElement);
            res.Add(firstRow);
            for (var i = 2; i <= numRows; i++) {
                IList<int> row = new List<int>();
                row.Add(defaultElement);
                var newRowElIndex = 1; // start from second item
                var prevRow = res[res.Count - 1];
                while (newRowElIndex < i - 1) {
                    var newEl = prevRow[newRowElIndex - 1] + prevRow[newRowElIndex];
                    row.Add(newEl);
                    newRowElIndex++;
                }
                row.Add(defaultElement);
                res.Add(row);
            }

            return res;
    }
}