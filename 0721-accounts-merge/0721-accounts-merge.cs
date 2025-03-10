public class Solution {
    private ISet<string> _visited;
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts) {
        _visited = new HashSet<string>();

        var graph = new Dictionary<string, ISet<string>>();
        foreach(var acc in accounts)
        {
            var accName = acc[0];
            var accFirstEmail = acc[1];
            for(var i = 2; i < acc.Count; i++)
            {
                var accEmail = acc[i];
                if(!graph.ContainsKey(accFirstEmail))
                    graph.Add(accFirstEmail, new HashSet<string>());
                graph[accFirstEmail].Add(accEmail);
                if(!graph.ContainsKey(acc[i]))
                    graph.Add(accEmail, new HashSet<string>());
                graph[accEmail].Add(accFirstEmail);
            }
        }

        var mergedAccounts = new List<IList<string>>();
        foreach(var acc in accounts)
        {
            var accName = acc[0];
            var accFirstEmail = acc[1];
            if(_visited.Contains(accFirstEmail))
                continue;
            var mergedAccount = new List<string>();
            mergedAccount.Add(accName);
            GetAllAccountEmails(mergedAccount, graph, accFirstEmail);
            mergedAccount.Sort(1, mergedAccount.Count - 1, StringComparer.Ordinal);
            mergedAccounts.Add(mergedAccount);
        }

        return mergedAccounts;
    }

    private void GetAllAccountEmails(List<string> emails, IDictionary<string, ISet<string>> graph, string email)
    {
        _visited.Add(email);
        emails.Add(email);

        if(!graph.ContainsKey(email))
            return;
        foreach(var adj in graph[email])
        {
            if(!_visited.Contains(adj))
                GetAllAccountEmails(emails, graph, adj);
        }
    }
}