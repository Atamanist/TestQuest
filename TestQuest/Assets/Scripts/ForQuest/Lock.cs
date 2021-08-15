using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock:ColorItem,IHintable,IActivatableByItem<GameObject>
{
    [SerializeField]private bool _lockStatus;
    [SerializeField] private Door _lockedObject;

    private string _lockinfo;
    private string _lockLocked = "Lock locked";
    private string _lockOpened = "Lock opened";


    private void Start()
    {
        LockStatus();
    }

    public bool Activate(GameObject item)
    {
        if(item.TryGetComponent(out Key key))
        {
            if (key.Color == Color)
            {
                _lockStatus = !_lockStatus;
                LockStatus();
                _lockedObject.Activate();
                return true;
            }
            else
                _lockedObject.Wrong();
            return false;
        }
        return false;
    }


    public string ShowHint()
    {
        return _lockinfo;
    }


    private void LockStatus()
    {
        if (_lockStatus)
            _lockinfo = _lockLocked;
        else
            _lockinfo = _lockOpened;
    }

}