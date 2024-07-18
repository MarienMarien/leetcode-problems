public class Solution {
    public string PredictPartyVictory(string senate) {
        const char D = 'D';
        const char R = 'R';
        const string RADIANT = "Radiant";
        const string DIRE = "Dire";

        var q = new Queue<char>();

        var bannedR = 0;
        var bannedD = 0;
        foreach (var s in senate)
            q.Enqueue(s);

        while (q.Count > 1)
        {
            var s = q.Dequeue();
            if (s == D)
            {
                if (bannedD > 0)
                {
                    bannedD--;
                }
                else
                {
                    q.Enqueue(D);
                    bannedR++;
                }
            }
            else if(s == R) 
            {
                if (bannedR > 0)
                {
                    bannedR--;
                }
                else {
                    q.Enqueue(R);
                    bannedD++;
                }
            }
            if (bannedD == q.Count)
                return RADIANT;
            if (bannedR == q.Count)
                return DIRE;
        }

        var last = q.Dequeue();
        
        return last == R ? RADIANT : DIRE;
    }
}