using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDoorAfterDelay : MonoBehaviour
//{
//    public float delay = 5f; // Temps en secondes avant la destruction

//    void Start()
//    {
//        // Détruit cet objet (la porte) après le délai
//        Destroy(gameObject, delay);
//    }
//}
{
    public float delay = 5f; // Temps avant la destruction
    public AudioClip destroySound; // Son à jouer lors de la destruction
    private AudioSource audioSource;

    void Start()
    {
        // Récupère ou ajoute un AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Lance la destruction après le délai
        StartCoroutine(DestroyAfterDelay());
    }

    private IEnumerator DestroyAfterDelay()
    {
        // Attend le délai spécifié
        yield return new WaitForSeconds(delay);

        // Joue le son
        if (destroySound != null && audioSource != null)
        {
            audioSource.PlayOneShot(destroySound);
        }

        // Attend la fin du son avant de détruire
        yield return new WaitForSeconds(destroySound.length);

        // Détruit l'objet (la porte)
        Destroy(gameObject);

    }
}
