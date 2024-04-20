using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTank : MonoBehaviour
{
    public float moveSpeed = 4f; // Speed of the movement
    public float rotationSpeed = 5f; // Speed of the rotation
    
    public Bullet bulletPrefab; // Reference to the prefab in the Unity Editor
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void shootBullet(Vector3 finalDestination){
        Transform gunChild = transform.Find("Gun");
        Vector3 bulletPosition = new Vector3(gunChild.transform.position.x, transform.position.y,gunChild.transform.position.z);
        Bullet tempBullet = Instantiate(bulletPrefab, bulletPosition, gunChild.transform.rotation);
        tempBullet.setDestination(finalDestination);
        tempBullet.setActiveBullet(true);
    }

    protected void OnCollisionEnter(Collision collision)
    {   
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }   
    }
}
