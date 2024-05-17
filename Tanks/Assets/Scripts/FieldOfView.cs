using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;

    public GameObject playerRef;
    //public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    public float checkInterval = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FOV(checkInterval));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void fovCheck(){
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius);
        bool ableToShoot = false;
        
        for(int i = 0; i < rangeChecks.Length; i++){
            if(rangeChecks[i].gameObject.name == playerRef.name){
                ableToShoot = true;
                break;
            }
        }

        if(ableToShoot){
            Transform target = playerRef.transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, directionToTarget) < angle / 2) {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                canSeePlayer = !Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask);
                if(canSeePlayer){
                    //gameObject.shootBullet(target.position);
                    // Call a function from ScriptA
                    DummyTank scriptA = GetComponent<DummyTank>();
                    if (scriptA != null)
                    {
                        scriptA.shootBullet(target.position);
                    }

                    Enemy scriptB = GetComponent<Enemy>();
                    if (scriptB != null)
                    {
                        scriptB.shootBullet(target.position);
                    }
                }
                
                
            }
            else{
                canSeePlayer = false;
            }
        }
        // If it was visible before
        else if(canSeePlayer){
            canSeePlayer = false;
        }
    }

    IEnumerator FOV(float interval)
    {   
        yield return new WaitForSeconds(interval);

        fovCheck();
        
        yield return StartCoroutine(FOV(interval)); // Recursive call
        
    }
}
