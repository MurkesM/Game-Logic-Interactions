using UnityEngine;

public class Barrier : MonoBehaviour
{
    public AudioSource audioSource;

    public void Hit()
    {
        audioSource.Play();
    }
}