using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour,IWinObject
{
    [SerializeField] private Material _start, _red, _green;
    private Timer _timer;

    public event IWinObject.WinObject IWin;

    private void Start()
    {
        _timer = GetComponent<Timer>();
        _timer.TimeEnd += SetStart;
    }

    public void Activate()
    {
        GetComponent<MeshRenderer>().material = _green;
        IWin.Invoke();
    }

    public void Wrong()
    {
        GetComponent<MeshRenderer>().material = _red;
        _timer.SetTime();

    }

    public void SetStart()
    {
        GetComponent<MeshRenderer>().material = _start;
    }
}
