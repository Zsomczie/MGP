using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] InputActionReference moveAction;
    [SerializeField] InputActionReference gyroMoveAction;
    [SerializeField] PlayerInputHandler playerInputHandler;
    [SerializeField] float moveSpeed;
    [SerializeField] float playerSpeed = 7f;
    [SerializeField] bool isGyro;

    private void Update()
    {
        if (!isGyro)
        {
            Vector3 moveDirection = new Vector3(moveAction.action.ReadValue<Vector2>().x, 0, playerSpeed);
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
        else 
        {
            Vector3 moveDirectionGyro = new Vector3(gyroMoveAction.action.ReadValue<Vector3>().x,0,playerSpeed);
            transform.Translate(moveDirectionGyro*moveSpeed*Time.deltaTime);
        }
    }
}
