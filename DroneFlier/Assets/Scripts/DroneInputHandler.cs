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
        }
        else if (controller.MoveForwards)
        {
            applyPlanarForce(transform.forward);
        }
        else if (controller.MoveBackwards)
        {
            applyPlanarForce(transform.forward * -1);
        }
        else if (controller.MoveLeft)
        {
            applyPlanarForce(transform.right * -1);
        }
        else if (controller.MoveRight)
        {
            applyPlanarForce(transform.right);
        }
        else
        {
            droneBody.useGravity = true;
        }
    }

    private void clearDroneForce()
    {
        droneBody.velocity = Vector3.zero;
        droneBody.angularVelocity = Vector3.zero;
    }

    private void applyPlanarForce(Vector3 forceDirection)
    {
        if (droneBody.velocity.y != 0)
        {
            clearDroneForce();
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
