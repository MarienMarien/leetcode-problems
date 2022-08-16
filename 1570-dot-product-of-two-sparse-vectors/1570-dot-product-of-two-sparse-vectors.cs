public class SparseVector {
    public int[] Nums { get; set; }
    
    public SparseVector(int[] nums) {
        Nums = nums;
    }
    
    // Return the dotProduct of two sparse vectors
    public int DotProduct(SparseVector vec) {
        var res = 0;
        for(var i = 0; i < Nums.Length; i++){
            if(i >= vec.Nums.Length)
                break;
            res += vec.Nums[i] * Nums[i];
        }
        return res;
    }
}

// Your SparseVector object will be instantiated and called as such:
// SparseVector v1 = new SparseVector(nums1);
// SparseVector v2 = new SparseVector(nums2);
// int ans = v1.DotProduct(v2);