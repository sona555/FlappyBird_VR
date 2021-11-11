using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float speed = 3.5f;
    public float jumpForce = 10f;

    private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dead == true)
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            return;
        }

        GetComponent<Rigidbody>().velocity = new Vector3(
            0,
            GetComponent<Rigidbody>().velocity.y,
            speed
         );

        //Make the bird jump
        if (Input.GetKeyDown("space"))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0));
        }
    }

    void OnTriggerEnter(Collider otherCollider)
    {
       // Debug.Log(otherCollider.tag);
        if (otherCollider.tag == "Obstacle")
        {
            dead = true;
        }
    }
}
