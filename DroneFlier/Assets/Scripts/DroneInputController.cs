using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DroneInputController : MonoBehaviour
{
    private int fanMask = 0;
    private bool allFansShortcut = false;
    public bool MoveForwards;
    public bool MoveBackwards;
    public bool MoveLeft;
    public bool MoveRight;
    public bool MoveUp;
    public bool MoveDown;
    [SerializeField]
    private UIManager uiManager;

    private void Awake()
    {
        uiManager.SetFansOutOfUse();
    }

    public void OnFrontLeftFan(InputValue value)
    {
        if (!allFansShortcut)
        {
            setFanMaskBit(DroneFans.FRONT_LEFT_FAN, value.isPressed);
            determineMovement();
        }
    }

    public void OnFrontRightFan(InputValue value)
    {
        if (!allFansShortcut)
        {
            setFanMaskBit(DroneFans.FRONT_RIGHT_FAN, value.isPressed);
            determineMovement();
        }
    }

    public void OnBackLeftFan(InputValue value)
    {
        if (!allFansShortcut)
        {
            setFanMaskBit(DroneFans.BACK_LEFT_FAN, value.isPressed);
            determineMovement();
        }
    }

    public void OnBackRightFan(InputValue value)
    {
        if (!allFansShortcut)
        {
            setFanMaskBit(DroneFans.BACK_RIGHT_FAN, value.isPressed);
            determineMovement();
        }
    }

    public void OnAllFans(InputValue value)
    {
        if (value.isPressed)
        {
            fanMask = DroneFans.GetUpValue();
            allFansShortcut = true;
        }
        else if (fanMask == DroneFans.GetUpValue())
        {
            fanMask = 0;
            allFansShortcut = false;
        }
        determineMovement();
    }

    private void setFanMaskBit(int bitToSet, bool isFanOn)
    {
        clearFanMaskBit(bitToSet);
        int fanValue = getFanOnValue(isFanOn, bitToSet);
        fanMask = fanMask | fanValue;
    }

    private void clearFanMaskBit(int bitToClear)
    {
        fanMask = fanMask & ~bitToClear;
    }

    private int getFanOnValue(bool isPressed, int maskValue)
    {
        int fanOnValue = 0;
        if (isPressed)
        {
            fanOnValue = maskValue;
        }
        return fanOnValue;
    }

    private void determineMovement()
    {
        resetAllValues();
        if (DroneFans.IsValidCombination(fanMask))
        {
            uiManager.SetFanValid(fanMask);
        }
        else if (fanMask == 0)
        {
            uiManager.SetFansOutOfUse();
        }
        else
        {
            uiManager.SetFanInvalid(fanMask);
        }
        if (fanMask == DroneFans.GetUpValue())
        {
            MoveUp = true;
        }
        else if (fanMask == DroneFans.GetForwardValue())
        {
            MoveForwards = true;
        }
        else if (fanMask == DroneFans.GetBackwardValue())
        {
            MoveBackwards = true;
        }
        else if (fanMask == DroneFans.GetLeftValue())
        {
            MoveLeft = true;
        }
        else if (fanMask == DroneFans.GetRightValue())
        {
            MoveRight = true;
        }
        else
        {
            MoveDown = true;
        }
    }

    private void resetAllValues()
    {
        MoveUp = false;
        MoveForwards = false;
        MoveBackwards = false;
        MoveLeft = false;
        MoveRight = false;
        MoveDown = false;
    }
}
