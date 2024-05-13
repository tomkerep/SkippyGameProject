using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class start_level : MonoBehaviour
{

    private int level;

    public void Start() {
        level = Level_Selection.selectedLevel;
        Debug.Log(level);



    }

    public void PlayLevel() {
        SceneManager.LoadScene("Level " + level.ToString());
    }
}
