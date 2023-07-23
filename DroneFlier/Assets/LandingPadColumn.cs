using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingPadColumn : MonoBehaviour
{
    private LandingPad[] landingPads;

    private void Awake()
    {
        landingPads = GetComponentsInChildren<LandingPad>();
    }
    public int PadCount()
    {
        return landingPads.Length;
    }

    public int GetPadNumber(int index)
    {
        return landingPads[index].GetPadNumber();
    }

    public Color GetPadColor(int index)
    {
        return landingPads[index].GetPadColor();
    }
}
