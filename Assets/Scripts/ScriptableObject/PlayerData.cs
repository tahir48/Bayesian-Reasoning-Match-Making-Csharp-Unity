
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayer", menuName = "Player", order = 0)]
public class PlayerData : ScriptableObject
{
    public string playerName;
    public double skillLevel;

    public int wins;
    public int losses;
    public float winRate => (wins + losses > 0) ? (float)wins / (wins + losses) : 0;

    public void UpdateStats(bool wonGame, double skillDifference)
    {
        wins += wonGame ? 1 : 0;
        losses += wonGame ? 0 : 1;

        double adjustedSkillDifference = skillDifference;
        if (wonGame)
        {
            if (skillDifference < 0)
            {
                adjustedSkillDifference = -skillDifference;
            }
        }

        if (!wonGame)
        {
            if (skillDifference > 0)
            {
                adjustedSkillDifference = -skillDifference;
            }
        }

        double likelihood = CalculateLikelihood(adjustedSkillDifference);

        skillLevel = BayesCalculator.CalculatePosterior(skillLevel, likelihood, 0.5);
        if (playerName == "macbeth")
        {
            Debug.Log(playerName + "   " + skillLevel + " won  " + wonGame);
        }
    }

    private double CalculateLikelihood(double skillDifference)
    {
        return 1 / (1 + Mathf.Exp((float)-skillDifference));
    }



}


