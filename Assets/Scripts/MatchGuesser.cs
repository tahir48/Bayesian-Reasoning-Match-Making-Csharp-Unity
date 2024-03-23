using System.Linq;
using UnityEngine;

public class MatchGuesser : MonoBehaviour
{
    public PlayerData[] team1Players;
    public PlayerData[] team2Players;

    private void Start()
    {
        GuessWinner();
    }
    public void GuessWinner()
    {
        double team1AverageSkill = CalculateAverageSkill(team1Players);
        double team2AverageSkill = CalculateAverageSkill(team2Players);

        if (team1AverageSkill == team2AverageSkill)
        {
            Debug.LogError("The match is too close to call!");
        }
        else if (team1AverageSkill > team2AverageSkill)
        {
            Debug.LogError("Team 1 is predicted to win!");
        }
        else
        {
            Debug.LogError("Team 2 is predicted to win!");
        }
    }

    private double CalculateAverageSkill(PlayerData[] players)
    {
        if (players.Length == 0) return 0;
        double totalSkill = players.Sum(player => player.skillLevel);
        return totalSkill / players.Length;
    }
}
