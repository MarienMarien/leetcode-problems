public class Solution {
    public string[] GetFolderNames(string[] names) {
         var dict = new Dictionary<string, int>();
        //var result = new string[names.Length];
        for (var i = 0; i < names.Length; i++) {
            if (!dict.ContainsKey(names[i]))
            {
                dict.Add(names[i], 1);
                //result[i] = names[i];
            }
            else {
                var number = dict[names[i]];
                var sb = new StringBuilder(names[i]);
                sb.Append('(').Append(number).Append(')');
                while (dict.ContainsKey(sb.ToString())) {
                    number++;
                    sb = new StringBuilder(names[i]);
                    sb.Append('(').Append(number).Append(')');
                }
                dict[names[i]]++;
                names[i] = sb.ToString();
                dict.Add(names[i], 1);
            }
        }
        return names;
    }
}