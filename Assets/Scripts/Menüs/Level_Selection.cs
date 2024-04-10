using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Selection : MonoBehaviour
{
    public void StartLevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void StartLevelTwo()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void StartLevelThree()
    {
        SceneManager.LoadScene("Level 3");
    }
}
