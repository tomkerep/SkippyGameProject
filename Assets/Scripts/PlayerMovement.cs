using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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

    private void CheckForPickup()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
            
               /* PickableItem pickable = hit.collider.GetComponent<PickableItem>(); // PickableItem ist nur ein Platzhalter, ersetzen durch den Namen des Skripts, das die PickUp-Funktion enthält
                if (pickable != null)
                {
                    pickable.Pickup();
                }*/
            }
        }


    }
}