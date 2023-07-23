using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LandingPad : MonoBehaviour
{
    [SerializeField]
    private int padNumber = 0;
    [SerializeField]
    private Color padColor = Color.white;
    [SerializeField]
    private TextMeshProUGUI meshLabel;
    [SerializeField]
    private GameObject padModel;
    private Material padMaterial;

    // Start is called before the first frame update
    void Awake()
    {
        meshLabel.text = padNumber.ToString();
        MeshRenderer padRenderer = padModel.GetComponent<MeshRenderer>();
        Material padMaterial = new Material(padRenderer.material);
        padMaterial.color = padColor;
        padRenderer.material = padMaterial;
    }

    public Color GetPadColor()
    {
        return padColor;
    }

    public int GetPadNumber()
    {
        return padNumber;
    }
}
