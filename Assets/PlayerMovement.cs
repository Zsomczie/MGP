using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float Movespeed = 5;
    [SerializeField] private InputActionReference MovementControls;
    // Update is called once per frame
    void Update()
    {
        Vector3 MoveDirection = new Vector3(MovementControls.action.ReadValue<Vector2>().x, 
            0, 
            MovementControls.action.ReadValue<Vector2>().y);
        transform.Translate(MoveDirection * Movespeed * Time.deltaTime);
    }
}
