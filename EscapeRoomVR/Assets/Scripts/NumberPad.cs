using UnityEngine;
using TMPro;

    public class NumberPad : MonoBehaviour
    {
        [SerializeField] private TextMeshPro numberDisplay;
        [SerializeField] private GameObject key;
        [SerializeField] private GameObject TEstkey;
        [SerializeField] private Transform keyToSpawn;
        private int _buttonInputCounter = 0;
        private int[] _rightCombination = { 2,3,8 };
        private int[] _numberCombination = { 0,0,0 };
        private bool _codeRight = true;

        public void ButtonPressed(int id)
        {
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
                    for (int i = 0; i < 5; i++)
                    {
                        if (_numberCombination[i] != _rightCombination[i])
                        {
                            _codeRight = false;
                        }
                    }

                    if (_codeRight)
                    {
                        Instantiate(key, keyToSpawn.position - new Vector3(0,0.1f,0), Quaternion.identity);
                        _buttonInputCounter++;
                    }
                    else
                    {
                        _numberCombination = new [] { 0,0,0 };
                        _buttonInputCounter = 0;
                    }
                    
                }
            }
        }
        
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Instantiate(key, keyToSpawn.position, Quaternion.identity);
            }
        }

        public void ResetCode()
        {
            _numberCombination = new [] { 0,0,0 };
            _buttonInputCounter = 0;
            _codeRight = true;
        }
    }
