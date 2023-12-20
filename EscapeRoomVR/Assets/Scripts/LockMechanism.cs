using System;
using UnityEngine;


public class LockMechanism : MonoBehaviour
{
    [SerializeField] private GameObject key;
    private Collider _lockTrigger;

    private void Start()
    {
        _lockTrigger = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            Instantiate(key, transform.position, Quaternion.identity, transform);
            Destroy(other);
            _lockTrigger.enabled = false;
        }
    }
}