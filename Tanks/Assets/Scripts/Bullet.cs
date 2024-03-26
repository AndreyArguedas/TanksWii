using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 7f; // Speed of the movement
    private Vector3 destination;
    private bool collide = false;
    // Start is called before the first frame update
    void Start()
    {
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

    void OnCollisionEnter(Collision collision)
    {   
        //collide = true;
        Debug.Log("Colision " + collision.gameObject.name);
        // Check if the collision involves a GameObject with the name "MainCharacter"
        /*if (collision.gameObject.name == "MainCharacter")
        {
           myCollider.enabled = false;
           objectRenderer.enabled = false;
           SceneController.instance.NextLevel();
        }

        // Check if the collision involves a GameObject with the name "Ground"
        if (collision.gameObject.name == "Ground" || 
            collision.gameObject.name == "Obstacle")
        {
           // Get the current scene index
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Reload the current scene
            SceneManager.LoadScene(currentSceneIndex);
        }*/
   
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the right mouse button is clicked
        if (gameObject.activeSelf && !collide)
        {
            transform.position = Vector3.MoveTowards(transform.position, getDestination(), moveSpeed * Time.deltaTime);
            if(transform.position == getDestination()){
                Destroy(gameObject);
            }
        }
    }
}
