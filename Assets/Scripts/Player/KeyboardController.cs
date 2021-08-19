using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]

public class KeyboardController : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = gameObject.GetComponent<Player>();
    }

    void Update()
    {
        DefineMovement();
    }

    private void DefineMovement()
    {
        if (Input.GetKey(KeyCode.Space))
            _player.Jump();

        if (Input.GetKey(KeyCode.A)&&!Input.GetKey(KeyCode.Space))
        {
            _player.Direction = Player.direction.Left;

            if (Input.GetKey(KeyCode.LeftShift))
                _player.Move(true);
            else _player.Move(false);
        }

        if (Input.GetKey(KeyCode.D)&&!Input.GetKey(KeyCode.Space))
        {
            _player.Direction = Player.direction.Right;

            if (Input.GetKey(KeyCode.LeftShift))
                _player.Move(true);
            else _player.Move(false);
        }

       
    }
}
