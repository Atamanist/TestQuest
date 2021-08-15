using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]private Sprite _spriteItem;

    internal Sprite SpriteItem()
    {  return _spriteItem;  }
}
