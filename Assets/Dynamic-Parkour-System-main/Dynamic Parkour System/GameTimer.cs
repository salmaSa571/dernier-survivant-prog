using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private float gameDuration = 60f; // Durée du jeu en secondes
    [SerializeField] private Text timerText; // Texte pour afficher le temps
    //[SerializeField] private Text endGameText; // Texte pour le message de fin
    public GameObject endGameText;
    private bool isGameOver = false;

    void Start()
    {
        endGameText.gameObject.SetActive(false); // Cacher le texte de fin au départ
    }

    void Update()
    {
        if (isGameOver) return; // Si le jeu est terminé, ne faites rien

        // Réduire le temps restant
        gameDuration -= Time.deltaTime;

        // Mettre à jour le texte de la minuterie
        timerText.text = "Time: " + Mathf.CeilToInt(gameDuration).ToString();

        // Vérifier si le temps est écoulé
        if (gameDuration <= 0)
        {
            EndGame(false); // Game Over
        }
    }

    public void PlayerWins()
    {
        EndGame(true); // Le joueur a gagné
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
