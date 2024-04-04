using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level_Select_Level2_Button : MonoBehaviour
{
    public void StartLevelTwo()
    {
        SceneManager.LoadScene("Garten");
    }
}
