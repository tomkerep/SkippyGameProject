using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MLevel_Select_Tutorial_Button : MonoBehaviour
{
    public AudioClip click;
    // Start is called before the first frame update
    public void StartTutorial()
    {
        SceneManager.LoadScene("Garten");
        // Soundeffekt abspielen
            AudioManager.instance.PlaySFX(click);
    }

}