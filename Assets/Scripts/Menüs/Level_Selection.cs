using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Selection : MonoBehaviour
{

    public static int selectedLevel;
    public int level;

    public void OpenScene()
    {
        selectedLevel = level;
        SceneManager.LoadScene("Level " + level.ToString());
    }
    
}
