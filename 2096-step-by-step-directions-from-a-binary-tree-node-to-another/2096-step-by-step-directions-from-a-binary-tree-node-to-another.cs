/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public string GetDirections(TreeNode root, int startValue, int destValue) {
        var startL = new List<char>();
        var destL = new List<char>();
        startL = Find(root, startValue, startL);
        destL = Find(root, destValue, destL);
        
        var sb = new StringBuilder();
        var startLId = 0;
        var destLId = 0;
        while (startLId < startL.Count && destLId < destL.Count && startL[startLId] == destL[destLId]) {
            startLId++;
            destLId++;
        }
        sb.Append('U', startL.Count - startLId);
        while (destLId < destL.Count) {
            sb.Append(destL[destLId]);
            destLId++;
        }
        return sb.ToString();
    }
    private List<char> Find(TreeNode root, int target, List<char> list)
    {
        if (root == null)
            return null;
        if (root.val == target)
            return list;
        // left
        list.Add('L');
        var currList = Find(root.left, target, list);
        //right
        if (currList == null)
        {
            list.RemoveAt(list.Count - 1);
            list.Add('R');
            currList = Find(root.right, target, list);
            if (currList == null)
                list.RemoveAt(list.Count - 1);
        }

        return currList;
    }
}