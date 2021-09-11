using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class TimeManager : MonoBehaviour
{
    public float LevelTime = 10f;
    private float _time;
    public bool NoTime = false;

    // Start is called before the first frame update
    void Start()
    {
        _time = LevelTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (_time >= 0)
        {
            _time -= Time.deltaTime;
            GetComponent<Text>().text = ((int)_time / 1).ToString();
        }
        else
        {
            NoTime = true;
            SceneManager.LoadScene(5);

        }


    }
}
