using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    [SerializeField] private Text _hint;
    [SerializeField] private Eye _eye;

    private void Start()
    {
        _eye.ISeeHint += ShowDisplayHint;
    }

    public void ShowDisplayHint(GameObject item)
    {
        if(item!=null)
        {
            if (item.TryGetComponent(out IHintable hint))
                _hint.text = hint.ShowHint();
        }
        else
            _hint.text = null;
    }
}
