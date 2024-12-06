using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; // Nécessaire pour gérer les scènes

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private string nextSceneName; // Nom de la prochaine scène
    //[SerializeField] private Vector3 playerSpawnPosition; // Position où le joueur apparaîtra dans la nouvelle scène

    private void OnTriggerEnter(Collider other)
    {
        // Vérifier si l'objet qui entre en collision est le joueur
        if (other.CompareTag("Player"))
        {
            //// Sauvegarder la position où le joueur doit apparaître
            //PlayerPrefs.SetFloat("SpawnX", playerSpawnPosition.x);
            //PlayerPrefs.SetFloat("SpawnY", playerSpawnPosition.y);
            //PlayerPrefs.SetFloat("SpawnZ", playerSpawnPosition.z);

            // Charger la prochaine scène
            SceneManager.LoadScene(nextSceneName);

            //FindObjectOfType<GameTimer>().PlayerWins();
        }
    }
}

