using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardMove : MonoBehaviour
{
    public float speed = 10.0f;
    private float translation;
    private float straffe;
    private bool _move=true;

    // Update is called once per frame
    void Update()
    {
        if(_move)
        {
            float speedModifier = speed;
            // Input.GetAxis() is used to get the user's input
            // You can furthor set it on Unity. (Edit, Project Settings, Input)
            translation = Input.GetAxis("Vertical") * speedModifier * Time.deltaTime;
            straffe = Input.GetAxis("Horizontal") * speedModifier * Time.deltaTime;
            transform.Translate(straffe, 0, translation);
        }
    }

    public void Move()
    {
        _move = !_move;
    }
}
