using System.Collections;
using UnityEngine;

public class SimonSays : MonoBehaviour
{
    [SerializeField] private GameObject[] buttons;

    private int[] buttonsToHit = new int[5];
    int _counter;
    // Start is called before the first frame update
    void Start()
    {
        
        //Renderer buttonRenderer = buttons[3].GetComponent<Renderer>();
        //buttonRenderer.material.SetColor("_Color",Color.green);
        for (int i = 0; i < 5; i++)
        {
            buttonsToHit[i] = Random.Range(0, 9);
        }

        for (int i = 0; i < 5; i++)
        {
            StartCoroutine(TurnColorButton(buttonsToHit[i]));
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.deltaTime);
        
    }
    
    IEnumerator TurnColorButton(int i)
    {
        yield return new WaitForSeconds(1f);
        Renderer buttonRenderer = buttons[i].GetComponent<Renderer>();
        buttonRenderer.material.SetColor("_Color",Color.green);
        
    }
}
