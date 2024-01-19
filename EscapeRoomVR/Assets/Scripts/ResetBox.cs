using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBox : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Key") || other.CompareTag("Labyrinth"))
        {
            other.transform.position = new Vector3(0, 1, 0);
        }
    }
}
