using System;
using UnityEngine;

[Serializable]
public struct PlayerInputValues
{
    public Vector2 Move{
        get{ return _move;}
        set{ _move = value; }
    }
    
    private Vector2 _move;
}
