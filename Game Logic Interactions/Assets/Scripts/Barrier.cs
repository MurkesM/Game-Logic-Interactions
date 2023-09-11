using UnityEngine;

public class Barrier : MonoBehaviour, IShootable
{
    public AudioSource audioSource;

    public void Hit()
    {
        audioSource.Play();
    }

    public void Shot()
    {
        Hit();
    }
}