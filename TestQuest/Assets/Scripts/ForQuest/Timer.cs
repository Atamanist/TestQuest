using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _time;
    private float _timeCurrent;
    public delegate void EndTime();
    public event EndTime TimeEnd;

    // Update is called once per frame
    void Update()
    {
        if(_timeCurrent>0)
        {
            _timeCurrent = _timeCurrent - Time.deltaTime;
            if (_timeCurrent<0)
            {
                TimeEnd.Invoke();
            }
        }

    }

    public void SetTime()
    {
        _timeCurrent = _time;
    }
}
