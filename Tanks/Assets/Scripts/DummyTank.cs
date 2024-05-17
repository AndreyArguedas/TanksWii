using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTank : BaseTank
{
    
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(shoot(shootInterval));
    }

    // Update is called once per frame
    void Update()
    {
        if (destination != null)
        {
            // Calculate the direction from this object to the target object
            Vector3 directionToTarget = destination.transform.position - transform.position;

            // Calculate the rotation needed to face the target object
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

    }

    public override void shootBullet(Vector3 finalDestination){
        base.shootBullet(finalDestination);
    }
}
