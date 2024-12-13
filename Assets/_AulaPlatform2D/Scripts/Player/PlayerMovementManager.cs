using UnityEngine;
public class PlayerMovementManager : MonoBehaviour
{   
    private Vector2 _moveDirection;
    [SerializeField] private float _moveSped = 5f;

    private Rigidbody2D _rigidbody;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        ApplyForces();
    }

    private void ApplyForces(){
        //_rigidbody.AddForceX(_moveDirection.x * _moveSped);
        _rigidbody.linearVelocityX = _moveDirection.x * _moveSped;
    }

    public void SetInputs(PlayerInputValues values){
        _moveDirection = values.Move;
    }
}
