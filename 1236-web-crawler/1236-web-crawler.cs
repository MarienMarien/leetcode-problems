/**
 * // This is the HtmlParser's API interface.
 * // You should not implement it, or speculate about its implementation
 * class HtmlParser {
 *     public List<String> GetUrls(String url) {}
 * }
 */

class Solution {
    private ISet<string> _result;
    private string _hostName;
    public IList<string> Crawl(string startUrl, HtmlParser htmlParser) {
        _result = new HashSet<string>() { startUrl };
        var id = "http://".Length;
        while (id < startUrl.Length && startUrl[id] != '/'){
            id++;
        }
        _hostName = startUrl[0..id];
        FindUrls(startUrl, htmlParser);
        return _result.ToList();
    }

    private void FindUrls(string startUrl, HtmlParser htmlParser)
    {
        var urls = htmlParser.GetUrls(startUrl);
        foreach (var url in urls) {
            if (url.StartsWith(_hostName)) {
                if (!_result.Contains(url)) { 
                    _result.Add(url);
                    FindUrls(url, htmlParser);
                }
            }
        } 
    }
}