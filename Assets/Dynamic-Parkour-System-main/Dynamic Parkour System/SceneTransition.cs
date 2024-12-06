using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; // N�cessaire pour g�rer les sc�nes

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private string nextSceneName; // Nom de la prochaine sc�ne
    //[SerializeField] private Vector3 playerSpawnPosition; // Position o� le joueur appara�tra dans la nouvelle sc�ne

    private void OnTriggerEnter(Collider other)
    {
        // V�rifier si l'objet qui entre en collision est le joueur
        if (other.CompareTag("Player"))
        {
            //// Sauvegarder la position o� le joueur doit appara�tre
            //PlayerPrefs.SetFloat("SpawnX", playerSpawnPosition.x);
            //PlayerPrefs.SetFloat("SpawnY", playerSpawnPosition.y);
            //PlayerPrefs.SetFloat("SpawnZ", playerSpawnPosition.z);

            // Charger la prochaine sc�ne
            SceneManager.LoadScene(nextSceneName);

            //FindObjectOfType<GameTimer>().PlayerWins();
        }
    }
}

