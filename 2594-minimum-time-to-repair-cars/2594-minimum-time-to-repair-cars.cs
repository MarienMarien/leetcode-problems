public class Solution {
    public long RepairCars(int[] ranks, int cars) {
        long maxMinutes = 1L * ranks[0] * cars * cars;
        long minMinutes = 1;
        long minTime = 0;
        while(minMinutes < maxMinutes)
        {
            long time = (maxMinutes + minMinutes) / 2;
            if(CanRepair(ranks, cars, time))
            {
                
                maxMinutes = time;
            }
            else 
            {
                minMinutes = time + 1;
                minTime = minMinutes;
            }
        }

        return minMinutes;
    }

    private bool CanRepair(int[] ranks, int cars, long time)
    {
        long carsRepairedInTime = 0;
        foreach(var r in ranks)
        {
            carsRepairedInTime += (long)Math.Sqrt((1.0 * time )/ r);
        }
        return carsRepairedInTime >= cars;
    }
}