using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 7f; // Speed of the movement
    private Vector3 destination;
    private Rigidbody rb;
    public int allowedCollisions = 3;
    private int currentCollisions = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = (destination - transform.position).normalized * moveSpeed;
        Invoke("disableTriggerCollider", 0.05f);
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
    public void disableTriggerCollider(){
        transform.GetComponent<Collider>().isTrigger = false;
    }
    


    void OnCollisionEnter(Collision collision)
    {   
        if (collision.gameObject.tag == "Wall")
        {
           ContactPoint contact = collision.contacts[0];
           Vector3 direction = Vector3.Project(rb.velocity, contact.normal);
           GetComponent<Rigidbody>().AddForce(direction * moveSpeed);
           currentCollisions++;
           //rb.velocity = direction * moveSpeed;
           if(currentCollisions >= 3){
            Destroy(gameObject);
           }
        }

        if (collision.gameObject.name == "Enemy" || collision.gameObject.name == "Tank")
        {
            Destroy(gameObject);
        }
   
    }

    // Update is called once per frame
    void Update()
    {

    }
}
