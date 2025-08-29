using UnityEngine;
using UnityEngine.AI;

public class enemymove : MonoBehaviour
{
    public Transform ball;
    private NavMeshAgent navMeshAgent;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(ball != null)
        {
            navMeshAgent.SetDestination(ball.position);
        }
        
    }
}
