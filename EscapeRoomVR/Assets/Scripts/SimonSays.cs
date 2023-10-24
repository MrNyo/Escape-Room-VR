using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimonSays : MonoBehaviour
{
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private TextMeshPro textBox;
    private int[] buttonsToHit = new int[5];
    int _counter = 0;

    private int _buttonInputCounter = 0;

    private int[] _buttonInput = new int [5];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            buttonsToHit[i] = Random.Range(0, 9);
        }
        
        StartCoroutine(TurnColorButton(buttonsToHit));
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
            for (int i = 0; i < 5; i++)
            {
                textBox.text += buttonsToHit[i];
            }
            textBox.text += "/n";
            for (int i = 0; i < 5; i++)
            {
                textBox.text += _buttonInput[i];
            }
        }
    }

    IEnumerator TurnColorButton(int [] i)
    {
        Renderer buttonRenderer = buttons[i[_counter]].GetComponent<Renderer>();
        buttonRenderer.material.SetColor("_Color",Color.green);
        yield return new WaitForSeconds(1f);
        buttonRenderer.material.SetColor("_Color",Color.red);
        _counter++;
        if (_counter < 5)
        {
            StartCoroutine(TurnColorButton(buttonsToHit)); 
        }
        
    }
}
