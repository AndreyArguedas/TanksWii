using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 7f; // Speed of the movement
    private Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
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

    // Update is called once per frame
    void Update()
    {
        // Check if the right mouse button is clicked
        if (gameObject.activeSelf)
        {
            transform.position = Vector3.MoveTowards(transform.position, getDestination(), moveSpeed * Time.deltaTime);
            if(transform.position == getDestination()){
                Destroy(gameObject);
            }
        }
    }
}
