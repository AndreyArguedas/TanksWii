using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of the movement
    public float rotationSpeed = 5f; // Speed of the rotation
    public int amountBullets = 10; // Amount of bullets
    
    public Bullet bulletPrefab; // Reference to the prefab in the Unity Editor
    private List<Bullet> bullets = new List<Bullet>();
    
    // Start is called before the first frame update
    void Start()
    {
        //Transform gunChild = transform.Find("Gun");

        for (int i = 0; i < amountBullets; i++)
        {
            // Adjust position according to your needs
            Bullet obj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            //obj.transform.SetParent(transform);
            bullets.Add(obj);
        }
        

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
        if (Input.GetMouseButtonDown(0) && bullets.Count > 0)
        {
            Vector3 bulletFuturePos = Input.mousePosition;
            // Set the distance of the camera from the object
            bulletFuturePos.z = Camera.main.transform.position.y;
            Vector3 finalDestination = Camera.main.ScreenToWorldPoint(bulletFuturePos);
            Bullet tempBullet = bullets[0];
            tempBullet.setDestination(finalDestination);
            tempBullet.setActiveBullet(true);
            bullets.RemoveAt(0); 
            
        }
    }
}
