using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public Transform startTransform;
    public Transform endTransform;
    public NavMeshAgent agent;

    private void Awake()
    {
        transform.position = startTransform.position;
        agent.destination = endTransform.position;
    }
}