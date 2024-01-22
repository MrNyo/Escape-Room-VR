using System;
using UnityEngine;
using TMPro;

public class NumberPad : MonoBehaviour
{
    [SerializeField] private TextMeshPro numberDisplay;
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject spotlight;
    [SerializeField] private Transform keyToSpawn;
    private int _buttonInputCounter = 0;
    private int[] _rightCombination = { 2, 3, 8 };
    private int[] _numberCombination = { 0, 0, 0 };
    private bool _codeRight = true;

    private void Start()
    {
        spotlight.transform.rotation = Quaternion.Euler(0,84,0);
    }

    /**
     * When pressing a button it will first will the display until it's full
     * It then will check the if the combination is correct
     * If it's correct it will spawn a exit key
     * If not it resets the combination
     */
    public void ButtonPressed(int id)
    {
        GameEvents.current.SoundPlayed(SoundTypes.Button);
        if (_buttonInputCounter < 3)
        {
            _numberCombination[_buttonInputCounter] = id;

            numberDisplay.text = string.Format("{0:0}:{1:0}:{2:0}", _numberCombination[0], _numberCombination[1],
                _numberCombination[2]);

            _buttonInputCounter++;
        }
        else
        {
            if (_buttonInputCounter == 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (_numberCombination[i] != _rightCombination[i])
                    {
                        _codeRight = false;
                    }
                }

                if (_codeRight)
                {
                    GameEvents.current.SoundPlayed(SoundTypes.ChallengeWon);
                    Instantiate(key, keyToSpawn.position - new Vector3(0, 0.1f, 0), Quaternion.identity);
                    _buttonInputCounter++;
                }
                else
                {
                    GameEvents.current.SoundPlayed(SoundTypes.ChallengeFailed);
                    ResetCode();
                }
            }
        }
    }

    /**
     * Reset button pressed
     */
    public void ResetCodeButton()
    {
        GameEvents.current.SoundPlayed(SoundTypes.Button);
        ResetCode();
    }

    /**
     * Resetting the combination
     */
    private void ResetCode()
    {
        _numberCombination = new[] { 0, 0, 0 };
        numberDisplay.text = string.Format("{0:0}:{1:0}:{2:0}", _numberCombination[0], _numberCombination[1],
            _numberCombination[2]);
        _buttonInputCounter = 0;
        _codeRight = true;
    }
}