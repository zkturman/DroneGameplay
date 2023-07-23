using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneFanController : MonoBehaviour
{
    [SerializeField]
    private Animator frontLeftFan;
    [SerializeField]
    private Animator frontRightFan;
    [SerializeField]
    private Animator backLeftFan;
    [SerializeField]
    private Animator backRightFan;
    [SerializeField]
    private Transform droneModel;
    [SerializeField]
    private float rotationAmount = 20f;

    public void SetAllFans()
    {
        frontLeftFan.enabled = true;
        frontRightFan.enabled = true;
        backLeftFan.enabled = true;
        backRightFan.enabled = true;
        setModelRotation(Vector3.zero);
    }

    public void SetForwardFans()
    {
        stopAllFanRotation();
        backLeftFan.enabled = true;
        backRightFan.enabled = true;
        Vector3 modelRotation = new Vector3(rotationAmount, 0f, 0f);
        setModelRotation(modelRotation);
    }

    public void SetBackwardFans()
    {
        stopAllFanRotation();
        frontLeftFan.enabled = true;
        frontRightFan.enabled = true;
        Vector3 modelRotation = new Vector3(-rotationAmount, 0f, 0f);
        setModelRotation(modelRotation);
    }

    public void SetLeftFans()
    {
        stopAllFanRotation();
        frontRightFan.enabled = true;
        backRightFan.enabled = true;
        Vector3 modelRotation = new Vector3(0f, 0f, rotationAmount);
        setModelRotation(modelRotation);
    }

    public void SetRightFans()
    {
        stopAllFanRotation();
        frontLeftFan.enabled = true;
        backLeftFan.enabled = true;
        Vector3 modelRotation = new Vector3(0f, 0f, -rotationAmount);
        setModelRotation(modelRotation);
    }

    public void StopAllFans()
    {
        stopAllFanRotation();
        setModelRotation(Vector3.zero);
    }

    private void stopAllFanRotation()
    {
        frontLeftFan.enabled = false;
        frontRightFan.enabled = false;
        backLeftFan.enabled = false;
        backRightFan.enabled = false;
    }

    private void setModelRotation(Vector3 rotationToSet)
    {
        droneModel.rotation = Quaternion.Euler(rotationToSet);
    }
}
