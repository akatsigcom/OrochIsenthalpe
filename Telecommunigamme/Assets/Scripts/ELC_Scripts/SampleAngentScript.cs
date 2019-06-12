using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SampleAngentScript : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -1);

        agent.SetDestination(target.position);
       

    }
}
