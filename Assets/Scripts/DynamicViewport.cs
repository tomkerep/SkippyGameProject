using UnityEngine;

public class DynamicViewport : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        UpdateViewport();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateViewport();
        }
    }

    void UpdateViewport()
    {
        // Berechnen Sie das Seitenverhältnis des Bildschirms
        float targetAspect = 16f / 9f; // Standard-Aspect-Ratio, ändern Sie dies entsprechend Ihrer Anforderungen
        float screenAspect = (float)Screen.width / Screen.height;

        // Berechnen Sie die Breite und Höhe des Viewports basierend auf dem Seitenverhältnis des Bildschirms
        float width = screenAspect / targetAspect;
        float height = 1f;

        // Wenn das Bildschirmseitenverhältnis größer ist als das Ziel-Seitenverhältnis, skaliere die Höhe des Viewports
        if (screenAspect > targetAspect)
        {
            height = targetAspect / screenAspect;
        }

        // Setzen Sie das Viewport-Rechteck basierend auf der berechneten Breite und Höhe
        mainCamera.rect = new Rect((1f - width) / 2f, (1f - height) / 2f, width, height);
    }
}
