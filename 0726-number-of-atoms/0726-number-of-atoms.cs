public class Solution {
    public string CountOfAtoms(string formula) {
        var elements = new SortedDictionary<string, int>();
        var koefs = new Stack<int>();

        var i = formula.Length - 1;
        int currKoef = 1;
        var totalKoef = 1;

        while (i >= 0)
        {
            
            if (char.IsDigit(formula[i])) {
                var numberStartPos = i;
                while (char.IsDigit(formula[i]))
                {
                    i--;
                }
                currKoef = Int32.Parse(formula[(i + 1)..(numberStartPos + 1)]);

                continue;
            }

            if (formula[i] == ')')
            {
                if (currKoef > 1)
                {
                    koefs.Push(currKoef);
                    totalKoef *= currKoef;
                    currKoef = 1;
                }

                i--;
                continue;
            }

            if (formula[i] == '(')
            {
                if (koefs.Count > 0)
                {
                    var prevKoef = koefs.Pop();
                    totalKoef /= prevKoef;
                }

                i--;
                continue;
            }

            // if letter
            var elementStartPos = i;
            while (char.IsLower(formula[i]))
            {
                i--;
            }

            var element = formula[i..(elementStartPos + 1)];
            var elementCount = totalKoef * currKoef;
            if (!elements.TryAdd(element, elementCount))
            {
                elements[element] += elementCount;
            }
            currKoef = 1;
            i--;
        }

        var sb = new StringBuilder();
        foreach (var el in elements)
        {
            sb.Append(el.Key);
            if (el.Value > 1)
                sb.Append(el.Value);
        }

        return sb.ToString();
    }
}