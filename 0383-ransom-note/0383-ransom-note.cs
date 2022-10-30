public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        if (ransomNote.Length > magazine.Length)
            return false;
        var note = ransomNote.ToCharArray();
        Array.Sort(note);
        var mgzn = magazine.ToCharArray();
        Array.Sort(mgzn);
        var noteId = 0;
        var mgznId = 0;
        while (mgznId < magazine.Length) {
            if (noteId == note.Length)
                return true;
            if (note[noteId] == mgzn[mgznId])
                noteId++;
            mgznId++;
        }
        return noteId == note.Length;
    }
}