using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] Rigidbody2D _rig;
    [SerializeField] Vector3 _move;


    bool _facingRight;
    bool _facingUp;

    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        _rig.velocity = new Vector2(_move.x, _move.y) * _speed;

        if (_move.x > 0 && _facingRight == true)
        {
            flip();
        }
        else if (_move.x < 0 && _facingRight == false)
        {
            flip();
        }

        if (_move.y < 0 && _facingUp == true)
        {
            flipY();
        }
        else if (_move.y > 0 && _facingUp == false)
        {
            flipY();
        }
    }

    public void SetMove(InputAction.CallbackContext value)
    {
        _move = value.ReadValue<Vector3>();
    }

    void flip()
    {
        _facingRight = !_facingRight;
        float x = transform.localScale.x;
        x *= -1;

        transform.localScale = new Vector2(x, transform.localScale.y);
    }

    void flipY()
    {
        _facingUp = !_facingUp;
        float y = transform.localScale.y;
        y *= -1;

        transform.localScale = new Vector2(transform.localScale.x, y);
    }
}
