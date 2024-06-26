using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : BaseTank
{
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        // Get the input from arrow keys or WASD
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // Calculate the movement direction
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        // Move the object based on the input
        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);
        // Get the current mouse position in screen coordinates
        Vector3 mousePos = Input.mousePosition;
        // Set the distance of the camera from the object
        mousePos.z = Camera.main.transform.position.y;
        // Convert the mouse position from screen space to world space
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        // Calculate the direction from the object to the mouse position
        Vector3 direction = worldMousePos - transform.position;
        direction.y = 0; // Optional: You can remove this line if you want rotation on all axes
        // Calculate the rotation to look at the mouse position
        Quaternion rotation = Quaternion.LookRotation(direction);
        // Rotate the object smoothly towards the mouse position
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        // Check if the left mouse button is clicked and there is bullets left
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 bulletFuturePos = Input.mousePosition;
            // Set the distance of the camera from the object
            bulletFuturePos.z = Camera.main.transform.position.y;
            Vector3 finalDestination = Camera.main.ScreenToWorldPoint(bulletFuturePos);
            base.shootBullet(finalDestination);           
        }
        
    }

}
