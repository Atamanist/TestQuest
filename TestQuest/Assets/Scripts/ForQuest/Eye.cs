using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    private Camera _camera;
    private RaycastHit _hit;
    private Ray _ray;
    [SerializeField] private float _distance;
    public delegate void WhatIsee(GameObject item);
    public event WhatIsee ISeeHint;


    private void Start()
    {
        _camera = Camera.main;

    }
    private void Update()
    {
        _ray = _camera.ScreenPointToRay(new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0));
        Debug.DrawRay(transform.position, transform.rotation * new Vector3(0, 0, 1), Color.red, _distance);
        if (Physics.Raycast(_ray, out _hit, _distance))
        {
            if (_hit.collider.gameObject.TryGetComponent(out IHintable hint))
            {
                ISeeHint.Invoke(_hit.collider.gameObject);
            }
            else
                ISeeHint.Invoke(null);
        }
        else
            ISeeHint.Invoke(null);

    }
}
