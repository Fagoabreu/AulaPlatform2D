using System;
using UnityEngine;

[Serializable]
public struct PlayerInputValues
{
    public Vector2 Move
    {
        get { return _move; }
        set { _move = value; }
    }

    public bool Jump
    {
        get { return _jump; }
        set { _jump = value; }
    }

    private Vector2 _move;
    private bool _jump;
}
