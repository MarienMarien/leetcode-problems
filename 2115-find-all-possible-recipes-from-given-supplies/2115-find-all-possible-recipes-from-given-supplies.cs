public class Solution {
    public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies) {
        var graph = new Dictionary<string, ISet<string>>();
        var indegree = new Dictionary<string, int>();

        for(var i = 0; i < recipes.Length; i++)
        {
            var product = recipes[i];
            indegree.Add(product, 0);

            foreach(var ingr in ingredients[i])
            {
                if(!graph.ContainsKey(ingr))
                    graph.Add(ingr, new HashSet<string>());
                graph[ingr].Add(product);

                indegree[product] += 1;
            }
        }

        var recipesSet = new HashSet<string>(recipes);
        var q = new Queue<string>();
        foreach(var suppl in supplies)
        {
            q.Enqueue(suppl);
        }

        var answer = new List<string>();
        while(q.Count > 0)
        {
            var curr = q.Dequeue();
            if(recipesSet.Contains(curr))
                answer.Add(curr);
            if(!graph.ContainsKey(curr))
                continue;
                
            foreach(var it in graph[curr])
            {
                if(!indegree.ContainsKey(it))
                    continue;
                 indegree[it]--;
                 if(indegree[it] == 0)
                 {
                    q.Enqueue(it);
                 }
            }
        }

        return answer;
    }
}