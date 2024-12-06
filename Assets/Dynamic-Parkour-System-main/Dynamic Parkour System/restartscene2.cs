using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartscene2 : MonoBehaviour
{
    // Start is called before the first frame update
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Testing");

    }
}
