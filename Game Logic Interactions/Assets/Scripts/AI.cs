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

    public AudioSource audioSource;

    public AudioClip deathSFX;
    public AudioClip reachedEndSFX;

    public bool headingForEndPoint = false;
    public bool reachedEnd = false;

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
            headingForEndPoint = true;

            isAtHidePoint = false;
        }
        else
        {
            SetHideAnim(false);
            SetRunAnim(true);
        }

        float distanceToEnd = Vector3.Distance(transform.position, AIPointManager.Instance.endPoint.position);

        if (headingForEndPoint && distanceToEnd < 2.5f && !reachedEnd)
        {
            reachedEnd = true;
            headingForEndPoint = false;

            audioSource.clip = reachedEndSFX;
            audioSource.Play();
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

        audioSource.clip = deathSFX;
        audioSource.Play();

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