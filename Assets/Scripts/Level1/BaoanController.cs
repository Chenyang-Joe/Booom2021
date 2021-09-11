using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class BaoanController : MonoBehaviour
{
    public float speed = 10f;


    private Rigidbody2D _rigidBody2D;
    private Animator _animator;

    private Vector2 _lookDirection = Vector2.down;
    private Vector2 _currentInput;

    private float _x;
    private float _y;

    private bool _invincible = false;
    private float _invincibleTime = 1f;
    public Image[] LifeList;
    private int _life;

    private bool _frooze = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _life = LifeList.Length;

    }

    // Update is called once per frame
    void Update()
    {


        _x = Input.GetAxis("Horizontal1");
        _y = Input.GetAxis("Vertical1");

        Vector2 movement = new Vector2(_x, _y);

        if (!Mathf.Approximately(a: movement.x, b: 0.0f) || !Mathf.Approximately(a: movement.y, b: 0.0f)) ;
        {
            _lookDirection.Set(movement.x, movement.y);
            _lookDirection.Normalize();

        }


        if (movement.x > 0f)
        {
            _animator.SetFloat(name: "LookX",1f);
        }
        else if (movement.x < 0f)
        {
            _animator.SetFloat(name: "LookX", 0f);
        }

        if (_frooze)
        {
            return;
        }


        if (Input.GetKey(KeyCode.RightShift))
        {
            _currentInput = movement * 2.0f;
        }
        else
        {
            _currentInput = movement;
        }
        _animator.SetFloat(name: "Speed", _currentInput.magnitude);


        if (_invincible)
        {
            _invincibleTime -= Time.deltaTime;
        }

        if (_invincibleTime <= 0)
        {
            _invincible = false;
            _invincibleTime = 1f;
            _animator.SetFloat(name: "Damage", 0);


        }


    }


    private void FixedUpdate()
    {
        if (_frooze)
        {
            return;
        }


        Vector2 position = _rigidBody2D.position;
        position += _currentInput * speed * Time.deltaTime;
        _rigidBody2D.MovePosition(position);

    }



    private void OnCollisionEnter2D(Collision2D other)
    {

        if (_invincible)
        {
            return;
        }

        if (string.Equals(other.collider.name.Substring(0, 3), "Mon"))
        {
            _invincible = true;
            _animator.SetFloat(name: "Damage", 1);
            _life -= 1;
            if (_life < 0)
            {
                SceneManager.LoadScene(5);
                return;
            }
            LifeList[_life].GetComponent<Image>().color = new Color(1, 1, 1, 0);



        }
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
