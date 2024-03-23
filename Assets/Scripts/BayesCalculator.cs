using System;

public class BayesCalculator
{
    public static double CalculatePosterior(double prior, double likelihood, double totalEvidence)
    {
        double posterior = (likelihood * prior) / totalEvidence;
        return posterior;
    }
}
