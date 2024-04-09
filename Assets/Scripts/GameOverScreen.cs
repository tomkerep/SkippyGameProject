using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " Nüsse gesammelt";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Overlay Levels");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Hauptmenü");

    }
}
