using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LeftChatDialog : MonoBehaviour
{
    [Header("UI ���")]
    public Text _TextLabel;//�ı���
    public Image _FaseImage;//ͷ��

    [Header("�ı��ļ�")]
    public TextAsset _TextFile;
    public int _Index;//���

    [Header("ͷ��")]
    public Sprite _Face01, _Face02, _Face03;

    //�ַ���ʾ�ٶ�
    public float _TextSpeed = 0.1f;
    //�ַ��Ƿ���ʾ��ϲ���
    bool _bTextFinished;
    //�Ƿ�ȡ����ǰ��������
    bool _bCacelTyping;


    public GameObject[] Item;
    public GameObject[] NoItem;
    public GameObject player;

    //�ı��б�
    List<string> _TextList = new List<string>();

    void Awake()
    {
        GetTextFormFile(_TextFile);
        _Index = 0;//���й���
    }
    private void OnEnable()
    {
        //_TextLabel.text = _TextList[_Index];
        //_Index++;

        //�ַ��Ƿ���ʾ��ϲ���
        _bTextFinished = true;
        _Index = 0;//���й���
        //����Э��
        StartCoroutine(SetTextUI());
    }

    void Update()
    {

  

        //if (Input.GetKeyDown(KeyCode.R) && _bTextFinished)
        //{
        //    //_TextLabel.text = _TextList[_Index];
        //    //_Index++;

        //    //����Э��
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
            _Index = 0;//���й���
            return;
        }


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //�������ִ�ж����������û��ȡ����ǰ��������
            if (_bTextFinished && !_bCacelTyping)
            {
                //����  �ı��������
                StartCoroutine(SetTextUI());
            }
            //����Ѿ���ʼִ���ı�������� �����ö������벼��
            else if (!_bTextFinished)
            {
                _bCacelTyping = !_bCacelTyping;
            }
        }

    }

    //�ļ���ȡ����
    private void GetTextFormFile(TextAsset _Flie)
    {
        _TextList.Clear();
        _Index = 0;

        //���ж�ȡ�ı��ļ�
        var _LineDate = _Flie.text.Split('\n');
        foreach (var _Line in _LineDate)
        {
            _TextList.Add(_Line);
        }
    }

    //�ı��������
    public IEnumerator SetTextUI()
    {
        //�ı��������
        _bTextFinished = false;
        _TextLabel.text = "";



        //ͷ������
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

        ////��ȡ��ǰ�ĵ���ǰ�г���
        //for (int i = 0; i < _TextList[_Index].Length; i++)
        //{
        //    //�ۼ��ַ���ʾ
        //    _TextLabel.text += _TextList[_Index][i];
        //    yield return new WaitForSeconds(_TextSpeed);
        //}

        int _letter = 0;
        //��������㵱ǰ����
        while (!_bCacelTyping && _letter < _TextList[_Index].Length - 1)
        {
            //�ۼ��ַ���ʾ
            _TextLabel.text += _TextList[_Index][_letter];
            _letter++;
            //Э�̵ȴ�ʱ��
            yield return new WaitForSeconds(_TextSpeed);
        }
        //��ֱ�������ǰ�ı����ı�
        _TextLabel.text = _TextList[_Index];

        _bCacelTyping = false;
        //�ı�������
        _bTextFinished = true;
        //�������
        _Index++;
    }
}