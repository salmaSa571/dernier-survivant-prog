using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Fonction appel�e lorsque le bouton "Play" est cliqu�
    public void PlayGame()
    {
        // Charger la sc�ne de jeu
        SceneManager.LoadScene("intro");
    }

    // Fonction pour quitter le jeu (optionnelle)
    public void QuitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit();
    }
}
