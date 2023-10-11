using System.Collections;
using UnityEngine;

public class SimonSays : MonoBehaviour
{
    [SerializeField] private GameObject[] buttons;

    private int[] buttonsToHit = new int[5];
    int _counter = 0;
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
        Debug.Log(id);
    }

    IEnumerator TurnColorButton(int [] i)
    {
        Renderer buttonRenderer = buttons[i[_counter]].GetComponent<Renderer>();
        buttonRenderer.material.SetColor("_Color",Color.green);
        yield return new WaitForSeconds(1f);
        buttonRenderer.material.SetColor("_Color",Color.white);
        _counter++;
        if (_counter < 5)
        {
            StartCoroutine(TurnColorButton(buttonsToHit)); 
        }
        
    }
}
