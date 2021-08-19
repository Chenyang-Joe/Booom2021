using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TezhongbingController : MonoBehaviour
{
    public float speed = 10f;


    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private Vector2 _lookDirection = Vector2.down;
    private Vector2 _currentInput;

    private float _x;
    private float _y;

    public GameObject Bomb;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {


        _x = Input.GetAxis("Horizontal2");
        _y = Input.GetAxis("Vertical2");

        Vector2 movement = new Vector2(_x, _y);

        if (!Mathf.Approximately(a: movement.x, b: 0.0f) || !Mathf.Approximately(a: movement.y, b: 0.0f)) ;
        {
            _lookDirection.Set(movement.x, movement.y);
            _lookDirection.Normalize();

        }


        if (movement.x > 0f)
        {
            _animator.SetFloat(name: "LookX", 1f);
        }
        else if (movement.x < 0f)
        {
            _animator.SetFloat(name: "LookX", 0f);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentInput = movement * 2.0f;
        }
        else
        {
            _currentInput = movement;
        }
        _animator.SetFloat(name: "Speed", _currentInput.magnitude);

        if (Input.GetKeyDown(KeyCode.J))
        {
            LaunchBomb();
        }


    }


    private void FixedUpdate()
    {
        Vector2 position = _rigidbody2D.position;
        position += _currentInput * speed * Time.deltaTime;
        _rigidbody2D.MovePosition(position);



    }


    private void LaunchBomb()
    {

        GameObject bomb_1 = null;
        GameObject bomb_2 = null;

        Vector2 position = _rigidbody2D.position;
        bomb_1 = Instantiate(Bomb, position + Vector2.down * 3f, Quaternion.identity);
        bomb_2 = Instantiate(Bomb, position + Vector2.down * 3f + Vector2.right * 52f, Quaternion.identity);
    }

}
