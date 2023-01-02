using System.Collections;
using UnityEngine;

public class PlayerController_1 : MonoBehaviour
{
    public float moveSpeed = 7;
    public float leftRightSpeed;
    public GameObject gameOverText;

    Vector3 jump;
   
    public float jumpForce = 2.0f;
    public bool isGrounded;

    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
       // gameOverText.SetActive(false);

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("platform"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Die"))
        {
            FindObjectOfType<GameManager>().showGamePanel(true);
            moveSpeed = 0;
        }
    }
    private void LateUpdate()
    {
       
        //Move left
        if ( Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(new Vector3(0f, -90f, 0f));
          
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {       
            transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
           // transform.Rotate(new Vector3(0f, -90f, 0f));
        }
        //Move right
        if (Input.GetKeyDown(KeyCode.D))
        {
           // transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
        
           transform.Rotate(new Vector3(0f, 90f, 0f));
         
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
           
            transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * (-1));
           // transform.Rotate(new Vector3(0f, 90f, 0f));
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

       // Restart
        if (rb.position.y < -0.5f)
        {
            FindObjectOfType<GameManager>().showGamePanel(true);
            
           // gameOverText.SetActive(true);
        }

       transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);

    }
    private void OnTriggerEnter(Collider other)
    {
        
        // tốc độ được tăng lên 2
        if (other.gameObject.tag == "Candy")
        {
            moveSpeed = moveSpeed + 2;
            other.gameObject.SetActive(false);
        }
        //tốc độ bị giảm 
        if (other.gameObject.tag == "obstacle")
        {
            moveSpeed = moveSpeed - 1;
        }

        //delay 1 khoảng thời gian
        if (other.gameObject.tag == "Rock")
        {
            StartCoroutine(timeSpeed());
            other.gameObject.SetActive(false);
        }

    }
    IEnumerator timeSpeed()
    {
        yield return new WaitForSeconds(0.01f);
        moveSpeed = 7;
    }
}
