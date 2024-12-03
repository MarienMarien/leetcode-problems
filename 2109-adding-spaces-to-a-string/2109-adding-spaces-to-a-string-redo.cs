public class Solution {
    public string AddSpaces(string s, int[] spaces) {
        var sb = new StringBuilder(s.Length + spaces.Length);
        var spacesId  =0;
        for(var i = 0; i < s.Length; i++)
        {
            if(spacesId < spaces.Length && i == spaces[spacesId])
            {
                sb.Append(' ');
                spacesId++;
            }
            sb.Append(s[i]);
        }

        return sb.ToString();
    }
}