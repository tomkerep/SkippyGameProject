using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    public Slider slider;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " Nüsse gesammelt";
    }

    public void RestartButton()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        slider.value = slider.maxValue;

        // Load the current scene by its name
        SceneManager.LoadScene(currentSceneName);

    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Hauptmenü");

    }
}
