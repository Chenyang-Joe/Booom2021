using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CCManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlusNum(float Num)
    {
        char[] separator = { '/' };
        string str = GetComponent<Text>().text;
        string[] arr = str.Split(separator);


        GetComponent<Text>().text = ((int)(float.Parse(arr[0]) + Num) / 1).ToString() + '/' + arr[1];

    }
}
