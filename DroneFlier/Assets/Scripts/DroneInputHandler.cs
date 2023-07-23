using UnityEngine;

public class DroneInputHandler : MonoBehaviour
{
    [SerializeField]
    private DroneInputController controller;
    [SerializeField]
    private Rigidbody droneBody;
    [SerializeField]
    private float upwardForce = 10f;
    [SerializeField]
    private float planarForce = 8f;
    [SerializeField]
    private DroneFanController fanOperator;

    
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
            droneBody.useGravity = true;
            fanOperator.SetAllFans();
        }
        else if (controller.MoveForwards)
        {
            applyPlanarForce(transform.forward);
            fanOperator.SetForwardFans();
        }
        else if (controller.MoveBackwards)
        {
            applyPlanarForce(transform.forward * -1);
            fanOperator.SetBackwardFans();
        }
        else if (controller.MoveLeft)
        {
            applyPlanarForce(transform.right * -1);
            fanOperator.SetLeftFans();
        }
        else if (controller.MoveRight)
        {
            applyPlanarForce(transform.right);
            fanOperator.SetRightFans();
        }
        else
        {
            droneBody.useGravity = true;
            fanOperator.StopAllFans();
        }
    }

    private void clearDroneVerticalForce()
    {
        Vector3 planarVelocity = new Vector3(droneBody.velocity.x / 2, 0f, droneBody.velocity.z / 2);
        droneBody.velocity = planarVelocity;
        Vector3 planarAngularVelocity = new Vector3(droneBody.angularVelocity.x / 2, 0f, droneBody.angularVelocity.z / 2);
        droneBody.angularVelocity = planarAngularVelocity;
    }

    private void applyPlanarForce(Vector3 forceDirection)
    {
        if (droneBody.velocity.y != 0)
        {
            clearDroneVerticalForce();
        }
        droneBody.AddForce(planarForce * forceDirection);
        droneBody.useGravity = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(new Ray(transform.position, transform.forward));
    }
}
