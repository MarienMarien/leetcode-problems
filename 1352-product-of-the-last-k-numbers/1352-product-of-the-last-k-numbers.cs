public class ProductOfNumbers {
    private IList<int> _products;
    public ProductOfNumbers() {
        _products = new List<int>();
    }
    
    public void Add(int num) {
        if(num == 0)
        {
            _products = new List<int>();
            return;
        }
        var newProduct = _products.Count == 0 ? num : _products[^1] * num;
        _products.Add(newProduct);
    }
    
    public int GetProduct(int k) {
        if(_products.Count < k)
            return 0;
        var divisor = 1;
        if(k < _products.Count)
        {
            var extra = _products.Count - 1 - k;
            divisor = _products[extra];
        }
        
        return _products[^1] / divisor;
    }
}

/**
 * Your ProductOfNumbers object will be instantiated and called as such:
 * ProductOfNumbers obj = new ProductOfNumbers();
 * obj.Add(num);
 * int param_2 = obj.GetProduct(k);
 */