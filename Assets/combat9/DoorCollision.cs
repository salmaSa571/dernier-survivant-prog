using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Pour g�rer les sc�nes

public class DoorCollision : MonoBehaviour

{
    public string nextSceneName; // Nom de la prochaine sc�ne � charger
    public AudioSource audioSource;



    void OnTriggerEnter(Collider other)
    {
        // V�rifie si c'est le joueur qui entre en collision avec la porte
        if (other.CompareTag("Player"))
        {
            // Charge la sc�ne sp�cifi�e
            SceneManager.LoadScene(nextSceneName);
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}






//public class DoorCollision : MonoBehaviour
//{
//    public string nextSceneName; // Nom de la prochaine sc�ne � charger
//    public GameObject levelImage; // R�f�rence � l'image UI de transition

//    private void OnTriggerEnter(Collider other)
//    {
//        // V�rifie si c'est le joueur qui entre en collision avec la porte
//        if (other.CompareTag("Player"))
//        {
//            StartCoroutine(ShowLevelImageAndLoadScene());
//        }
//    }

//    private IEnumerator ShowLevelImageAndLoadScene()
//    {
//        // Affiche l'image de transition
//        if (levelImage != null)
//        {
//            levelImage.SetActive(true);
//            // Jouer le son de victoire
//            AudioSource audioSource = levelImage.GetComponent<AudioSource>();
//            if (audioSource != null)
//            {
//                audioSource.Play();
//            }
//        }

//        // Attend 2 secondes
//        yield return new WaitForSeconds(2f);

//        // Charge la sc�ne suivante
//        if (!string.IsNullOrEmpty(nextSceneName))
//        {
//            SceneManager.LoadScene(nextSceneName);
//        }
//    }
//}
