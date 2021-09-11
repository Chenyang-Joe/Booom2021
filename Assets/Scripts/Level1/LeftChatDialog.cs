using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LeftChatDialog : MonoBehaviour
{
    [Header("UI 组件")]
    public Text _TextLabel;//文本框
    public Image _FaseImage;//头像

    [Header("文本文件")]
    public TextAsset _TextFile;
    public int _Index;//序号

    [Header("头像")]
    public Sprite _Face01, _Face02, _Face03;

    //字符显示速度
    public float _TextSpeed = 0.1f;
    //字符是否显示完毕布尔
    bool _bTextFinished;
    //是否取消当前独字输入
    bool _bCacelTyping;


    public GameObject[] Item;
    public GameObject[] NoItem;
    public GameObject player;

    //文本列表
    List<string> _TextList = new List<string>();

    void Awake()
    {
        GetTextFormFile(_TextFile);
        _Index = 0;//序列归零
    }
    private void OnEnable()
    {
        //_TextLabel.text = _TextList[_Index];
        //_Index++;

        //字符是否显示完毕布尔
        _bTextFinished = true;
        _Index = 0;//序列归零
        //开启协程
        StartCoroutine(SetTextUI());
    }

    void Update()
    {

  

        //if (Input.GetKeyDown(KeyCode.R) && _bTextFinished)
        //{
        //    //_TextLabel.text = _TextList[_Index];
        //    //_Index++;

        //    //开启协程
        //    StartCoroutine(SetTextUI());
        //}
        //
        if (Input.GetKeyDown(KeyCode.LeftShift) && _Index == _TextList.Count)
        {


            player.GetComponent<TezhongbingController>().UnFrooze();


            for (int i = 0; i < Item.Length; i++)
            {
                Item[i].SetActive(true);

            }

            for (int i = 0; i < NoItem.Length; i++)
            {
                NoItem[i].SetActive(false);

            }


            _TextLabel.transform.parent.gameObject.SetActive(false);
            _Index = 0;//序列归零
            return;
        }


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //如果正在执行独字输出并且没有取消当前独字输入
            if (_bTextFinished && !_bCacelTyping)
            {
                //开启  文本输出方法
                StartCoroutine(SetTextUI());
            }
            //如果已经开始执行文本输出方法 就设置独字输入布尔
            else if (!_bTextFinished)
            {
                _bCacelTyping = !_bCacelTyping;
            }
        }

    }

    //文件读取方法
    private void GetTextFormFile(TextAsset _Flie)
    {
        _TextList.Clear();
        _Index = 0;

        //逐行读取文本文件
        var _LineDate = _Flie.text.Split('\n');
        foreach (var _Line in _LineDate)
        {
            _TextList.Add(_Line);
        }
    }

    //文本输出方法
    public IEnumerator SetTextUI()
    {
        //文本正在输出
        _bTextFinished = false;
        _TextLabel.text = "";



        //头像设置
        switch (int.Parse(_TextList[_Index]))
        {
            case 1:
                _FaseImage.color = new Color(1, 1, 1, 1);
                _FaseImage.sprite = _Face01;
                _Index++;
                break;
            case 2:
                _FaseImage.color = new Color(1, 1, 1, 1);
                _FaseImage.sprite = _Face02;
                _Index++;
                break;
            case 3:
                _FaseImage.color = new Color(1, 1, 1, 1);
                _FaseImage.sprite = _Face03;
                _Index++;
                break;
            case 4:
                _FaseImage.color = new Color(1, 1, 1, 0);
                //_FaseImage.sprite = _Face04;
                _Index++;
                break;
            default:
                break;

        }

        ////获取当前文档当前行长度
        //for (int i = 0; i < _TextList[_Index].Length; i++)
        //{
        //    //累加字符显示
        //    _TextLabel.text += _TextList[_Index][i];
        //    yield return new WaitForSeconds(_TextSpeed);
        //}

        int _letter = 0;
        //如果不满足当前条件
        while (!_bCacelTyping && _letter < _TextList[_Index].Length - 1)
        {
            //累加字符显示
            _TextLabel.text += _TextList[_Index][_letter];
            _letter++;
            //协程等待时间
            yield return new WaitForSeconds(_TextSpeed);
        }
        //就直接输出当前文本行文本
        _TextLabel.text = _TextList[_Index];

        _bCacelTyping = false;
        //文本输出完毕
        _bTextFinished = true;
        //序号增加
        _Index++;
    }
}