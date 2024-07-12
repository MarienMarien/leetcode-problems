public class Solution {
     public int MaximumGain(string s, int x, int y)
    {
        var head = new DoublyLinkedListNode<char>();
        var list = head;
        foreach (var ch in s)
        {
            var newNode = new DoublyLinkedListNode<char>(ch, list);
            list.next = newNode;
            list = list.next;
        }

        var higherScore = x > y ? x : y;
        var higherScoreCombination = higherScore == x ? "ab" : "ba";

        var totalScore = 0;

        var curr = head;
        var currScore = 0;
        (curr, currScore) = CalcCombinationScore(curr, higherScore, higherScoreCombination);
        totalScore += currScore;
       
        var lowerScore = higherScore == x ? y : x;
        var lowerScoreCombination = higherScore == x ? "ba" : "ab";

        (_, currScore) = CalcCombinationScore(curr, lowerScore, lowerScoreCombination);
        totalScore += currScore;
        
        return totalScore;
    }

    private (DoublyLinkedListNode<char>, int) CalcCombinationScore(DoublyLinkedListNode<char> curr, int combinationScore, string combination)
    {
        var currHead = curr;
        var score = 0;
        while (curr != null)
        {
            if (curr.next != null && curr.val == combination[0] && curr.next.val == combination[1])
            {
                score += combinationScore;
                var newNext = curr.next.next;
                if(newNext != null)
                    newNext.prev = curr.prev;
                curr = curr.prev;
                
                curr.next = newNext;
                continue;
            }
            curr = curr.next;
        }

        return (currHead, score);
    }

    public class DoublyLinkedListNode<T>
    {
        public T val;
        public DoublyLinkedListNode<T> prev;
        public DoublyLinkedListNode<T> next;

        public DoublyLinkedListNode(T val = default, DoublyLinkedListNode<T> prev = null, DoublyLinkedListNode<T> next = null)
        {
            this.val = val;
            this.prev = prev;
            this.next = next;
        }
    }
}