using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TakeDamage : MonoBehaviour
{
    public float initialIntensity = 0.2f;
    public float fadeDuration = 0.2f; // Duration for the initial effect before fading
    public float fadeSpeed = 0.01f;   // Speed at which the effect fades

    PostProcessVolume _volume;
    Vignette _vignette;

    void Start()
    {
        _volume = GetComponent<PostProcessVolume>();
        if (_volume.profile.TryGetSettings<Vignette>(out _vignette))
        {
            _vignette.enabled.Override(false);
        }
        else
        {
            Debug.LogError("Vignette component not found in the PostProcessVolume.");
        }
    }

    public IEnumerator TakeDamageEffect()
    {
        // Set initial intensity and enable vignette
        _vignette.enabled.Override(true);
        _vignette.intensity.Override(initialIntensity);

        // Wait for the specified duration
        yield return new WaitForSeconds(fadeDuration);

        // Gradually decrease intensity
        while (_vignette.intensity.value > 0)
        {
            _vignette.intensity.Override(_vignette.intensity.value - fadeSpeed);
            yield return new WaitForSeconds(0.01f); // Adjust delay as needed for smoother fade
        }

        // Ensure the intensity is set to 0 and disable vignette
        _vignette.intensity.Override(0);
        _vignette.enabled.Override(false);
    }
}