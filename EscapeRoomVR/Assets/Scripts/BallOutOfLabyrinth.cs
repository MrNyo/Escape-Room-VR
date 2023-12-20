using UnityEngine;

    public class BallOutOfLabyrinth: MonoBehaviour
    {
        [SerializeField] private Transform ballReset;
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Ball"))
            {
                other.transform.position = ballReset.position;
            }
        }
    }
