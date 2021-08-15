using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWinObject
{
    delegate void WinObject();
    event WinObject IWin;

}
