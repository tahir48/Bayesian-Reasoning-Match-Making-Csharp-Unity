using System.IO;
using UnityEngine;

public class GameOutcomeProcessor : MonoBehaviour
{
    private void Start()
    {
        ProcessAllGameOutcomes();
    }

    private void ProcessAllGameOutcomes()
    {
        GameOutcome[] allGameOutcomes = Resources.LoadAll<GameOutcome>("GameOutcomes");

        foreach (var gameOutcome in allGameOutcomes)
        {
            if (!gameOutcome.isProcessed)
            {
                gameOutcome.UpdatePlayerStats();
            }
        }

    }

}