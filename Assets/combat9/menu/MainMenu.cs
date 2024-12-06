using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Fonction appelée lorsque le bouton "Play" est cliqué
    public void PlayGame()
    {
        // Charger la scène de jeu
        SceneManager.LoadScene("intro");
    }

    // Fonction pour quitter le jeu (optionnelle)
    public void QuitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit();
    }
}
