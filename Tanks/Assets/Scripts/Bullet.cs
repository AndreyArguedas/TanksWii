using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 7f; // Speed of the movement
    private Vector3 destination;
    private Rigidbody rb;

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
           Vector3.Reflect(rb.velocity, contact.normal);
        }
   
    }

    // Update is called once per frame
    void Update()
    {

    }
}
