using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDoorAfterDelay : MonoBehaviour
//{
//    public float delay = 5f; // Temps en secondes avant la destruction

//    void Start()
//    {
//        // D�truit cet objet (la porte) apr�s le d�lai
//        Destroy(gameObject, delay);
//    }
//}
{
    public float delay = 5f; // Temps avant la destruction
    public AudioClip destroySound; // Son � jouer lors de la destruction
    private AudioSource audioSource;

    void Start()
    {
        // R�cup�re ou ajoute un AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Lance la destruction apr�s le d�lai
        StartCoroutine(DestroyAfterDelay());
    }

    private IEnumerator DestroyAfterDelay()
    {
        // Attend le d�lai sp�cifi�
        yield return new WaitForSeconds(delay);

        // Joue le son
        if (destroySound != null && audioSource != null)
        {
            audioSource.PlayOneShot(destroySound);
        }

        // Attend la fin du son avant de d�truire
        yield return new WaitForSeconds(destroySound.length);

        // D�truit l'objet (la porte)
        Destroy(gameObject);

    }
}
