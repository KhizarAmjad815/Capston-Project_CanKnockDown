using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyColaCan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            // If Cola Can hits ground, destroying it and adding to user scores
            Destroy(this.gameObject);
            Debug.Log("Cola Can is destroyed after hitting ground");

            GameManager.gameManager.AddScore(1);
        }
    }
}
