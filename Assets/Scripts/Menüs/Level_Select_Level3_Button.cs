using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level_Select_Level3_Button : MonoBehaviour
{
    public void StartLevelThree()
    {
        SceneManager.LoadScene("Garten");
    }
}
