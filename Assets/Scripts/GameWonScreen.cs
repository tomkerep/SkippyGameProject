using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameWonScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " Nüsse gesammelt";
    }

public void NextLevel()
{
    SceneManager.LoadScene("Level 2");
}
    

    public void ExitButton()
    {
        SceneManager.LoadScene("Hauptmenü");

    }
}
