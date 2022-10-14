using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10f;
    public float xBound = 11f;
    private float zPos = 2.4f;
    private float yPos = 1.1f;
    public bool isJumping = false;

    private Rigidbody ballRB;
    public float forwardForce = 5f;
    public float upForce = 5f;

    // Start is called before the first frame update
    void Start()
    {
        ballRB = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y == yPos || transform.position.z == zPos)
        {
            transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        }

        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            ballRB.AddForce(Vector3.up * upForce, ForceMode.Impulse);
            ballRB.AddRelativeForce(Vector3.forward * forwardForce, ForceMode.Impulse);
            isJumping = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Ball is destroyed afte hitting ground");
            Destroy(this.gameObject);
        }
    }
}
