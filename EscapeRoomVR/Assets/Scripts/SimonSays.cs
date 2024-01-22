using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimonSays : MonoBehaviour
{
    //[SerializeField] private GameObject[] buttons;
    [SerializeField] private GameObject[] displayField;
    [SerializeField] private GameObject[] difficultyFieldDisplay;
    [SerializeField] private Transform keySpawnPosition;
    [SerializeField] private GameObject key;
    
    private IEnumerator _colorCoroutine;
    private bool _coroutineRunning = false;

    private int[] _buttonsToHit = new int[5];

    int _counter = 0;

    private int _combinationLength = 3;

    private int _buttonInputCounter = 0;

    private int[] _buttonInput = new int [5];

    private bool _rightCombination = true;
    private bool _challengeWon = false;


    // Start is called before the first frame update
    void Start()
    {
        RandomizeSimonSayCombination();

        StartCoroutine(_colorCoroutine);
    }

    /**
     * Randomizing the combination of buttons to press
     */
    void RandomizeSimonSayCombination()
    {
        int temp = -1;
        for (int i = 0; i < _combinationLength; i++)
        {
            _buttonsToHit[i] = Random.Range(0, 9);
            while (temp == _buttonsToHit[i])
            {
                _buttonsToHit[i] = Random.Range(0, 9);
            }

            temp = _buttonsToHit[i];
        }

        _colorCoroutine = TurnColorButton(_buttonsToHit);
    }

    /**
     * Resetting the combination and starting the display as long as is not playing currently
     */
    public void StartSimonSays()
    {
        GameEvents.current.SoundPlayed(SoundTypes.Button);
        if (!_coroutineRunning)
        {
            StartNewRun();
        }
    }

    void StartNewRun()
    {
        _counter = 0;
        _buttonInputCounter = 0;
        RandomizeSimonSayCombination();
        StartCoroutine(_colorCoroutine);
        _coroutineRunning = true;
        _rightCombination = true;
    }

    /**
     * Pressing one of the buttons
     * Saving the combination until full
     * If full check if the combination is correct
     * 
     *
     */
    public void ButtonPressed(int id)
    {
        GameEvents.current.SoundPlayed(SoundTypes.Button);
        if (_buttonInputCounter < _combinationLength && !_coroutineRunning)
        {
            _buttonInput[_buttonInputCounter] = id;

            _buttonInputCounter++;
        }
        
        if (_buttonInputCounter == _combinationLength)
        {
            for (int i = 0; i < _combinationLength; i++)
            {
                if (_buttonInput[i] != _buttonsToHit[i])
                {
                    _rightCombination = false;
                }
            }

            if (_rightCombination)
            {
                Debug.Log(_rightCombination);
                Renderer buttonRenderer = difficultyFieldDisplay[_combinationLength - 3].GetComponent<Renderer>();
                buttonRenderer.material.SetColor("_Color", Color.green);
                if (_combinationLength == 5 && !_challengeWon)
                {
                    GameEvents.current.SoundPlayed(SoundTypes.ChallengeWon);
                    Instantiate(key, keySpawnPosition.position, Quaternion.identity);
                    _challengeWon = true;
                    _buttonInputCounter++;
                }
                else
                {
                    _combinationLength++;
                    StartNewRun();
                }
                }
            else
            {
                 GameEvents.current.SoundPlayed(SoundTypes.ChallengeFailed);
                 StartNewRun();
            }

                
        }
        
    }

    /**
     * Displaying the combination by turning tiles green for 1 sec in a row
     */
    IEnumerator TurnColorButton(int[] i)
    {
        Renderer buttonRenderer = displayField[i[_counter]].GetComponent<Renderer>();
        buttonRenderer.material.SetColor("_Color", Color.green);
        yield return new WaitForSeconds(1f);
        buttonRenderer.material.SetColor("_Color", new Color(0.4245283f, 0.4245283f, 0.4245283f));
        _counter++;
        if (_counter < _combinationLength)
        {
            StartCoroutine(TurnColorButton(_buttonsToHit));
        }
        else
        {
            _coroutineRunning = false;
        }
    }
}