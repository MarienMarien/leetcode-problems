public class Solution {
    public IList<string> InvalidTransactions(string[] transactions) {
        var dict = new Dictionary<string, List<Transaction>>();
        Array.Sort(transactions);
        foreach (var tr in transactions) {
            var trObj = new Transaction(tr);
            if (!dict.ContainsKey(trObj.Name)) {
                dict.Add(trObj.Name, new List<Transaction>());
            }
            dict[trObj.Name].Add(trObj);
        }
        IList<string> invalid = new List<string>();
        foreach (var user in dict) {
            for (var i = 0; i < user.Value.Count; i++) {
                if (!IsValid(i, user.Value[i], user.Value))
                    invalid.Add(user.Value[i].ToString());
            }
        }
        return invalid;
    }

    private bool IsValid(int id, Transaction tr, List<Transaction> transactions) {
        if (tr.Amount > 1000)
            return false;
        for (var i = 0; i < transactions.Count; i++) {
            if (i == id)
                continue;
            if (Math.Abs(tr.Time - transactions[i].Time) <= 60 && tr.City != transactions[i].City)
                return false;
        }
        return true;
    }

    private class Transaction {
        private string _initial;
        public string Name;
        public int Time;
        public int Amount;
        public string City;
        public Transaction(string initial)
        {
            _initial = initial;
            var parts = initial.Split(',');
            Name = parts[0];
            Time = Int32.Parse(parts[1]);
            Amount = Int32.Parse(parts[2]);
            City = parts[3];
        }

        override public string ToString() {
            return _initial;
        }
    }
}