using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : BaseTank
{
    public float movementInterval = 2.0f;
    private int movementType = 0; //0 - random walk - 1 ai movement

    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(defineMovement(movementInterval));
        //StartCoroutine(shoot(shootInterval));
    }

    // Update is called once per frame
    void Update()
    {   
        if(destination != null) {
            movement();
        }
    }

    private void movement(){
        if(movementType == 0){
            agent.destination = GetRandomPosition();
            
        }
        else{
            agent.destination = destination.transform.position;
        }

    }

    private void setMovementType(int moveType){
        movementType = moveType;
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(transform.position.x - sightRange, transform.position.x + sightRange);
        float z = Random.Range(transform.position.z - sightRange, transform.position.z + sightRange);
        return new Vector3(x, 0f, z);
    }

    IEnumerator defineMovement(float interval){
        yield return new WaitForSeconds(interval);
        setMovementType(Random.Range(0, 2));
        yield return StartCoroutine(defineMovement(interval)); // Recursive call
    }

}
