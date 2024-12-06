using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private float gameDuration = 60f; // Dur�e du jeu en secondes
    [SerializeField] private Text timerText; // Texte pour afficher le temps
    //[SerializeField] private Text endGameText; // Texte pour le message de fin
    public GameObject endGameText;
    private bool isGameOver = false;

    void Start()
    {
        endGameText.gameObject.SetActive(false); // Cacher le texte de fin au d�part
    }

    void Update()
    {
        if (isGameOver) return; // Si le jeu est termin�, ne faites rien

        // R�duire le temps restant
        gameDuration -= Time.deltaTime;

        // Mettre � jour le texte de la minuterie
        timerText.text = "Time: " + Mathf.CeilToInt(gameDuration).ToString();

        // V�rifier si le temps est �coul�
        if (gameDuration <= 0)
        {
            EndGame(false); // Game Over
        }
    }

    public void PlayerWins()
    {
        EndGame(true); // Le joueur a gagn�
    }

    private void EndGame(bool playerWon)
    {
        isGameOver = true; // Stopper le jeu
        endGameText.SetActive(true);

    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
