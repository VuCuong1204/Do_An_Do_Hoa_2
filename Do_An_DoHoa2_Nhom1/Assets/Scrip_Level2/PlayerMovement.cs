using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool turnLeft, turnRight;
    public float speed =4.0f;
    private CharacterController myCharacterController;
    Vector3 jump;
    public bool isGrounded;
    public float jumpForce = 2.0f;

    void Start()
    {
       // rb = GetComponent<Rigidbody>();
        myCharacterController = GetComponent<CharacterController>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("platform"))
        {
            isGrounded = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //KeyCode.D
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(new Vector3(0f, -90f, 0f));
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) 
        {
            transform.Rotate(new Vector3(0f, 90f, 0f));
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
          //  rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        //myCharacterController.SimpleMove(new Vector3(0f, 0f, 0f));
        //myCharacterController.Move(transform.forward * speed * Time.deltaTime);
    }
}
