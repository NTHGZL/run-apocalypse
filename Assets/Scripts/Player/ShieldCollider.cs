using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollider : MonoBehaviour
{
    public int lifePoint = 4;
    // Start is called before the first frame update
    void Start()
    {
       
       
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if (lifePoint <= 0)
        {
            gameObject.SetActive(false);
            lifePoint = 4;

        }
        
    }
    /**
     * Change gameplay when the shield is active
     */
   

  
    
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("SHIELD !");
            Destroy(other.gameObject);
            lifePoint--;
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
