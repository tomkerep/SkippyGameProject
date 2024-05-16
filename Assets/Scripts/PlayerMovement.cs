using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 6f;
    public Transform bau;
    private Inventory playerInventory;
    public Animator animator;


    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            // Debug.Log("rechts");
            animator.SetBool("isMoving", true);
            animator.SetBool("läuftRechts", true);
            //  Flip();
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            // Debug.Log("links");
            animator.SetBool("isMoving", true);
            animator.SetBool("läuftRechts", false);
            // Flip();
        }
        else if (!Input.anyKey)
        {
            animator.SetBool("isMoving", false);
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isMoving", true);
        }
    }

    void FixedUpdate()
    {
        //MovePlayer();
        //}

        // private void MovePlayer()
        // {
        float horizontalMovement = //Input.GetAxis("Horizontal");
        (Input.GetKey(KeyCode.D) ? 1f : 0f) +
        (Input.GetKey(KeyCode.RightArrow) ? 1f : 0f) +
        (Input.GetKey(KeyCode.A) ? -1f : 0f) +
        (Input.GetKey(KeyCode.LeftArrow) ? -1f : 0f);

        float verticalMovement = //Input.GetAxis("Vertical");
        (Input.GetKey(KeyCode.W) ? 1f : 0f) +
         (Input.GetKey(KeyCode.UpArrow) ? 1f : 0f) +
         (Input.GetKey(KeyCode.S) ? -1f : 0f) +
         (Input.GetKey(KeyCode.DownArrow) ? -1f : 0f);

        Vector3 movement = new Vector3(horizontalMovement, 0, verticalMovement).normalized* MoveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement );

        
    }

    /*  public void Flip(){
      // Switch the way the player is labelled as facing.
      m_FacingRight = !m_FacingRight;

      // Multiply the player's x local scale by -1.
      Vector3 theScale = transform.localScale;
      theScale.x *= -1;
      transform.localScale = theScale;
  }*/
}
