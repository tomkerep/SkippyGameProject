using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameWonScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public GameObject GameManager;
    public GameObject Bau;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public AudioClip win_sound;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        // Soundeffekt abspielen
            AudioManager.instance.PlaySFX(win_sound);
        pointsText.text = score.ToString() + " Nüsse gesammelt";
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

        timer2 timer = GameManager.GetComponent<timer2>();
        BauInventory bauInventory = Bau.GetComponent<BauInventory>();

        if(bauInventory.StoredNuts >= timer.NutsNeeded){
            Debug.LogWarning("1 Stern");
            star1.SetActive(true);
        }

        if(bauInventory.StoredNuts >= timer.NutsNeededStar2){
            Debug.LogWarning("2 Sterne");
            star2.SetActive(true);

        }

        if(bauInventory.StoredNuts >= timer.NutsNeededStar3){
            Debug.LogWarning("3 Sterne");
            star3.SetActive(true);
        }

    }

    public void NextLevel()
    {
        //Slider zurücksetzen
        FindObjectOfType<GameManager>().ResetSlider(); 
        //nächste Szene laden
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void ExitButton()
    {
        SceneManager.LoadScene("Hauptmenü");

    }
}
