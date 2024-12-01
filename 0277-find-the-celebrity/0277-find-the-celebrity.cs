/* The Knows API is defined in the parent class Relation.
      bool Knows(int a, int b); */

public class Solution : Relation {
    public int FindCelebrity(int n) {
        var celebrityCandidate = 0;
        for (var person = 1; person < n; person++)
        {
            if (Knows(celebrityCandidate, person))
            {
                celebrityCandidate = person;
            }
        }

        for (var person = 0; person < n; person++)
        {
            if (person == celebrityCandidate)
                continue;
            if (!Knows(person, celebrityCandidate) || Knows(celebrityCandidate, person))
                return -1;
        }

        return celebrityCandidate;
    }
}