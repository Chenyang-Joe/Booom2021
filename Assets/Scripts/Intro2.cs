using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro2 : MonoBehaviour
{

    public Text _TextLabelL;
    public Text _TextLabelR;

    public TextAsset _TextFileL;
    public TextAsset _TextFileR;

    public Text _TextCountinueL;
    public Text _TextCountinueR;



    public float _TextSpeed = 0.1f;

    private bool _finishL = false;
    private bool _finishR = false;

    private bool _readyL = false;
    private bool _readyR = false;



    private void Update()
    {
        if (_finishL && _finishR)
        {
            if (!_readyL)
            {
                _TextCountinueL.text = "按左SHIFT以就绪";
            }

            if (!_readyR)
            {
                _TextCountinueR.text = "按右SHIFT以就绪";
            }



            if ( Input.GetKey(KeyCode.LeftShift))
            {
                _TextCountinueL.text = "已就绪";
                _readyL = true;
            }

            if (Input.GetKey(KeyCode.RightShift))
            {
                _TextCountinueR.text = "已就绪";
                _readyR = true;
            }


            if (_readyL && _readyR)
            {
                int ccc = 0;
                for (int i = 0; i <1000; i++)
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        for (int k = 0; k < 1000; k++)
                        {
                            ccc++;
                        }
                    }
                }
                SceneManager.LoadScene(3);
            }
        }
    }


    private void OnEnable()
    {
        StartCoroutine(SetTextUIL());
        StartCoroutine(SetTextUIR());


    }


    public IEnumerator SetTextUIL()
    {

        for (int i = 0; i < _TextFileL.text.Length; i++)
        {
            _TextLabelL.text += _TextFileL.text[i];

            yield return new WaitForSeconds(_TextSpeed);
        }

        _finishL = true;

    }


    public IEnumerator SetTextUIR()
    {

        for (int i = 0; i < _TextFileR.text.Length; i++)
        {
            _TextLabelR.text += _TextFileR.text[i];

            yield return new WaitForSeconds(_TextSpeed);
        }

        _finishR = true;

    }


}
