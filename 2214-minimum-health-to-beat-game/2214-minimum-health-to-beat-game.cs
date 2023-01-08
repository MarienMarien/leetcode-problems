public class Solution {
    public long MinimumHealth(int[] damage, int armor) {
        var maxDamage = 0;
        long healthNeeded = 1;
        foreach (var d in damage) {
            healthNeeded += d;
            maxDamage = Math.Max(maxDamage, d);
        }
        if (armor > 0) {
            var protect = armor >= maxDamage ? maxDamage : armor;
            healthNeeded -= protect;
        }
        return healthNeeded;
    }
}