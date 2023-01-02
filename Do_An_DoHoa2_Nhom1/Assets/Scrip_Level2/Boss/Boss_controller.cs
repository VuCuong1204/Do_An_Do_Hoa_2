using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_controller : MonoBehaviour
{
    private bool turnLeft, turnRight;
    private float speed = 5.0f;
    private CharacterController myCharacterController;
    void Start()
    {
        myCharacterController = GetComponent<CharacterController>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().showGamePanel(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

        // myCharacterController.SimpleMove(new Vector3(0f, 0f, 0f));
        myCharacterController.Move(transform.forward * speed * Time.deltaTime);
    }
}
