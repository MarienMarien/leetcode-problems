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
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        var rootStr = new StringBuilder();
        StringifyTree(root, rootStr);

        var subrootStr = new StringBuilder();
        StringifyTree(subRoot, subrootStr);

        return IsSubtree(rootStr.ToString(), subrootStr.ToString());
    }

    private void StringifyTree(TreeNode node, StringBuilder sb)
    {
        if(node == null)
        {
            sb.Append('#');
            return;
        }

        sb.Append('|');
        sb.Append(node.val);
        StringifyTree(node.left, sb);
        StringifyTree(node.right, sb);
    }

    private bool IsSubtree(string haystack, string needle)
    {
        if(needle.Length > haystack.Length)
            return false;

        var longestBorder = new int[needle.Length];
        longestBorder[0] = 0;
        var needleId = 1;
        var prev = 0;
        while(needleId < needle.Length)
        {
            if(needle[needleId] == needle[prev])
            {
                prev++;
                longestBorder[needleId] = prev;
                needleId++;
                continue;
            }
            if(prev == 0)
            {
                longestBorder[needleId] = 0;
                needleId++;
            } 
            else 
            {
                prev = longestBorder[prev - 1];
            }
        }

        needleId = 0;
        var haystackId = 0;
        while(haystackId < haystack.Length)
        {
            if(haystack[haystackId] == needle[needleId])
            {
                haystackId++;
                needleId++;
                if(needleId == needle.Length)
                {
                    return true;
                }
                continue;
            }

            if(needleId == 0)
            {
                haystackId++;
            } 
            else 
            {
                needleId = longestBorder[needleId - 1];
            }
        }

        return false;
    }
}