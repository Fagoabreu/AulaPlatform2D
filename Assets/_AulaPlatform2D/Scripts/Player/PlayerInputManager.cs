using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    private Vector2 _moveInput;
    public void OnMove(InputValue value){
        _moveInput = value.Get<Vector2>();
    }

    public PlayerInputValues getInputs(){
        return new PlayerInputValues(){
            Move = _moveInput,
        };
    }
}
