using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour
{

    public GameObject[] StartList;







    // Start is called before the first frame update
    void Start()
    {


        for (int i = 0; i < StartList.Length; i++)
        {
            StartList[i].SetActive(false);

        }



    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            for (int i = 0; i < StartList.Length; i++)
            {
                StartList[i].SetActive(true);

            }
        }



    }
}
