using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace M
{
    public class EnemyRoot : MonoBehaviour
    {
        public static Action PlayerAttacked;
    
        [SerializeField] private GameObject parent;

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Projectile"))
            {
                Destroy(parent);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                PlayerAttacked?.Invoke();
            }
        }
    }   
}