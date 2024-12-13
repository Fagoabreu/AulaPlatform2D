using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerInputManager _playerInputManager;
    private PlayerMovementManager _playerMovementManager;

    private void Awake() {
        _playerInputManager = GetComponent<PlayerInputManager>();
        _playerMovementManager = GetComponent<PlayerMovementManager>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInputValues inputValue = LerInput();
        Mover(inputValue);
    }

    private PlayerInputValues LerInput(){
        return _playerInputManager.getInputs();
    }
    private void Mover(PlayerInputValues playerInputValues){
        _playerMovementManager.SetInputs(playerInputValues);
    }
}
