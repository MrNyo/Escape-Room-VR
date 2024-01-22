using UnityEngine;

public class BallOutOfLabyrinth : MonoBehaviour
{
    [SerializeField] private Transform ballReset;

    /**
     * Resets the ball in case it falls out of the box
     */
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            other.transform.position = ballReset.position;
        }
    }
}