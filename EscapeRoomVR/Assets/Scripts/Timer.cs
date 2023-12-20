using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float _timeValue = 600; //600
    [SerializeField] private TextMeshPro timetext;

    void Update()
    {
        if (_timeValue > -5)
        {
            _timeValue -= Time.deltaTime;
        }
        else
        {
            //_timeValue = 0;
            if (_timeValue <= -5)
            {
                Application.Quit();
            }
        }

        DisplayTime(_timeValue);
    }

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
}