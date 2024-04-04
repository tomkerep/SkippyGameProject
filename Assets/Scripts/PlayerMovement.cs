using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public int maxNuts = 4;
    private int currentNuts = 0;
    public Transform bau;
    private Inventory playerInventory;

    void Start()
    {
        playerInventory = GetComponent<Inventory>(); // Erhalten Sie das Inventar des Spielers
    }

    void Update()
    {
        MovePlayer();
        CheckForPickup();
        CheckForDrop();
        //CheckForEnemyCollision();
    }

    private void MovePlayer()
    {
        float horizontalMovement = 
            (Input.GetKey(KeyCode.D) ? 1f : 0f) +
            (Input.GetKey(KeyCode.RightArrow) ? 1f : 0f) +
            (Input.GetKey(KeyCode.A) ? -1f : 0f) +
            (Input.GetKey(KeyCode.LeftArrow) ? -1f : 0f);

        float verticalMovement =
            (Input.GetKey(KeyCode.W) ? 1f : 0f) +
            (Input.GetKey(KeyCode.UpArrow) ? 1f : 0f) +
            (Input.GetKey(KeyCode.S) ? -1f : 0f) +
            (Input.GetKey(KeyCode.DownArrow) ? -1f : 0f);

        this.transform.position += new Vector3(horizontalMovement, 0f, verticalMovement) * MoveSpeed * Time.deltaTime;
    }

    private void CheckForPickup()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                PickableNut nut = hit.collider.GetComponent<PickableNut>();
                if (nut != null && currentNuts < maxNuts)
                {
                    currentNuts++;
                    playerInventory.AddItem(hit.collider.gameObject); // Fügen Sie das aufgenommene Objekt dem Inventar hinzu
                    //nut.PickUp();
                }
            }
        }
    }

    private void CheckForDrop()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (currentNuts > 0)
            {
                currentNuts--;
                // Hier können Sie die Nuss aus dem Inventar des Spielers entfernen, wenn Sie möchten
            }
        }
    }
  /*  private void CheckForEnemyCollision()
    {
        // Check if the player has collided with an enemy
        // If so, reset the player's position to the bau
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, Mathf.Infinity))
        {
            EnemyMovement enemy = hit.collider.GetComponent<EnemyMovement>();
            if (enemy != null)
            {
              //  transform.position = bau.position;
            }
        }
    }*/
}

internal class PickableNut
{
}