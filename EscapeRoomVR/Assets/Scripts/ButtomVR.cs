using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ButtomVR : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    private GameObject _presser;
    private bool _isPressed;

    // Start is called before the first frame update
    private void Start()
    {
        _isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!_isPressed)
            {
                button.transform.localPosition = new Vector3(0, 0.003f, 0);
                _presser = other.gameObject;
                onPress.Invoke();
                _isPressed = true;
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _presser)
        {
            button.transform.localPosition = new Vector3(0, 0.015f, 0);
            onRelease.Invoke();
            _isPressed = false;
        }
    }
}

