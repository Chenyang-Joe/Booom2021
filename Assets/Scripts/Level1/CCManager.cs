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
        GetComponent<Text>().text = ((int)(float.Parse(GetComponent<Text>().text.Substring(0, 1)) + Num) / 1).ToString() + GetComponent<Text>().text.Substring(1, 2);
    }
}
