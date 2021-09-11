using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPick : MonoBehaviour
{

    public GameObject TheBomb;
    private Sprite _sprite;

    // Start is called before the first frame update
    void Start()
    {
        _sprite = TheBomb.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (  (string.Equals(other.gameObject.name, "Tezhongbing")) && !other.GetComponent<TezhongbingController>().HoldItem)
        {
            
            other.transform.Find("BombGrabber").GetComponent<WeaponManager>().PickUpBomb(_sprite);
            other.GetComponent<TezhongbingController>().Hold();
            Destroy(gameObject);
        }
        else if ((string.Equals(other.gameObject.name, "Jixieshi")) && !other.GetComponent<JixieshiController>().HoldItem)
        {

            other.transform.Find("BombGrabber").GetComponent<WeaponManager>().PickUpBomb(_sprite);
            other.GetComponent<JixieshiController>().Hold();
            Destroy(gameObject);
        }

    }


}
