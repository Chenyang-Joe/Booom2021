using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysAudio2 : MonoBehaviour
{

    GameObject obj = null;
    public string TagName;
    private float v = 0.8f;
    private bool _stopping = false;

    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.FindGameObjectWithTag(TagName);
        if (obj == null)
        {
            StartCoroutine(DecayOut());

        }

    }


    // Update is called once per frame
    void Update()
    {

        if (!_stopping)
        {
            obj = GameObject.FindGameObjectWithTag(TagName);
            if (obj == null)
            {
                StartCoroutine(DecayOut());
                _stopping = true;
            }
        }
    }

    IEnumerator DecayOut()
    {
        while (v > 0.001)
        {
            v -= 0.001f;
            yield return new WaitForSeconds(0.001f);
            GetComponent<AudioSource>().volume = v;
        }
        Destroy(gameObject);

    }



}
