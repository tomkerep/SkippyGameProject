using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI nutText;
    private Vector2 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        nutText = GetComponent<TextMeshProUGUI>();  
         originalPosition = nutText.rectTransform.anchoredPosition;
    }

    public void UpdateNutText(PlayerInventory playerInventory)
    {
        nutText.text = playerInventory.NumberOfNuts.ToString() + "/" + playerInventory.MaxNumberOfNuts.ToString();
    }

    

}
