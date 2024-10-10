using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] InputActionReference moveAction;
    [SerializeField] float moveSpeed;
    [SerializeField] float playerSpeed;

    private void Update()
    {
        Vector3 moveDirection = new Vector3(moveAction.action.ReadValue<Vector2>().x, 0, playerSpeed);
        transform.Translate(moveDirection * moveSpeed*Time.deltaTime);
    }
}
