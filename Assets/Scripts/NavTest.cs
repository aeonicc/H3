using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Robb
{
    public class NavTest : MonoBehaviour
    {
        public Transform target;
        public NavMeshAgent agent;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            agent.SetDestination(target.position);
        }
    }

}
