using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class TargetPoints : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    private void LateUpdate()
    {
        transform.position = Camera.main.WorldToScreenPoint(_target.transform.position);
    }
}
