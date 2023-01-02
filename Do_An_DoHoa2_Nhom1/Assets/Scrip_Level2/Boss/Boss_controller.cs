using System.Collections;
using UnityEngine;

public class Boss_controller : MonoBehaviour
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

        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().showGamePanel(true);
            //gameOverText.SetActive(true);
            moveSpeed = 0f;
        }
    }
    private void LateUpdate()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
    }
    private void OnTriggerEnter(Collider other)
    {
   
    }
    IEnumerator timeSpeed()
    {
        yield return new WaitForSeconds(0.6f);
        moveSpeed = 5;
    }
}
