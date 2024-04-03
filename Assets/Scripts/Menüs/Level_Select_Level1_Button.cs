using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Select_Level1_Button : MonoBehaviour
{
    public void StartLevelOne()
    {
        SceneManager.LoadScene("Garten");
    }

}
