using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class BallReset : MonoBehaviour

    {
        [SerializeField] private Transform ballStart;
        [SerializeField] private Transform keySpawnPosition;
        [SerializeField] private GameObject key;

        private void OnTriggerEnter(Collider other)
        {
            
            if (other.CompareTag("Ball"))
            {
                if (transform.name == "Finish")
                {
                    Instantiate(key, keySpawnPosition.position, Quaternion.identity);
                    Destroy(other);
                }
                else
                {
                    other.transform.position = ballStart.position;
                }
                
            }
        }
    }
}