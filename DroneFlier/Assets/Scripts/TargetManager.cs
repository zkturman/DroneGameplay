using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField]
    private UIManager uiManager;
    private LandingPadColumn[] columns;
    private Color targetColor;
    private int targetNumber;

    private void Start()
    {
        columns = GetComponentsInChildren<LandingPadColumn>();
        CreateNewTarget();
    }

    public void CreateNewTarget()
    {
        int diceRoll;
        int numberOfColumns = columns.Length;
        diceRoll = Random.Range(0, numberOfColumns);
        LandingPadColumn targetColumn = columns[diceRoll];
        int numberOfPads = targetColumn.PadCount();
        diceRoll = Random.Range(0, numberOfPads);
        targetColor = targetColumn.GetPadColor(diceRoll);
        targetNumber = targetColumn.GetPadNumber(diceRoll);
        uiManager.SetLandingPadColor(targetColor);
        uiManager.SetLandingPadNumber(targetNumber);
    }

    public bool CheckMatch(LandingPad landingPad)
    {
        return landingPad.GetPadColor() == targetColor && landingPad.GetPadNumber() == targetNumber;
    }
}
