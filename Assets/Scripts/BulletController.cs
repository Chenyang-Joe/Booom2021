using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    private Rigidbody2D _rigibody2D;
    private bool _start = false;
    private Vector2 _targetDirection;
    private float _currentSpeed = 60f;
    private bool _colliding = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigibody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(_start)
        {
            _rigibody2D.MovePosition(_rigibody2D.position + _targetDirection * _currentSpeed * Time.deltaTime);
        }

    }


    public void Launch(Vector2 direction)
    {
        _targetDirection =  direction;
        _start = true;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_colliding)
        {
            return;
        }
        
        if (string.Equals(other.gameObject.name, "Yishou"))
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Animator>().SetFloat(name: "Explode", 1f);
            _colliding = true;
            StartCoroutine(Dead());

        }
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(0.167f);
        Destroy(gameObject);
    }

}
