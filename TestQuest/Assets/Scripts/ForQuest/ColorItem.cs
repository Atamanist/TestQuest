using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorItem : Item
{
    [SerializeField] private ColorType _color;

    public ColorType Color { get { return _color; } }
    public enum ColorType { red, green, blue }
}
