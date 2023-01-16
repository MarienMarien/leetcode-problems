/**
 * The Read4 API is defined in the parent class Reader4.
 *     int Read4(char[] buf4);
 */

public class Solution : Reader4 {
    /**
     * @param buf Destination buffer
     * @param n   Number of characters to read
     * @return    The number of actual characters read
     */
    public int Read(char[] buf, int n) {
        var currCount = n;
        var bufId = 0;
        while(currCount > 0){
            var buf4 = new char[4];
            var readCount = Read4(buf4);
            if(readCount == 0)
                break;
            for(var i = 0; i < readCount; i++){
                buf[bufId] = buf4[i];
                bufId++;
                currCount--;
                if(currCount == 0)
                    break;
            }
        }
        return n - currCount;
    }
}