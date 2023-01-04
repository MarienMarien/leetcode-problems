public class Solution {
    public int MinimumRounds(int[] tasks) {
        if (tasks.Length < 2)
            return -1;
        Array.Sort(tasks);
        var currTask = tasks[0];
        var tasksByTypeCount = 0;
        var rounds = 0;
        foreach (var t in tasks) {
            if (t == currTask) {
                tasksByTypeCount++;
                continue;
            }
            if (tasksByTypeCount == 1)
                return -1;
            rounds += CountRounds(tasksByTypeCount);
            currTask = t;
            tasksByTypeCount = 1;
        }
        if (tasksByTypeCount == 1)
            return -1;
        rounds += CountRounds(tasksByTypeCount);
        return rounds;
    }

    private int CountRounds(int tasksCount) {
        var rounds = 0;
        var extra = tasksCount % 3;
        switch (extra)
        {
            case 1:
                rounds += 2;
                tasksCount -= 2 * 2;
                break;
            case 2:
                rounds++;
                tasksCount -= extra;
                break;
            default:
                break;
        }
        rounds += tasksCount / 3;
        return rounds;
    }
}