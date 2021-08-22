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
        GetComponent<Text>().text = ((int)(float.Parse(GetComponent<Text>().text.Substring(0, 1))-1)/1).ToString() + GetComponent<Text>().text.Substring(1, 2);
        if (float.Parse(GetComponent<Text>().text.Substring(0, 1))==0)
        {
            float.Parse(GetComponent<Text>().text.Substring(0, 1));
            SceneManager.LoadScene(2);
        }
    }
}
