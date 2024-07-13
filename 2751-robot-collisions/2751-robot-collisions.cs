public class Solution {
    public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions) {
        var sorted = new (int position, int health, char direction, int priority)[positions.Length];
        for (var i = 0; i < positions.Length; i++)
        {
            sorted[i] = (positions[i], healths[i], directions[i], i);
        }

        Array.Sort(sorted, Comparer<(int position, int health, char direction, int priority)>.Create((x,y) => x.position - y.position));

        var stack = new Stack<(int position, int health, char direction, int priority)>();
        for(var i = 0; i < sorted.Length; i++)
        {
            var curr = sorted[i];
            if (stack.Count == 0)
            {
                stack.Push(curr);
                continue;
            }

            var prevPreview = stack.Peek();
            if (prevPreview.direction != curr.direction && prevPreview.direction == 'R')
            {
                var prev = stack.Pop();

                if (prev.health > curr.health)
                {
                    prev.health--;
                    stack.Push(prev);
                }
                else if (prev.health < curr.health)
                {
                    while (stack.Count > 0 && prev.health < curr.health && prev.direction != curr.direction)
                    {
                        curr.health--;
                        prev = stack.Pop();
                    }

                    if (prev.direction == curr.direction)
                    {
                        stack.Push(prev);
                        stack.Push(curr);
                        continue;
                    }

                    if (prev.health < curr.health)
                    {
                        curr.health--;
                        stack.Push(curr);
                    }
                    else if(prev.health > curr.health)
                    {
                        prev.health--;
                        stack.Push(prev);
                    }

                }
                // if health eq, then nothing added
            }
            else
            {
                stack.Push(curr);
            }
        }

        var pq = new PriorityQueue<(int position, int health, char direction, int priority),int>();

        while (stack.Count > 0)
        {
            var curr = stack.Pop();
            pq.Enqueue(curr, curr.priority);
        }

        var res = new List<int>();
        while (pq.Count > 0)
        {
            res.Add(pq.Dequeue().health);
        }

        return res;
    }
}