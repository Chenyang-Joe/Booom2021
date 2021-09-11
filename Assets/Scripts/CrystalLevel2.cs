using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalLevel2 : MonoBehaviour
{

    public GameObject Dilei;

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

        if (string.Equals(other.gameObject.name, "Jixieshi"))
        {

            Instantiate(original: Dilei, position: transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }

}
