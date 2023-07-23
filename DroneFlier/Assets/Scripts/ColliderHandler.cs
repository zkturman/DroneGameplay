using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderHandler : MonoBehaviour
{
    [SerializeField]
    private TargetManager targetManager;
    [SerializeField]
    private HealthHandler healthHandler;
    [SerializeField]
    private ScoreHandler scoreHandler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<LandingPad>(out LandingPad currentPad))
        {
            if (targetManager.CheckMatch(currentPad))
            {
                targetManager.CreateNewTarget();
                scoreHandler.IncrementScore();
            }
            else
            {
                healthHandler.ReduceHealth();
            }
        }        
    }
}
