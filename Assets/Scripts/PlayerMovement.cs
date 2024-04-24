using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public Transform bau;
    private Inventory playerInventory;

  private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
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

        Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement).normalized * MoveSpeed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);
    }
}
