using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI healthLabel;
    [SerializeField]
    private TextMeshProUGUI scoreLabel;
    [SerializeField]
    private RectTransform targetPadPanel;
    [SerializeField]
    private TextMeshProUGUI targetPadLabel;

    public void SetHealth(int valueToSet)
    {
        healthLabel.text = valueToSet.ToString();
    }

    public void SetScore(int valueToSet)
    {
        scoreLabel.text = valueToSet.ToString();
    }

    public void SetLandingPadColor(Color colorToSet)
    {
        targetPadPanel.GetComponent<Image>().color = colorToSet;
    }

    public void SetLandingPadNumber(int valueToSet)
    {
        targetPadLabel.text = valueToSet.ToString();
    }
}
