public class Solution {
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts) {
        var n = accounts.Count;
        var emailToIndex = new Dictionary<string, int>();
        var uf = new UnionFind(n);
        for (var groupId = 0; groupId < n; groupId++)
        {
            var account = accounts[groupId];
            for (var emailId = 1; emailId < account.Count; emailId++)
            {
                var currEmail = account[emailId];
                if (!emailToIndex.ContainsKey(currEmail))
                {
                    emailToIndex[currEmail] = groupId;
                }
                else 
                {
                    uf.Union(emailToIndex[currEmail], groupId);
                }
            }
        }

        var groupedAccounts = new Dictionary<int, IList<string>>();
        foreach (var email in emailToIndex)
        {
            var emailGroup = uf.Find(email.Value);
            if (!groupedAccounts.ContainsKey(emailGroup))
                groupedAccounts.Add(emailGroup, new List<string>());
            groupedAccounts[emailGroup].Add(email.Key);
        }

        var mergedAccounts = new List<IList<string>>();
        foreach (var group in groupedAccounts)
        {
            var accountName = accounts[group.Key][0];
            var orderedEmails = group.Value.Order(StringComparer.Ordinal);
            var mergedAccount = new List<string>(group.Value.Count + 1) { accountName };
            foreach (var email in orderedEmails)
            {
                mergedAccount.Add(email);
            }
            mergedAccounts.Add(mergedAccount);
        }

        return mergedAccounts;
    }

    class UnionFind
    {
        private int[] _parent;
        public UnionFind(int n)
        {
            _parent = new int[n];
            for (var i = 0; i < n; i++)
            {
                _parent[i] = i;
            }
        }

        public void Union(int a, int b)
        {
            var parentA = Find(a);
            var parentB = Find(b);
            if (parentA == parentB)
                return;
            _parent[parentB] = parentA;
        }

        public int Find(int x)
        {
            if (_parent[x] != x)
                _parent[x] = Find(_parent[x]);
            return _parent[x];
        }
    }
}