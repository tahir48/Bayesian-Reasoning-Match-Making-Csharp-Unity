using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Matchmaker : MonoBehaviour
{
    [SerializeField] public int team1Size;
    [SerializeField] public int team2Size;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            CreateAndDisplayTeams(team1Size, team2Size);

        }
    }
    public void CreateAndDisplayTeams(int team1Size, int team2Size)
    {
        PlayerData[] allPlayers = Resources.LoadAll<PlayerData>("PlayerData");

        var sortedPlayers = allPlayers.OrderBy(p => p.skillLevel).ToList();

        List<PlayerData> team1 = new List<PlayerData>();
        List<PlayerData> team2 = new List<PlayerData>();

        double team1TotalSkill = 0, team2TotalSkill = 0;

        foreach (var player in sortedPlayers)
        {
            bool canAddToTeam1 = team1.Count < team1Size;
            bool canAddToTeam2 = team2.Count < team2Size;

            if (canAddToTeam1 && (team1TotalSkill <= team2TotalSkill || !canAddToTeam2))
            {
                team1.Add(player);
                team1TotalSkill += player.skillLevel;
            }
            else if (canAddToTeam2)
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
        Debug.Log(teamName + ":");
        foreach (var player in team)
        {
            Debug.Log(player.playerName + " - Skill: " + player.skillLevel);
        }
    }
}
