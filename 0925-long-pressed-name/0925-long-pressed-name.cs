public class Solution {
    public bool IsLongPressedName(string name, string typed) {
        if(typed.Length < name.Length)
            return false;
        var nameId = 0;
        var typedId = 0;
        while(typedId < typed.Length){
            if(nameId < name.Length && typed[typedId] == name[nameId]){
                typedId++;
                nameId++;
                continue;
            } else if(typedId > 0 && typed[typedId] == typed[typedId - 1]){
                typedId++;
                continue;
            }
            return false;

        }
        return nameId == name.Length;
    }
}