using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    //AI doohickey, I dunno what dis does but it;s important
    private NavMeshAgent agent = null;

    //transform of the player object
   [SerializeField] private Transform player;
    // Start is called before the first frame update
    void Start()
    {
          GetReferences();
    }

    // Update is called once per frame
    void Update()
    {
     
       moveToPlayer();
       
    }

    private void GetReferences(){

        agent = GetComponent<NavMeshAgent>();

    }

    private void moveToPlayer(){
        agent.SetDestination(player.position);



    }
    private void lookAtPlayer(){
        Vector3 direction = player.position-transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;

       
    }

}
