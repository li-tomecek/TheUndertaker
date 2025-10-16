using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputHandler : Singleton<InputHandler>
{
    private GameInputs _gameInputs;
    public UnityEvent ButtonPressed;
    public UnityEvent<Vector2> NewMovement;

    public void Awake()
    {
        ButtonPressed = new UnityEvent();
        NewMovement = new UnityEvent<Vector2>();
    }

    public void OnEnable()
    {
        if (_gameInputs == null)
        {
            _gameInputs = new GameInputs();
        }
        _gameInputs.Atari.Enable();
        
        _gameInputs.Atari.Interact.performed += (val) => ButtonPressed?.Invoke();
        _gameInputs.Atari.Move.performed += (val) => NewMovement?.Invoke(val.ReadValue<Vector2>());
        _gameInputs.Atari.Move.canceled += (val) => NewMovement?.Invoke(Vector2.zero);

        LockCursor();
    }

    private void OnDestroy()
    {
        _gameInputs?.Disable();
        UnlockCursor();
    }

    public void LockCursor()
    {
        Cursor.visible = false;
    }
    
        public void UnlockCursor()
    {
        Cursor.visible = true;
    }
}
