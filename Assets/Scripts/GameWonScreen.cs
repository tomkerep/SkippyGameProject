using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameWonScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public GameObject GameManager;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public GameObject Bau;

    void Start()
    {
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
    }

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " Nüsse gesammelt";
    }

    public void NextLevel()
    {
        //nächste Szene laden
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void ExitButton()
    {
        SceneManager.LoadScene("Hauptmenü");

    }

    public void Update(){

        timer2 timer = GameManager.GetComponent<timer2>();
        BauInventory bauInventory = Bau.GetComponent<BauInventory>();

        if(bauInventory.StoredNuts >= timer.NutsNeeded){
            star1.SetActive(true);
        }

        if(bauInventory.StoredNuts >= timer.NutsNeededStar2){
            star2.SetActive(true);

        }

        if(bauInventory.StoredNuts >= timer.NutsNeededStar3){
            star3.SetActive(true);
        }
}
}