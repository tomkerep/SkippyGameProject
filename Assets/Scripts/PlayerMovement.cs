using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public Transform bau;
    private Inventory playerInventory;

    void Start()
    {
     //   playerInventory = GetComponent<Inventory>(); // Erhalten Sie das Inventar des Spielers
    }

    void Update()
    {
        MovePlayer();
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
}
