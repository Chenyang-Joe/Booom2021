using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{


    public void PickUpBomb(Sprite s)
    {
        GetComponent<SpriteRenderer>().sprite = s;


    }


    public void PutDownBomb()
    {
        GetComponent<SpriteRenderer>().sprite = null;


    }
}
