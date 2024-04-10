using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of the movement
    public float rotationSpeed = 5f; // Speed of the rotation
    public GameObject destination;
    private NavMeshAgent agent;
    public Bullet bulletPrefab; // Reference to the prefab in the Unity Editor

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = destination.transform.position;
    }

    void shootBullet(Vector3 finalDestination){
        Transform gunChild = transform.Find("Gun");
        Vector3 bulletPosition = new Vector3(gunChild.transform.position.x, transform.position.y,gunChild.transform.position.z);
        Bullet tempBullet = Instantiate(bulletPrefab, bulletPosition, gunChild.transform.rotation);
        tempBullet.setDestination(finalDestination);
        tempBullet.setActiveBullet(true);
    }

    void OnCollisionEnter(Collision collision)
    {   
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }   
    }
}
