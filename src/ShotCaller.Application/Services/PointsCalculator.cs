namespace ShotCaller.Application.Services;

public static class PointsCalculator
{
    public static int Calculate(int predictedHome, int predictedAway, int actualHome, int actualAway)
    {
        // Exakt resultat = 3 poäng
        if (predictedHome == actualHome && predictedAway == actualAway)
            return 3;

        // Rätt utgång (vinnare eller oavgjort) = 1 poäng
        if (GetOutcome(predictedHome, predictedAway) == GetOutcome(actualHome, actualAway))
            return 1;

        // Fel = 0 poäng
        return 0;
    }

    private static int GetOutcome(int home, int away)
    {
        if (home > away) return 1;   // hemmaseger
        if (home < away) return -1;  // bortaseger
        return 0;                    // oavgjort
    }
}