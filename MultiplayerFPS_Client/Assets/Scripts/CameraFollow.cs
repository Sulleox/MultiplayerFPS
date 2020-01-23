using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private bool _conditionsValidated = false;

    [SerializeField] private Transform _followedObject = null;

    void Start()
    {
        _conditionsValidated = GetConditionsState();

        if (_conditionsValidated)
        {
            transform.position = _followedObject.position;
            transform.LookAt(_followedObject.position + _followedObject.forward);
        }
    }

    void LateUpdate()
    {
        if (_conditionsValidated)
        {
            transform.position = _followedObject.position;
            transform.LookAt(_followedObject.position + _followedObject.forward);
        }
    }

    bool GetConditionsState()
    {
        if(_followedObject == null)
        {
            Debug.LogError("[CAMERA FOLLOW] Required transform object is null.");
            return false;
        }

        return true;
    }
}
