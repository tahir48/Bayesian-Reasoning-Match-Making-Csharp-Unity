using UnityEngine;

public class GameInitializationManager : MonoBehaviour
{
    private void Awake()
    {
        LoadAllGameOutcomesProcessedState();
    }

    private void LoadAllGameOutcomesProcessedState()
    {
        GameOutcome[] allGameOutcomes = Resources.LoadAll<GameOutcome>("GameOutcomes");

        foreach (var gameOutcome in allGameOutcomes)
        {
            gameOutcome.LoadProcessedState();
        }
    }
}
