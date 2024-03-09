using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 7f; // Speed of the movement
    private bool activateBullet = false;
    private Vector3 worldMousePos;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the right mouse button is clicked
        if (Input.GetMouseButtonDown(0) && !activateBullet)
        {
            Vector3 mousePos = Input.mousePosition;
            // Set the distance of the camera from the object
            mousePos.z = Camera.main.transform.position.y;
            // Convert the mouse position from screen space to world space
            worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
            activateBullet = true;
        }

        if(activateBullet){
            transform.position = Vector3.MoveTowards(transform.position, worldMousePos, moveSpeed * Time.deltaTime);
        }
        

    }
}
