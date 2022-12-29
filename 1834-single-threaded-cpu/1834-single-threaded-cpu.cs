public class Solution {
    public int[] GetOrder(int[][] tasks) {
        var tasksArr = new CustomTask[tasks.Length];
        for (var i = 0; i < tasks.Length; i++)
        {
            tasksArr[i] = new CustomTask(i, tasks[i][0], tasks[i][1]);
        }
        Array.Sort(tasksArr, Comparer<CustomTask>.Create((x, y) => {
            return x.EnqueueTime == y.EnqueueTime ? x.ProcessingTime - y.ProcessingTime : x.EnqueueTime - y.EnqueueTime;
        }));
        var res = new int[tasks.Length];
        var heap = new SortedSet<CustomTask>(Comparer<CustomTask>.Create((x, y) => {
            return x.ProcessingTime == y.ProcessingTime? x.TaskId - y.TaskId : x.ProcessingTime - y.ProcessingTime;
        }));
        var time = 0;
        var resId = 0;
        var tasksArrId = 0;
        while (resId < tasks.Length) {
            while (tasksArrId < tasksArr.Length && tasksArr[tasksArrId].EnqueueTime <= time) {
                heap.Add(tasksArr[tasksArrId]);
                tasksArrId++;
            }
            if (heap.Count > 0)
            {
                var min = heap.Min;
                heap.Remove(min);
                res[resId] = min.TaskId;
                resId++;
                time += min.ProcessingTime;
            }
            else {
                time = tasksArr[tasksArrId].EnqueueTime;
            }
        }
        return res;
    }

    private class CustomTask {
            public int TaskId;
            public int EnqueueTime;
            public int ProcessingTime;
            public CustomTask(int taskId = 0, int enqueueTime = 0, int processingTime = 0)
            {
                TaskId = taskId;
                EnqueueTime = enqueueTime;
                ProcessingTime = processingTime;
            }
        }
}