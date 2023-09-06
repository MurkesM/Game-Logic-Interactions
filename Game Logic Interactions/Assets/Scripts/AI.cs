using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;
    public float moveSpeed = 5;

    private bool isAtHidePoint = false;
    public float timeArrivedAtHidePoint;
    public float randomHideTime;

    public bool canKill = true;

    private void Start()
    {
        EnemyDataManager.IncrementEnemyCount();

        agent.destination = AIPointManager.Instance.GetUniqueHidePoint().position;

        randomHideTime = Random.Range(2, 5);

        SetRunAnim(true);
    }

    private void Update()
    {
        if (Mathf.Approximately(agent.remainingDistance, 0) && !isAtHidePoint)
        {
            isAtHidePoint = true;
            timeArrivedAtHidePoint = Time.time;

            SetRunAnim(false);
            SetHideAnim(true);
        }
            
        if (isAtHidePoint)
        {
            if (Time.time < timeArrivedAtHidePoint + randomHideTime)
                return;

            agent.destination = AIPointManager.Instance.endPoint.position;
            isAtHidePoint = false;
        }
        else
        {
            SetHideAnim(false);
            SetRunAnim(true);
        }
    }

    private void SetRunAnim(bool run)
    {
        if (run)
        {
            animator.SetFloat("Speed", moveSpeed);
            return;
        }

        animator.SetFloat("Speed", 0);
    }

    private void SetHideAnim(bool hide)
    {
        animator.SetBool("Hiding", hide);
    }

    public void KillAI()
    {
        if (!canKill)
            return;

        canKill = false;

        EnemyDataManager.DecrementEnemyCount();

        PlayerPointsManager.AddPoints(50);

        agent.speed = 0;

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