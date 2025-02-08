using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    private Vector2 _moveInput;
    private bool _jumpInput;
    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        _jumpInput = value.Get<float>() == 1 ? true : false;
    }

    public PlayerInputValues getInputs()
    {
        return new PlayerInputValues()
        {
            Move = _moveInput,
            Jump = _jumpInput,
        };
    }
}
