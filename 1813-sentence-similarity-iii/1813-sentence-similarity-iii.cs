public class Solution {
    public bool AreSentencesSimilar(string sentence1, string sentence2) {
        if(sentence1 == sentence2)
            return true;
        var list1 = new LinkedList<string>(sentence1.Split(" "));
        var list2 = new LinkedList<string>(sentence2.Split(" "));
        while(list1.Count > 0 && list2.Count > 0 && list1.First.Value.Equals(list2.First.Value)){
            list1.RemoveFirst();
            list2.RemoveFirst();
        }
        while(list1.Count > 0 && list2.Count > 0 && list1.Last.Value.Equals(list2.Last.Value)){
            list1.RemoveLast();
            list2.RemoveLast();
        }
        return list1.Count == 0 || list2.Count == 0;
    }
}