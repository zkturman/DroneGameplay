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
    [SerializeField]
    private RectTransform frontLeftFanPanel;
    [SerializeField]
    private RectTransform frontRightFanPanel;
    [SerializeField]
    private RectTransform backLeftFanPanel;
    [SerializeField]
    private RectTransform backRightFanPanel;

    [SerializeField]
    private Color validFanColor = Color.green;
    [SerializeField]
    private Color invalidFanColor = Color.red;
    [SerializeField]
    private Color outOfUseFanColor = Color.gray;
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

    public void SetFanValid(int fanBitMask)
    {
        SetFansOutOfUse();
        if ((fanBitMask & DroneFans.FRONT_LEFT_FAN) == DroneFans.FRONT_LEFT_FAN)
        {
            setFanColor(DroneFans.FRONT_LEFT_FAN, validFanColor);
        }
        if ((fanBitMask & DroneFans.FRONT_RIGHT_FAN) == DroneFans.FRONT_RIGHT_FAN)
        {
            setFanColor(DroneFans.FRONT_RIGHT_FAN, validFanColor);
        }
        if ((fanBitMask & DroneFans.BACK_LEFT_FAN) == DroneFans.BACK_LEFT_FAN)
        {
            setFanColor(DroneFans.BACK_LEFT_FAN, validFanColor);
        }
        if ((fanBitMask & DroneFans.BACK_RIGHT_FAN) == DroneFans.BACK_RIGHT_FAN)
        {
            setFanColor(DroneFans.BACK_RIGHT_FAN, validFanColor);
        }
    }

    public void SetFanInvalid(int fanBitMask)
    {
        SetFansOutOfUse();
        if ((fanBitMask & DroneFans.FRONT_LEFT_FAN) == DroneFans.FRONT_LEFT_FAN)
        {
            setFanColor(DroneFans.FRONT_LEFT_FAN, invalidFanColor);
        }
        if ((fanBitMask & DroneFans.FRONT_RIGHT_FAN) == DroneFans.FRONT_RIGHT_FAN)
        {
            setFanColor(DroneFans.FRONT_RIGHT_FAN, invalidFanColor);
        }
        if ((fanBitMask & DroneFans.BACK_LEFT_FAN) == DroneFans.BACK_LEFT_FAN)
        {
            setFanColor(DroneFans.BACK_LEFT_FAN, invalidFanColor);
        }
        if ((fanBitMask & DroneFans.BACK_RIGHT_FAN) == DroneFans.BACK_RIGHT_FAN)
        {
            setFanColor(DroneFans.BACK_RIGHT_FAN, invalidFanColor);
        }
    }

    public void SetFansOutOfUse()
    {
        setFanColor(DroneFans.FRONT_LEFT_FAN, outOfUseFanColor);
        setFanColor(DroneFans.FRONT_RIGHT_FAN, outOfUseFanColor);
        setFanColor(DroneFans.BACK_LEFT_FAN, outOfUseFanColor);
        setFanColor(DroneFans.BACK_RIGHT_FAN, outOfUseFanColor);
    }

    private void setFanColor(int fanBitValue, Color colorToSet)
    {
        if (fanBitValue == DroneFans.FRONT_LEFT_FAN)
        {
            frontLeftFanPanel.GetComponent<Image>().color = colorToSet;
        }
        else if (fanBitValue == DroneFans.FRONT_RIGHT_FAN)
        {
            frontRightFanPanel.GetComponent<Image>().color = colorToSet;
        }
        else if (fanBitValue == DroneFans.BACK_LEFT_FAN)
        {
            backLeftFanPanel.GetComponent<Image>().color = colorToSet;
        }
        else if (fanBitValue == DroneFans.BACK_RIGHT_FAN)
        {
            backRightFanPanel.GetComponent<Image>().color = colorToSet;
        }
    }
}
