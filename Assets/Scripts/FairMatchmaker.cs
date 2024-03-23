using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class FairMatchmaker : MonoBehaviour
{
    public List<PlayerData> availablePlayers = new List<PlayerData>();

    public void AddPlayer(PlayerData player)
    {
        if (!availablePlayers.Contains(player))
        {
            availablePlayers.Add(player);
            Debug.Log($"Added {player.playerName} to the pool.");
        }
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            CreateAndDisplayFairTeams();
        }
    }

    public void CreateAndDisplayFairTeams()
    {
        if (availablePlayers.Count % 2 != 0)
        {
            Debug.LogWarning("Odd number of players, making teams may not be perfectly fair.");
        }

        var sortedPlayers = availablePlayers.OrderBy(p => p.skillLevel).ToList();

        List<PlayerData> team1 = new List<PlayerData>();
        List<PlayerData> team2 = new List<PlayerData>();

        double team1TotalSkill = 0, team2TotalSkill = 0;

        foreach (var player in sortedPlayers)
        {
            if (team1TotalSkill <= team2TotalSkill)
            {
                team1.Add(player);
                team1TotalSkill += player.skillLevel;
            }
            else
            {
                team2.Add(player);
                team2TotalSkill += player.skillLevel;
            }
        }

        DisplayTeam("Team 1", team1);
        DisplayTeam("Team 2", team2);
    }

    private void DisplayTeam(string teamName, List<PlayerData> team)
    {
        Debug.Log($"{teamName} (Total Skill: {team.Sum(p => p.skillLevel)}):");
        foreach (var player in team)
        {
            Debug.Log($"{player.playerName} - Skill: {player.skillLevel}");
        }
    }
}
