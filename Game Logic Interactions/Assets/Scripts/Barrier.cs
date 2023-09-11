using System.Collections;
using UnityEngine;

public class Barrier : MonoBehaviour, IShootable
{
    public AudioSource audioSource;
    public MeshRenderer meshRenderer;
    public bool canShoot = true;

    public void Hit()
    {
        if (!canShoot)
            return;

        canShoot = false;

        audioSource.Play();

        //turn off barrier
        meshRenderer.enabled = false;

        StartCoroutine(CoolDownRoutine());
    }

    public IEnumerator CoolDownRoutine()
    {
        yield return new WaitForSeconds(2);

        RepairBarrier();
    }

    public void RepairBarrier()
    {
        canShoot = true;

        //turn off barrier
        meshRenderer.enabled = true;
    }

    public void Shot()
    {
        Hit();
    }
}