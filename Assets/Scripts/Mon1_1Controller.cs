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
    private float _currentSpeed = 1f;



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
    private Path _path;
    private int _currentWaypoint;
    private float _nextWaypointDistance = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _seeker = GetComponent<Seeker>();


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
                AIChase();
                break;
            case 2:
                _animator.SetFloat(name: "Target", 1);
                _animator.SetFloat(name: "Burst", 1);
                AIBurst();
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

    private void AIChase()
    {
        if (_targetDistance > FollowDistance)
        {
            _monsterState = 0;
        }

        _currentSpeed = speed1;
        UpdatePath();
        MoveToTarget();

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


    private void AIBurst()
    {

    _nextWaypointDistance = 0.5f;
    _currentSpeed = speed2;
        UpdatePath();
        MoveToTarget();

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

    private void UpdatePath()
    {
        Vector2 _targetPositionVetor = Target.position;
        _seeker.StartPath(_rigidBody2D.position, _targetPositionVetor, OnPathComplete);
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            _path = p;
            _currentWaypoint = 0;
        }
    }

    private void MoveToTarget()
    {
        if (_path == null) 
        { 
            return; 
        }

        float distanceToWaypoint;
        while (true)
        {
            distanceToWaypoint = Vector2.Distance(transform.position, _path.vectorPath[_currentWaypoint]);
            if (distanceToWaypoint < _nextWaypointDistance)
            {
                if (_currentWaypoint + 1 < _path.vectorPath.Count) 
                { 
                    _currentWaypoint++; 
                }
                else 
                { 
                    _path = null; 
                    break; 
                }
            }
            else 
            { 
                break; 
            }
        }

        Vector2 _targetPoint = _path.vectorPath[_currentWaypoint];
        Vector2 _targetDirection = ( _targetPoint - _rigidBody2D.position ).normalized;
        _rigidBody2D.MovePosition(_rigidBody2D.position + _targetDirection * _currentSpeed * Time.deltaTime);



        if (_targetDirection.x >= 0)
        {
            _animator.SetFloat(name: "LookX", 1);
        }
        else
        {
            _animator.SetFloat(name: "LookX", 0);
        }
    }





    public void Dead()
    {
        StartCoroutine(Dispear());

    }


    IEnumerator Dispear()
    {
        _monsterState = 0;
        GetComponent<Animator>().SetFloat(name: "Dead", 1f);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);

    }


}
