using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarUI : MonoBehaviour
{
    private TextMeshProUGUI starText1;
    private TextMeshProUGUI starText2;
    private TextMeshProUGUI starText3;


private timer2 gameManager;
    
    void Start()
    {
        // Find the timer2 GameObject
        GameObject timer2Object = GameObject.Find("GameManager");

        // Get the timer2 script component from the GameObject
        gameManager = timer2Object.GetComponent<timer2>();

        // Get references to the TextMeshProUGUI components
        starText1 = transform.Find("StarText1").GetComponent<TextMeshProUGUI>();
        starText2 = transform.Find("StarText2").GetComponent<TextMeshProUGUI>();
        starText3 = transform.Find("StarText3").GetComponent<TextMeshProUGUI>();

        // Update UI text with values from GameManager
        UpdateUI();
    }

    void UpdateUI()
    {
        // Update UI text with values from GameManager
        starText1.text = gameManager.NutsNeeded.ToString();
        starText2.text = gameManager.NutsNeededStar2.ToString();
        starText3.text = gameManager.NutsNeededStar3.ToString();
    }
}
