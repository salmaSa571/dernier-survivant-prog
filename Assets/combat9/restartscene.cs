using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartscene : MonoBehaviour
{
    // Start is called before the first frame update


    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Map3");

    }
}
