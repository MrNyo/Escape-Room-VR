using UnityEngine;

public class BallReset : MonoBehaviour

{
    [SerializeField] private Transform ballStart;
    [SerializeField] private Transform keySpawnPosition;
    [SerializeField] private GameObject key;

    /**
    * Reacting to the ball "falling" into a hole
    *   Case 1: Resets ball to the start
    *   Case 2: Reaching the finish hole it will spawn an exit key
    */
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (transform.name == "Finish")
            {
                GameEvents.current.SoundPlayed(SoundTypes.ChallengeWon);
                Instantiate(key, keySpawnPosition.position, Quaternion.identity);
                Destroy(other.gameObject);
            }
            else
            {
                GameEvents.current.SoundPlayed(SoundTypes.ChallengeFailed);
                other.transform.position = ballStart.position;
            }
        }
    }
}