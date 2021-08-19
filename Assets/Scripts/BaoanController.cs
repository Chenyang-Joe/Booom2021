using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaoanController : MonoBehaviour
{
    public float speed = 10f;


    private Rigidbody2D _rigidBody2D;
    private Animator _animator;

    private Vector2 _lookDirection = Vector2.down;
    private Vector2 _currentInput;

    private float _x;
    private float _y;


    // Start is called before the first frame update
    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();


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

        if (Input.GetKey(KeyCode.RightShift))
        {
            _currentInput = movement * 2.0f;
        }
        else
        {
            _currentInput = movement;
        }
        _animator.SetFloat(name: "Speed", _currentInput.magnitude);


    }


    private void FixedUpdate()
    {
        Vector2 position = _rigidBody2D.position;
        position += _currentInput * speed * Time.deltaTime;
        _rigidBody2D.MovePosition(position);

    }




}
