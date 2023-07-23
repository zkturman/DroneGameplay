using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField]
    private int goalScore;
    private int currentScore = 0;
    [SerializeField]
    private UIManager uiManager;

    private void Awake()
    {
        uiManager.SetScore(currentScore);
    }

    public void IncrementScore()
    {
        currentScore++;
        uiManager.SetScore(currentScore);
        if (currentScore == goalScore)
        {
            Debug.Log("You win!"); 
        }
    }
}
