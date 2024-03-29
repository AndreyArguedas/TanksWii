using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 7f; // Speed of the movement
    private Vector3 destination;
    private bool collide = false;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = (destination - transform.position).normalized * moveSpeed;
        //Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
    }

    public void setActiveBullet(bool active){
        gameObject.SetActive(active);
    }

    public void setDestination(Vector3 inputDestination){
        destination = inputDestination;
    }

    public Vector3 getDestination(){
        return destination;
    }

    void FixedUpdate()
    {
        // Check if we have reached the destination
        /*if (Vector3.Distance(transform.position, destination) < 0.1f)
        {
            rb.velocity = Vector3.zero;
            // Implement bouncing behavior here
            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse); // Example: Bounce upward
        }*/
    }

    // This method is called when another collider enters the trigger collider.
    /*private void OnTriggerEnter(Collider other)
    {
        collision
        if (other.name == "Ball")
        {
            moveStarToCounter(destination);
        }
    }*/

    void OnCollisionEnter(Collision collision)
    {   
        //collide = true;
        Debug.Log("Colision " + collision.gameObject.tag);
        //Debug.Log("Colision " + collision.contacts[0].normal);*/
        // Check if the collision involves a GameObject with the tag
        if (collision.gameObject.tag == "Wall")
        {
           ContactPoint contact = collision.contacts[0];
           Vector3.Reflect(rb.velocity, contact.normal);
        }
   
    }

    // Update is called once per frame
    void Update()
    {

    }
}
