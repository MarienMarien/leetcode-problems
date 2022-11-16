/** 
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is higher than the picked number
 *			      1 if num is lower than the picked number
 *               otherwise return 0
 * int guess(int num);
 */

public class Solution : GuessGame {
    public int GuessNumber(int n) {
        if(guess(n) == 0)
            return n;
        var start = 1;
        var end = n;
        int mid = 0;
        while(start < end){
            mid = start + ((end - start) / 2);
            var guessed = guess(mid);
            if(guessed == 0)
                break;
            if(guessed == -1)
                end = mid;
            else 
                start = mid + 1;

        }
        return mid;
    }
}