using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : ColorItem, IPickable,IHintable
{
    private string _keyInfo;

    private void Start()
    {
        _keyInfo = $"Key is {this.Color}";
    }

    public string ShowHint()
    {
        return _keyInfo;
    }

}
