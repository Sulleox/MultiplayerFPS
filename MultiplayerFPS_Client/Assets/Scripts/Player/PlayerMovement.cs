using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField][Range(1f, 5f)] private float _speed = 3f;

    private Vector3 _movement = Vector3.zero;

    void Update()
    {
        if(Input.GetAxis("Vertical") != 0)
        {
            _movement = transform.forward * (_speed * Time.deltaTime) * Input.GetAxis("Vertical");
            _movement.y = 0f;
            transform.position += _movement;
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            _movement = transform.right * (_speed * Time.deltaTime) * Input.GetAxis("Horizontal");
            _movement.y = 0f;
            transform.position += _movement;
        }

    }
}
