using UnityEngine;

public class SizeInPixels : MonoBehaviour
{
    void Start()
    {
        // Hol die aktuelle Größe des Objekts in Weltkoordinaten
        Vector3 size = transform.localScale;

        // Hol die aktuelle Bildschirmauflösung
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // Hol die Position des Objekts in Bildschirmkoordinaten
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        // Berechne die Größe des Objekts in Pixeln
        float objectWidthInPixels = (size.x / 2) * screenWidth / screenPos.z;
        float objectHeightInPixels = (size.y / 2) * screenHeight / screenPos.z;

        // Gib die Größe des Objekts in Pixeln aus
        Debug.Log("Width: " + objectWidthInPixels + " pixels");
        Debug.Log("Height: " + objectHeightInPixels + " pixels");
    }
}
