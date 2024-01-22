using UnityEngine;

public class ResetBox : MonoBehaviour
{
    /**
     * For when the key or the labyrinth should fall out of the room they get reset into the middle of the room
     */
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Key") || other.CompareTag("Labyrinth"))
        {
            other.transform.position = new Vector3(0, 1, 0);
        }
    }
}
