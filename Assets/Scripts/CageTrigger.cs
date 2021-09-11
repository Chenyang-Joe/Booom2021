using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageTrigger : MonoBehaviour
{


    public GameObject talkUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        talkUI.SetActive(true);
        other.GetComponent<BaoanController>().Frooze();
    }




}


