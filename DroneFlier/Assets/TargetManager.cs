using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    private LandingPadColumn[] columns;
    private Color targetColor;
    private int targetNumber;

    private void Start()
    {
        columns = GetComponentsInChildren<LandingPadColumn>();
        CreateNewTarget();
        Debug.Log("target: " + targetColor.ToString() + " - " + targetNumber);
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
    }

    public bool CheckMatch(LandingPad landingPad)
    {
        return landingPad.GetPadColor() == targetColor && landingPad.GetPadNumber() == targetNumber;
    }
}
