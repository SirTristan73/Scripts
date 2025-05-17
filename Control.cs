using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Control : MonoBehaviour
{
    public static Control Instance;

    public event Action<float> _fire;
    public event Action<Vector2> _move;
    
    void Awake()
    {
        Instance = this;
    }

    public void FireCallbackContext(InputAction.CallbackContext ctx)
    {
        _fire?.Invoke(ctx.ReadValue<float>());
        Debug.Log(ctx.ReadValue<float>());
    }

    public void OnMoveCallbackContext(InputAction.CallbackContext ctx)
    {
        _move?.Invoke(ctx.ReadValue<Vector2>());
    }
}
