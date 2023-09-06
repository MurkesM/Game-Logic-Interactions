using UnityEngine;

public class ShootInput : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;

    private LayerMask mask;

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

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            if (hit.transform.TryGetComponent<AI>(out AI ai))
                ai .KillAI();
    }
}