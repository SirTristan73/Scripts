using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    public static Control Instance;
    public event Action<float> _fire;
    public event Action<Vector2> _move;
    public event Action<float> _onEscape;
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
    public void OnEscapeCallbackContext(InputAction.CallbackContext ctx)
    {
        _onEscape?.Invoke(ctx.ReadValue<float>());
        SceneManager.LoadScene(SceneManagerInfo.MainMenuScene);
    }
}
