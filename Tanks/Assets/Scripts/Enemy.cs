using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : BaseTank
{
    public float shootInterval = 3.5f;
    
    public GameObject destination;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(shoot(shootInterval));
    }

    // Update is called once per frame
    void Update()
    {   
        if(destination != null){
            agent.destination = destination.transform.position;
        }
    }

    IEnumerator shoot(float duration)
    {   
        yield return new WaitForSeconds(duration);
        if(destination != null){
            base.shootBullet(destination.transform.position);
            yield return StartCoroutine(shoot(duration)); // Recursive call
        }
        
    }

}
