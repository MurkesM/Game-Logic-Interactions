using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;

    private bool isAtHidePoint = false;
    public float timeArrivedAtHidePoint;
    public float randomHideTime;

    private void Start()
    {
        //set destination to random hide point
        agent.destination = AIPointManager.Instance.GetRandomHidePoint().position;

        randomHideTime = Random.Range(2, 6);
    }

    private void Update()
    {
        if (Mathf.Approximately(agent.remainingDistance, 0) && !isAtHidePoint)
        {
            isAtHidePoint = true;
            timeArrivedAtHidePoint = Time.time;
        }
            
        if (isAtHidePoint && agent.destination != AIPointManager.Instance.endPoint.position)
        {
            if (Time.time < timeArrivedAtHidePoint + randomHideTime)
                return;

            animator.SetBool("Hiding", true);

            agent.destination = AIPointManager.Instance.endPoint.position;
        }
        else
        {
            animator.SetBool("Hiding", false);
        }
    }

    public void KillAI()
    {
        PlayerPointsManager.AddPoints(50);

        animator.SetTrigger("Death");
    }

    /// <summary>
    /// This will be called from an animation event when the end of the death animation is reached.
    /// </summary>
    public void OnDeathAnimFinished()
    {
        Destroy(this.gameObject);
    }
}