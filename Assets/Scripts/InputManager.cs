using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    int touchCount;
    [SerializeField] GameObject bullet;
    private void Awake()
    {
        playerControls = new PlayerControls();
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    private void Start()
    {
        playerControls.Player.Touch.started 
            += ctx=> DetectTouch(ctx);

        playerControls.Player.Touch.canceled
            += ctx => DetectCancel(ctx);
    }
    void DetectTouch(InputAction.CallbackContext context) 
    {
        Debug.Log("Touch Detected " 
            + context.ReadValue<Vector2>().ToString());

        Debug.Log(context.phase);

        touchCount++;

        Debug.Log("Touch count: "+touchCount);

        var worldToScreenPos = Camera.main.ScreenToWorldPoint(
            new Vector3(context.ReadValue<Vector2>().x, context.ReadValue<Vector2>().y,10f));

        Instantiate(bullet, worldToScreenPos, Quaternion.identity);
    }
    void DetectCancel(InputAction.CallbackContext context)
    {
        Debug.Log("Touch Canceled "
            + context.ReadValue<Vector2>().ToString());
    }
}
