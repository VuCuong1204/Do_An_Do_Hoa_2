using System.Collections;
using UnityEngine;

public class PlayerController_1 : MonoBehaviour
{
    public float moveSpeed = 5;
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
    }
    private void LateUpdate()
    {
        //Move left
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            //if(this.gameObject.transform.position.x > -4.6f)
            //{
            transform.Rotate(new Vector3(0f, -90f, 0f));
            //}
        }
        //Move right
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            //if (this.gameObject.transform.position.x < 4.6f)
            //{
            transform.Rotate(new Vector3(0f, 90f, 0f));
            //}
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
        if (other.gameObject.tag == "Gift")
        {
            StartCoroutine(timeSpeed());
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "obstacle")
        {
            FindObjectOfType<GameManager>().showGamePanel(true);
            //gameOverText.SetActive(true);
            moveSpeed = 0f;
        }
    }
    IEnumerator timeSpeed()
    {
        yield return new WaitForSeconds(0.6f);
        moveSpeed = 5;
    }
}
