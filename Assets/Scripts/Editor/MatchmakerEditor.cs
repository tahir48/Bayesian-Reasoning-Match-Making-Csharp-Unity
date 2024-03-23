using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(Matchmaker))]
public class MatchmakerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); 

        Matchmaker matchmakerScript = (Matchmaker)target;

        if (GUILayout.Button("Create and Display Teams"))
        {
            matchmakerScript.CreateAndDisplayTeams(matchmakerScript.team1Size, matchmakerScript.team2Size);
        }
    }
}
