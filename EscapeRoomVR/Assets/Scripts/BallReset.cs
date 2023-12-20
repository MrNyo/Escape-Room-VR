using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class BallReset : MonoBehaviour

    {
        [SerializeField] private Transform ballStart;
        [SerializeField] private Transform labyrinthItself;
        [SerializeField] private GameObject key;

        private void OnTriggerEnter(Collider other)
        {
            
            if (other.CompareTag("Ball"))
            {
                if (transform.name == "Finish")
                {
                    Instantiate(key, labyrinthItself.position - new Vector3(0,0.1f,0), Quaternion.identity);
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