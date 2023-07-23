using UnityEngine;

public class DroneInputHandler : MonoBehaviour
{
    [SerializeField]
    private DroneInputController controller;
    [SerializeField]
    private Rigidbody droneBody;
    [SerializeField]
    private float upwardForce = 2f;

    
    void Start()
    {
        if (controller == null)
        {
            controller = GetComponent<DroneInputController>();
        }
    }

    void Update()
    {
        if (controller.MoveUp)
        {
            droneBody.AddForce(upwardForce * transform.up);
        }
    }
}
