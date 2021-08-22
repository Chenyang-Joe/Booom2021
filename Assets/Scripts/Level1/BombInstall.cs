using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombInstall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Installing());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Installing()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Animator>().SetFloat(name: "State", 1f);



    }



}
