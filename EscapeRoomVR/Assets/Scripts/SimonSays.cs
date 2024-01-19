using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimonSays : MonoBehaviour
{
    //[SerializeField] private GameObject[] buttons;
    [SerializeField] private GameObject[] displayField;
    private IEnumerator _colorCoroutine;

    private bool _coroutineRunning = false;
    //[SerializeField] private TextMeshPro textBox;
    private int[] _buttonsToHit = new int[5];
    
    int _counter = 0;

    private int _difficultyCounter;

    private int _buttonInputCounter = 0;

    private int[] _buttonInput = new int [5];

    private bool _rightCombination = true;
    // Start is called before the first frame update
    void Start()
    {
        RandomizeSimonSayCombination();
        
        StartCoroutine(_colorCoroutine);
    }

    void RandomizeSimonSayCombination()
    {
        int temp = -1;
        for (int i = 0; i < 5; i++)
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

    public void StartSimonSays()
    {
        if (!_coroutineRunning)
        {
            _counter = 0;
            _buttonInputCounter = 0;
            RandomizeSimonSayCombination();
            StartCoroutine(_colorCoroutine);
            _coroutineRunning = true;
        }
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (!_coroutineRunning)
            {
                _counter = 0;
                _buttonInputCounter = 0;
                RandomizeSimonSayCombination();
                StartCoroutine(_colorCoroutine);
                _coroutineRunning = true;
            }
        }
    }

    public void ButtonPressed(int id)
    {
        if (_buttonInputCounter < 5)
        {
            _buttonInput[_buttonInputCounter] = id;
            _buttonInputCounter++;
        }
        else
        {
            if(_buttonInputCounter == 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (_buttonInput[i] != _buttonsToHit[i])
                    {
                        _rightCombination = false;
                    }
                }

                if (_rightCombination)
                {
                    
                }
                _buttonInputCounter++;
            }
            
        }
    }

    IEnumerator TurnColorButton(int [] i)
    {
        Debug.Log("Counter"+_counter);
        // if (displayField.Length != 0)
        // {
            Renderer buttonRenderer = displayField[i[_counter]].GetComponent<Renderer>();
            buttonRenderer.material.SetColor("_Color",Color.green);
            yield return new WaitForSeconds(1f);
            buttonRenderer.material.SetColor("_Color", new Color(0.4245283f,0.4245283f,0.4245283f));
        //}
        _counter++;
        if (_counter < 5)
        {
            StartCoroutine(TurnColorButton(_buttonsToHit)); 
        }
        else
        {
            _coroutineRunning = false;
        }
        
    }

}
