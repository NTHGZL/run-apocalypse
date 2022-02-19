using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{

    public GameObject shield;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameplayManager.Instance.GameOver();
        }

        if (other.CompareTag("Jumper"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*1500);
        }
        if (other.CompareTag("Ground"))
        {
            
            PlayerMovement.Instance.canJump = true;
        }

        if (other.CompareTag("Bonus"))
        {
            Destroy(other.gameObject);
            shield.SetActive(true);
        }
       
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            PlayerMovement.Instance.canJump = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
                PlayerMovement.Instance.canJump = false;
        }
    }
}
