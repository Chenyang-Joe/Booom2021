using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Mon1_1Controller : MonoBehaviour
{

    private Rigidbody2D _rigidBody2D;
    private Animator _animator;
    public float speed1 = 2f;
    public float speed2 = 10f;



    private int _monsterState = 0;
    private float _remainingTime;
    public float timeToChangeDirection = 0.5f;
    public float timeToBurst = 2f;
    public float burstDuration = 2f;
    private Vector2 _lookDirection = Vector2.right;

    public Transform Target;
    public float FollowDistance = 12f;
    private float _targetDistance;
    private Seeker _seeker;



    // Start is called before the first frame update
    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        Seeker _seeker = GetComponent<Seeker>();


        _remainingTime = timeToChangeDirection;

    }

    // Update is called once per frame
    void Update()
    {

        _remainingTime -= Time.deltaTime;
        UpdateDistance();


    }

    private void FixedUpdate()
    {


        switch (_monsterState)
        {
            case 0:
                _animator.SetFloat(name: "Target", 0);
                _animator.SetFloat(name: "Burst", 0);
                Idle();
                break;
            case 1:
                _animator.SetFloat(name: "Target", 1);
                _animator.SetFloat(name: "Burst", 0);
                Chase();
                break;
            case 2:
                _animator.SetFloat(name: "Target", 1);
                _animator.SetFloat(name: "Burst", 1);
                Burst();
                break;
            default:
                break;
        }

    }

    private void Idle()
    {
        if (_remainingTime <= 0)
        {
            _remainingTime = timeToChangeDirection;
            _lookDirection *= -1;
            _animator.SetFloat(name: "LookX", (_lookDirection.x+1)/2);
        }

        if (_targetDistance  <= FollowDistance)
        {
            _monsterState = 1;
            _remainingTime = timeToBurst;


        }


    }

    private void Chase()
    {
        if (_targetDistance > FollowDistance)
        {
            _monsterState = 0;
        }

        Vector2 _targetPositionVetor = Target.position;
        Vector2 _targetDirection = (_targetPositionVetor - _rigidBody2D.position).normalized;
        _rigidBody2D.MovePosition(_rigidBody2D.position + _targetDirection * speed1 * Time.deltaTime);

        if (_targetDirection.x >= 0)
        {
            _animator.SetFloat(name: "LookX", 1);
        }
        else
        {
            _animator.SetFloat(name: "LookX", 0);
        }

        if (_remainingTime <= 0)
        {
            _remainingTime = burstDuration;
            _monsterState = 2;

        }


    }

    private void Burst()
    {

        Vector2 _targetPositionVetor = Target.position;
        Vector2 _targetDirection = (_targetPositionVetor - _rigidBody2D.position).normalized;
        _rigidBody2D.MovePosition(_rigidBody2D.position + _targetDirection * speed2 * Time.deltaTime);


        if (_targetDirection.x >= 0)
        {
            _animator.SetFloat(name: "LookX", 1);
        }
        else
        {
            _animator.SetFloat(name: "LookX", 0);
        }

        if (_remainingTime <= 0)
        {
            _remainingTime = timeToChangeDirection;
            _monsterState = 0;

        }
    }


    private void UpdateDistance()
    {
        Vector2 _targetPositionVetor2 = Target.position;
        _targetDistance = Vector2.Distance(Target.position, _rigidBody2D.position);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        print(other.gameObject.name);

        if (string.Equals("bomb", other.gameObject.name.Substring(0,4)) )
        {
            Destroy(gameObject);
        }


    }

}
