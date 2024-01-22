using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private GameObject wonDisplay;

    private LockMechanism[] _mechanism;

    private const int KeyAmount = 3;

    private int _keyCounter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.OnKeyEnter += KeyEntered;
        wonDisplay.SetActive(false);
    }

    /**
     * Counts the key that the player entered into the locks, when he's got all three he's won
     */
    void KeyEntered()
    {
        _keyCounter++;
        if (_keyCounter == KeyAmount)
        {
            wonDisplay.SetActive(true);
            GameEvents.current.GameWon();
        }
    }

    private void OnDestroy()
    {
        GameEvents.current.OnKeyEnter -= KeyEntered;
    }
}
