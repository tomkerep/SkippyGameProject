using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //nächste Szene laden
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
        /* if (Application.isEditor)
         {
             UnityEditor.EditorApplication.isPlaying = false;
         }
         else
         {

         }*/
    }

}