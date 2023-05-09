public class Solution {
    public bool CheckString(string s) {
        bool bFound = false;
        const char A = 'a';
        const char B = 'b';
        foreach(char ch in s){
            if(ch == B)
                bFound = true;
            else if(ch == A && bFound)
                return false;
        }
        return true;
    }
}