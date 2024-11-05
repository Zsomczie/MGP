using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerInputs;
[CreateAssetMenu(fileName ="New Input",menuName ="Input/Input Reader")]
public class InputReader : ScriptableObject, IPlayerActions
{
    public event Action<Vector3> OnGyroMovement;
    // Start is called before the first frame update
    void OnEnable()
    {
        if (true)
        {

        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMove(InputAction.CallbackContext context) 
    {
        
    }
    public void OnTouch(InputAction.CallbackContext context)
    {

    }
    public void OnGyroMove(InputAction.CallbackContext context)
    {

    }
}
