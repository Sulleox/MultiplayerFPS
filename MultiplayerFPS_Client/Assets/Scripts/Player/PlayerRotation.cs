using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Transform _playerVision;

    void Update()
    {
        //Rotate player controller (Horizontal)
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X"), Space.Self);

        //Rotate player vision (Vertical)
        float rotation = -Input.GetAxis("Mouse Y");
        //Clamp between -80 and 80
        if(_playerVision.eulerAngles.x + rotation <= 80f || _playerVision.eulerAngles.x + rotation >= 280f)
        {
            _playerVision.Rotate(Vector3.right, rotation, Space.Self);
        }
    }
}
