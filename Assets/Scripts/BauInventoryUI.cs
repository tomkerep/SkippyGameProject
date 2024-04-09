using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BauInventoryUI : MonoBehaviour
{
    private TextMeshProUGUI bauText;

    public GameObject GameManager;

    // Start is called before the first frame update
    void Start()
    {
        bauText = GetComponent<TextMeshProUGUI>();  
    }

    public void UpdateBauText(BauInventory bauInventory)
    {
        timer2 timer = GameManager.GetComponent<timer2>();

        bauText.text = bauInventory.StoredNuts.ToString() + "/" + timer.NutsNeeded.ToString() + " \n Nüsse im Bau";
    }

}
