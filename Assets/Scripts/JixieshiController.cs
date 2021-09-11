using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JixieshiController : MonoBehaviour
{
    public float speed = 10f;


    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private Vector2 _lookDirection = Vector2.right;
    private Vector2 _currentInput;

    private float _x;
    private float _y;

    public GameObject Bomb;
    public GameObject BombLeft;
    public GameObject BombRight;

    public float MapOffset = 72f;


    public bool HoldItem = false;

    private bool _frooze = false;


    //public Text ItemCounter;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {


        _x = Input.GetAxis("Horizontal1");
        _y = Input.GetAxis("Vertical1");

        Vector2 movement = new Vector2(_x, _y);



        if (movement.x > 0f)
        {
            _animator.SetFloat(name: "LookX", 1f);
            _lookDirection.Set(1f, 0f);

        }
        else if (movement.x < 0f)
        {
            _animator.SetFloat(name: "LookX", 0f);
            _lookDirection.Set(-1f, 0f);

        }
        else
        {
            //Dont change direction when x = 0
        }

        if (Input.GetKey(KeyCode.RightShift) && !HoldItem)
        {
            _currentInput = movement * 2.0f;
        }
        else
        {
            _currentInput = movement;
        }
        _animator.SetFloat(name: "Speed", _currentInput.magnitude);

        if (Input.GetKeyDown(KeyCode.Slash) && HoldItem)
        {
            LaunchBomb();
        }

        if (Input.GetKeyDown(KeyCode.Backslash) && HoldItem)
        {
            InstallBomb();
        }



    }


    private void FixedUpdate()
    {
        if (_frooze)
        {
            return;
        }



        Vector2 position = _rigidbody2D.position;
        position += _currentInput * speed * Time.deltaTime;
        _rigidbody2D.MovePosition(position);



    }


    private void LaunchBomb()
    {

        GameObject bomb = null;

        Vector2 position = _rigidbody2D.position;
        if (_lookDirection.x > 0f)
        {
            bomb = Instantiate(Bomb, position + Vector2.right * 3f + Vector2.down, Quaternion.identity);
        }
        else if (_lookDirection.x < 0f)
        {
            bomb = Instantiate(Bomb, position + Vector2.left * 3f + Vector2.down, Quaternion.identity);
        }

        _animator.SetFloat(name: "Hold", 0f);
        HoldItem = false;

        transform.Find("BombGrabber").GetComponent<WeaponManager>().PutDownBomb();
    }

    private void InstallBomb()
    {

        GameObject bomb1 = null;
        GameObject bomb2 = null;


        HoldItem = false;
        Vector2 position = _rigidbody2D.position;
        bomb1 = Instantiate(BombLeft, position + Vector2.down * 3f, Quaternion.identity);
        bomb2 = Instantiate(BombRight, position + Vector2.down * 3f + Vector2.right * MapOffset, Quaternion.identity);


        transform.Find("BombGrabber").GetComponent<WeaponManager>().PutDownBomb();
        //ItemCounter.GetComponent<ItemManager>().MinusOne();


        StartCoroutine(InstallAnimate());




    }
    IEnumerator InstallAnimate()
    {

        _animator.SetFloat(name: "Install", 1f);
        yield return new WaitForSeconds(1);
        _animator.SetFloat(name: "Install", 0f);
        _animator.SetFloat(name: "Hold", 0f);


    }


    public void Hold()
    {
        _animator.SetFloat(name: "Hold", 1f);
        HoldItem = true;
    }
    public void Frooze()
    {

        _frooze = true;

    }


    public void UnFrooze()
    {

        _frooze = false;

    }


}
