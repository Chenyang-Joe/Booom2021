using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class YishouController : MonoBehaviour
{
    public float speed = 10f;


    private Rigidbody2D _rigidBody2D;
    private Animator _animator;

    private Vector2 _lookDirection = Vector2.down;
    private Vector2 _currentInput;

    private float _x;
    private float _y;
    private bool _attacking = false;

    private bool _invincible = false;
    private float _invincibleTime = 1f;
    public Image[] LifeList;
    private int _life;

    private bool _frooze = false;
    private System.Random random;

    private float _attackingTime = 1.17f;


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


        if (_invincible)
        {
            _invincibleTime -= Time.deltaTime;

            random = new System.Random();
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, random.Next(1, 1000) / 1000 * 0.4f + 0.6f);




        }


        if (_invincibleTime <= 0)
        {
            _invincible = false;
            _invincibleTime = 1f;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

        }




        if (_attacking)
        {
            _attackingTime -= Time.deltaTime;

            if (_attackingTime <= 0.3f)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(_rigidBody2D.position + Vector2.right + 2f * Vector2.down , 4);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject.tag == "Monster")
                    { 
                        colliders[i].gameObject.GetComponent<ShibingController>().Dead();
                    }
                }


            }


            return;
        }





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



        if (Input.GetKeyDown(KeyCode.J) && !_attacking)
        {
            DoAttack();
        }



    }


    private void FixedUpdate()
    {
        if (_frooze)
        {
            return;
        }


        if (_attacking)
        {
            return;
        }


        Vector2 position = _rigidBody2D.position;
        position += _currentInput * speed * Time.deltaTime;
        _rigidBody2D.MovePosition(position);

    }

    private void DoAttack()
    {

        StartCoroutine(DoingAttacking());


    }

    IEnumerator DoingAttacking()
    {
        _attacking = true;

        _animator.SetFloat(name: "Attack", 1f);
        yield return new WaitForSeconds(0.6f);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.57f);
        _animator.SetFloat(name: "Attack", 0f);

        _attacking = false;
        _attackingTime = 1.17f;

        yield return new WaitForSeconds(0.2f);
        GetComponent<AudioSource>().Stop();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (_invincible)
        {
            return;
        }

        if (string.Equals(other.gameObject.name.Substring(0, 3), "Bul"))
        {
            _invincible = true;
            //_animator.SetFloat(name: "Damage", 1);
            _life -= 1;
            if (_life < 0)
            {
                SceneManager.LoadScene(7);
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
