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
        if (GameManager.Instance.gameOver)
            return;

        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    private void Shoot()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        audioSource.Play();

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            if (hit.transform.TryGetComponent<IShootable>(out IShootable shootable))
                shootable.Shot();
    }
}