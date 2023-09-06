using UnityEngine;

public class ShootInput : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;

    private LayerMask mask;

    public AudioSource audioSource;

    private void Awake()
    {
        mask = LayerMask.GetMask("Shootable");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    private void Shoot()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        audioSource.Play();

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
        {
            if (hit.transform.TryGetComponent<AI>(out AI ai))
                ai.KillAI();

            else if (hit.transform.TryGetComponent<Barrier>(out Barrier barrier))
                barrier.Hit();
        }
    }
}