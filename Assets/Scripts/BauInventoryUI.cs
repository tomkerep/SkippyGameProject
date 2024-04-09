using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BauInventoryUI : MonoBehaviour
{
    private TextMeshProUGUI bauText;

    // Start is called before the first frame update
    void Start()
    {
        bauText = GetComponent<TextMeshProUGUI>();  
    }

    public void UpdateBauText(BauInventory bauInventory)
    {
        bauText.text = bauInventory.StoredNuts.ToString() + " Nüsse im Bau";
    }

}
