using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerInputs playerInputs;
    int touchCount;
    [SerializeField] GameObject bullet;

    private void Awake()
    {
        playerInputs = new PlayerInputs();
    }
    private void OnEnable()
    {
        playerInputs.Enable();
    }
    private void OnDisable()
    {
        playerInputs.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerInputs.Player.Touch.started += input => DetectTouch(input);
        playerInputs.Player.Touch.canceled += input => DetectCancel(input);
    }

    void DetectTouch(UnityEngine.InputSystem.InputAction.CallbackContext context) 
    {
        Debug.Log("Touch Started!");

        touchCount++;

        Debug.Log("Touch count: "+touchCount);

        var worldToScreenPos = Camera.main.ScreenToWorldPoint(new Vector3(context.ReadValue<Vector2>().x, context.ReadValue<Vector2>().y,10f));

        Instantiate(bullet, worldToScreenPos, Quaternion.identity);
        Debug.Log(context.ReadValue<Vector2>());
    }

    void DetectCancel(UnityEngine.InputSystem.InputAction.CallbackContext context) 
    {
        Debug.Log("Touch Canceled! "+ context.ReadValue<Vector2>().ToString());
    }

}
