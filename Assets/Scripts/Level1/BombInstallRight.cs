using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombInstallRight : MonoBehaviour
{
    public float DangerRadius = 5f;
    public float DelayTime = 1f;
    private float _remainingTime;
    private bool _trigger = false;
    private bool _used = false;

    private bool _initial = false;
    private bool _hasEnemy = false;
    private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Installing());
        _rigidbody = GetComponent<Rigidbody2D>();
        _remainingTime = DelayTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (!_initial || _used)
        {
            return;
        }

        _hasEnemy = DetectEnemy(DangerRadius);


        if (_hasEnemy && !_trigger )
        {
            GetComponent<Animator>().SetFloat(name: "End", 1f);
            print("Di");
            _trigger = true;
        }

        if (_trigger)
        {
            _remainingTime -= Time.deltaTime;
        }


        if (_hasEnemy && _remainingTime <= 0)
        {
            Explode(DangerRadius);
            _remainingTime = DelayTime;
            _trigger = false;
            _used = true;
        }


    }


    private bool DetectEnemy(float radius)
    {
        Vector2 _currentPosition = _rigidbody.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_currentPosition, radius);


        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.tag == "Monster")
            {
                return true;
            }
        }


        return false;
    }


    IEnumerator Installing()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Animator>().SetFloat(name: "State", 1f);

        _initial = true;

    }

    private void Explode(float radius)
    {

        print("BOOOM");
        Vector2 _currentPosition = _rigidbody.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_currentPosition, radius);


        float count = 0;
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.tag == "Monster")
            {
                count += 1;
            }
        }


        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.tag == "Monster")
            {
                colliders[i].gameObject.GetComponent<Mon1_1Controller>().ChangeNumber(count);
                colliders[i].gameObject.GetComponent<Mon1_1Controller>().Dead();
                StartCoroutine(Dispear());
            }
        }


    }

    IEnumerator Dispear()
    {
        GetComponent<Animator>().SetFloat(name: "End", 2f);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);


    }

}
