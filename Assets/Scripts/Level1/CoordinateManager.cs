using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoordinateManager : MonoBehaviour
{
    public GameObject LeftPlayer;
    public Image LeftUpImage;
    public Image LeftSideImage;
    public Vector2 LeftMiddlePosition;

    public GameObject RightPlayer;
    public Image RightUpImage;
    public Image RightSideImage;
    public Vector2 RightMiddlePosition;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        Vector2 _rawCoordLeft = LeftPlayer.transform.position;
        Vector2 _coordLeft = _rawCoordLeft - LeftMiddlePosition;

        LeftUpImage.rectTransform.anchoredPosition3D = new Vector3(_coordLeft.x * 360 / 66 - 207 - 1/2, LeftUpImage.rectTransform.anchoredPosition3D.y, LeftUpImage.rectTransform.anchoredPosition3D.z);
        LeftSideImage.rectTransform.anchoredPosition3D = new Vector3(LeftSideImage.rectTransform.anchoredPosition3D.x, _coordLeft.y * 175 / 30, LeftSideImage.rectTransform.anchoredPosition3D.z);


        Vector2 _rawCoordRight = RightPlayer.transform.position;
        Vector2 _coordRight = _rawCoordRight - RightMiddlePosition;

        RightUpImage.rectTransform.anchoredPosition3D = new Vector3(_coordRight.x * 360 / 66 + 207 + 1/2, RightUpImage.rectTransform.anchoredPosition3D.y, RightUpImage.rectTransform.anchoredPosition3D.z);
        RightSideImage.rectTransform.anchoredPosition3D = new Vector3(RightSideImage.rectTransform.anchoredPosition3D.x, _coordRight.y * 175 / 30, RightSideImage.rectTransform.anchoredPosition3D.z);




    }
}
