public class Solution {
    public char NextGreatestLetter(char[] letters, char target) {
        const char Z = 'z';
        if(target == Z)
            return letters[0];
        char minMax = Z;
        bool found = false;
        foreach (char letter in letters) {
            if(letter <= minMax && letter > target){
                minMax = letter;
                found = true;
            }
        }
        return found ? minMax : letters[0];
    }
}