using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private List<Door> _winObjects;
    [SerializeField] private GameObject _winScreen;
    private int _winScore;

    private void Start()
    {
        _winScreen.SetActive(false);
        _winScore = _winObjects.Count;
        foreach (Door i in _winObjects)
        {
            i.IWin += WinCheck;
        }
    }
    private void WinCheck()
    {
        if (_winScore <= 1)
        {
            _winScreen.SetActive(true);
        }
        else
        {
            _winScore--;
        }
    }
}

