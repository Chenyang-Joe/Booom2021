using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoordinateManager : MonoBehaviour
{
    public GameObject LeftPlayer;
    public Text LeftUpText;
    public Image LeftUpImage;
    public Vector2 LeftMiddlePosition;
    public float MapWith = 66f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        Vector2 _rawCoordLeft = LeftPlayer.transform.position;
        Vector2 _coordLeft = _rawCoordLeft - LeftMiddlePosition;

        LeftUpImage.rectTransform.anchoredPosition3D = new Vector3(_coordLeft.x * 370 / 66 - 185, LeftUpImage.rectTransform.anchoredPosition3D.y, LeftUpImage.rectTransform.anchoredPosition3D.z);
        print(LeftUpImage.rectTransform.anchoredPosition3D);



        //if (_coordLeft.x > 0)
        //{
        //    LeftUpText.GetComponent<Text>().text =  "ÓÒ";
        //}
        //else if (_coordLeft.x < 0)
        //{
        //    LeftUpText.GetComponent<Text>().text = "×ó";

        //}
        //else
        //{
        //    LeftUpText.GetComponent<Text>().text = "ÖÐ";

        //}

    }
}
