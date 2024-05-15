using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshPro nutText;
    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Try to get the TextMeshPro component on the same GameObject
        nutText = GetComponent<TextMeshPro>();
        
        // If not found, try to find it in the children
        if (nutText == null)
        {
            nutText = GetComponentInChildren<TextMeshPro>();
        }
        
        // Log an error if TextMeshPro component is still not found
        if (nutText == null)
        {
            Debug.LogError("TextMeshPro component not found!");
            return;
        }

        // Log success and continue with initialization
        Debug.Log("TextMeshPro component found.");
        originalPosition = nutText.transform.localPosition;
    }

    public void UpdateNutText(PlayerInventory playerInventory)
    {
        if (nutText == null)
        {
            Debug.LogError("TextMeshPro component not assigned!");
            return;
        }

        nutText.text = playerInventory.NumberOfNuts.ToString() + "/" + playerInventory.MaxNumberOfNuts.ToString();
    }
}

