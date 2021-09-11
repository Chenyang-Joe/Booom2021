using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MCManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void MinusOne()
    {
        char[] separator = { '/' };
        string str = GetComponent<Text>().text;
        string[] arr = str.Split(separator);


        GetComponent<Text>().text = ((int)(float.Parse(arr[0])-1)/1).ToString() +'/' + arr[1];
        if (float.Parse(arr[0]) == 1f)
        {
            SceneManager.LoadScene(6);
        }
    }
}
