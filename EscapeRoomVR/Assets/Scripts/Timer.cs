using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float _timeValue = 600;
    [SerializeField] private TextMeshPro timetext;
    private bool _gameStillRunning = true;

    private void Start()
    {
        GameEvents.current.OnGameWon += GameWon;
    }

    /**
     * Counts time down and quits the game when the time is over
     * Slightly more time that expected so player can realise it's over
     */
    void Update()
    {
        if (_timeValue > -5 && _gameStillRunning)
        {
            _timeValue -= Time.deltaTime;
        }
        else
        {
            if (_timeValue <= -5)
            {
                Application.Quit();
            }
        }

        DisplayTime(_timeValue);
    }

    /**
     * Displays the time the player has left
     */
    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        else if (timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timetext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    /**
     * Quits the game if button is pressed
     */
    public void ExitGame()
    {
        Application.Quit();
    }

    /**
     * Stops the timer if the game is won
     */
    void GameWon()
    {
        _gameStillRunning = false;
    }
}