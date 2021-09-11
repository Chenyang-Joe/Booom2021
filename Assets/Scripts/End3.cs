using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End3 : MonoBehaviour
{

    public Text _TextLabel;
    public Text _TextCountinue;


    public TextAsset _TextFile;

    public float _TextSpeed = 0.1f;

    private bool _finish = false;


    private void Update()
    {
        if (_finish)
        {
            _TextCountinue.text = "按空格键以继续";

            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(1);
            }
        }
    }


    private void OnEnable()
    {
        StartCoroutine(SetTextUI());

    }


    public IEnumerator SetTextUI()
    {

        for (int i = 0; i < _TextFile.text.Length; i++)
        {
            _TextLabel.text += _TextFile.text[i];

            yield return new WaitForSeconds(_TextSpeed);
        }

        _finish = true;

    }
}
