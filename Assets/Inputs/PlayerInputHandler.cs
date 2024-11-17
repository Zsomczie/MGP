using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] PlayerInputs playerInputActions;
    public InputAction GyroMove;

    private void Awake()
    {
        InitializeInputs();
    }
    void InitializeInputs() 
    {
        GyroMove = playerInputActions.Player.GyroMove;
    }
}
