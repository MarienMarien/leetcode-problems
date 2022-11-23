public class Solution {
    public string ValidIPAddress(string queryIP) {
        if (queryIP.Contains('.')) {
            return ChechIPv4(queryIP);
        }
        if (queryIP.Contains(':')) {
            return CheckIPv6(queryIP);
        }
        return "Neither";
    }

    private string CheckIPv6(string queryIP)
    {
        var regex = new System.Text.RegularExpressions.Regex("[^a-fA-F0-9]");
        var parts = queryIP.Split(':');
        if (parts.Length != 8)
            return "Neither";
        foreach (var p in parts) { 
            if(p.Length > 4 || p.Length < 1){
                return "Neither";
            }
            if(regex.IsMatch(p))
                return "Neither";
        }
        return "IPv6";
    }

    private string ChechIPv4(string queryIP)
    {
        var parts = queryIP.Split('.');
        if (parts.Length != 4)
            return "Neither";
        foreach (var p in parts) { 
            if(p.Length > 1 && p[0] == '0')
                return "Neither";
            if (!Int32.TryParse(p, out int n) || n > 255) {
                return "Neither";
            }
        }
        return "IPv4";
    }
}