using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject pauseMenu;
    private AudioSource[] allAudioSources;

    //void Start()
    //{
        
    //    allAudioSources = FindObjectsOfType<AudioSource>();
    //}




    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        // Met tous les sons en pause
        //foreach (AudioSource audioSource in allAudioSources)
        //{
        //    if (audioSource.isPlaying)
        //    {
        //        audioSource.Pause();
        //    }
        //}
    }




    public void Home()
    {
        
        SceneManager.LoadScene("menuscene");

    }
    public void Resume()
    {

        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        //// Reprend tous les sons mis en pause
        //foreach (AudioSource audioSource in allAudioSources)
        //{
        //    if (!audioSource.isPlaying)
        //    {
        //        audioSource.UnPause();
        //    }
        //}
    }
    public void Restart()
    {
        //Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
