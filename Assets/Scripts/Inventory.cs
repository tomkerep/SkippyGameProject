using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<GameObject> items = new List<GameObject>(); // Liste zur Aufbewahrung von Gegenständen im Inventar

    public void AddItem(GameObject item)
    {
        items.Add(item);
        Debug.Log(item.name + " wurde dem Inventar hinzugefügt.");
    }

    public void RemoveItem(GameObject item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log(item.name + " wurde aus dem Inventar entfernt.");
        }
        else
        {
            Debug.LogWarning(item.name + " ist nicht im Inventar vorhanden.");
        }
    }
}
