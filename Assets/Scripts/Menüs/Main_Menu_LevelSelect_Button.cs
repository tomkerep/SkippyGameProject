using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_LevelSelect_Button : MonoBehaviour
{
    public void StartUntermenü()
    {
        SceneManager.LoadScene("Untermenü");
    }
}
