public class Solution {
    public int NumUniqueEmails(string[] emails) {
        var set = new HashSet<string>();
        foreach (var e in emails) {
            var basicEmail = GetBasic(e);
            if (!set.Contains(basicEmail))
                set.Add(basicEmail);
        }
        return set.Count;
    }

    private string GetBasic(string email)
    {
        var sb = new StringBuilder();
        var skip = false;
        var isDomainPart = false;
        foreach (var ch in email) {
            if (ch == '.' && !isDomainPart)
                continue;
            if (ch == '+') { 
                skip = true;
                continue;
            }
            if (ch == '@')
            {
                isDomainPart = true;
                skip = false;
            }
            if (!skip)
                sb.Append(ch);
        }
        return sb.ToString();
    }
}