using UnityEngine;

public class BlockerSprite : MonoBehaviour
{
    // Variable, die angibt, ob der Sprite existiert oder nicht
    public bool exists = true;

    // Collider des Sprites
    private Collider2D myCollider;

    void Start()
    {
        // Hole den Collider des Sprites
        myCollider = GetComponent<Collider2D>();

        // Überprüfe, ob der Collider existiert und setze ihn entsprechend
        if (exists)
        {
            // Collider ist nicht als Trigger eingestellt und blockiert den Spieler
            myCollider.isTrigger = false;
        }
        else
        {
            // Collider ist als Trigger eingestellt und lässt den Spieler passieren
            myCollider.isTrigger = true;
        }
    }

    // Methode zum Aktualisieren des Verhaltens des Colliders basierend auf der Existenz des Sprites
    public void UpdateCollider()
    {
        if (exists)
        {
            myCollider.isTrigger = false;
        }
        else
        {
            myCollider.isTrigger = true;
        }
    }

    // Methode, um den Existenzstatus des Sprites zu ändern und das Collider-Verhalten entsprechend zu aktualisieren
    public void SetExistence(bool value)
    {
        exists = value;
        UpdateCollider();
    }
}
