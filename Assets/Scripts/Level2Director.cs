using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level2Director : MonoBehaviour
{

    GameObject obj = null;

    private bool _stopping = false;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

        if (!_stopping)
        {
            obj = GameObject.FindGameObjectWithTag("Monster");
            if (obj == null)
            {
                _stopping = true;
                SceneManager.LoadScene(7);
            }
        }
    }



}
