using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTank : BaseTank
{
    public float shootInterval = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(shoot(shootInterval));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
    }

    IEnumerator shoot(float duration)
    {   
        yield return new WaitForSeconds(duration);
        Transform spawnPoint = transform.Find("SpawnPoint");
        if(spawnPoint != null){
            base.shootBullet(spawnPoint.position);
            yield return StartCoroutine(shoot(duration)); // Recursive call
        }
        
    }
}
