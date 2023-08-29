public class Solution {
    public int BestClosingTime(string customers) {
        var totalPenaltyAfterClosing = 0;
        foreach (var c in customers)
        {
            if (c == 'Y')
                totalPenaltyAfterClosing++;
        }
        var minPenalty = totalPenaltyAfterClosing;
        var noCustomerPenalty = 0;
        var earliestClosingHour = 0;
        for(var h = 0; h < customers.Length; h ++) {
            if (customers[h] == 'Y')
            {
                totalPenaltyAfterClosing--;
            }
            else { 
                noCustomerPenalty++;
            }
            var totalPenalty = totalPenaltyAfterClosing + noCustomerPenalty;
            if (totalPenalty < minPenalty) {
                earliestClosingHour = h + 1;
                minPenalty = totalPenalty;
            }
        }

        return earliestClosingHour;
    }
}