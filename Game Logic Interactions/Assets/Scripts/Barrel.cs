using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour, IShootable
{
    public bool canShoot = true;
    public MeshRenderer meshRenderer;
    public GameObject explodedBarrel;
    public GameObject explosion;

    public List<IShootable> objectsToDamage = new();

    public AudioSource audioSource;

    public void Explode()
    {
        //turn on explosion, 
        explosion.SetActive(true);

        //swap to the exploded barrel
        meshRenderer.enabled = false;
        explodedBarrel.SetActive(true);

        //play explosion sfx
        audioSource.Play();

        //kill all enemies in collider
        foreach (IShootable shootable in objectsToDamage)
            shootable.Shot();
    }

    public void Shot()
    {
        if (!canShoot)
            return;

        canShoot = false;
        
        Explode();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.TryGetComponent<IShootable>(out IShootable shootable))
            objectsToDamage.Add(shootable);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.TryGetComponent<IShootable>(out IShootable shootable))
                return;

        if (!objectsToDamage.Contains(shootable))
            return;

        objectsToDamage.Remove(shootable);
    }
}