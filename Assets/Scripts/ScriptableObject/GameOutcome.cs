using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameOutcome", menuName = "Game Outcome", order = 1)]
public class GameOutcome : ScriptableObject
{
    public PlayerData[] team1Players;
    public PlayerData[] team2Players;
    public int winningTeam;
    public bool isProcessed = false;

    public void UpdatePlayerStats()
    {
        double team1AverageSkill = CalculateAverageSkill(team1Players);
        double team2AverageSkill = CalculateAverageSkill(team2Players);
        double skillDifference = team1AverageSkill - team2AverageSkill;

        UpdateTeamStats(team1Players, winningTeam == 1, skillDifference);
        UpdateTeamStats(team2Players, winningTeam == 2, -skillDifference);

        MarkAsProcessed();
    }

    private void UpdateTeamStats(PlayerData[] teamPlayers, bool wonGame, double skillDifference)
    {
        foreach (var player in teamPlayers)
        {
            player.UpdateStats(wonGame, skillDifference);
        }
    }


    private double CalculateAverageSkill(PlayerData[] players)
    {
        if (players.Length == 0) return 0;
        double totalSkill = 0;
        foreach (var player in players)
        {
            totalSkill += player.skillLevel;
        }
        return totalSkill / players.Length;
    }

    public void MarkAsProcessed()
    {
        isProcessed = true;
        PlayerPrefs.SetInt("Processed_" + name, isProcessed ? 1 : 0);
    }

    public void LoadProcessedState()
    {
        isProcessed = PlayerPrefs.GetInt("Processed_" + name, 0) == 1;
    }

}

