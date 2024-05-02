using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BauInventoryUI : MonoBehaviour
{
    private TextMeshProUGUI bauText;

    public GameObject GameManager;

     public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    // Start is called before the first frame update
    void Start()
    {
        bauText = GetComponent<TextMeshProUGUI>();  
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
    }

    public void UpdateBauText(BauInventory bauInventory)
    {
        timer2 timer = GameManager.GetComponent<timer2>();

        bauText.text = bauInventory.StoredNuts.ToString() + "/" + timer.NutsNeeded.ToString() + " \n Nüsse im Bau";
    }

    public void UpdateStars(BauInventory bauInventory){

        timer2 timer = GameManager.GetComponent<timer2>();

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

}
