using UnityEngine;

public class HandScale : MonoBehaviour
{
    public Transform worldAncher;

    private Transform _transform;
    private Camera _camera;

    private Vector3 mouseWorldPosition;
    private Vector3 mouseScreenPosition;

    private float _cameraDistance;
    private float _maxDistance;

    private bool _isPressed;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _camera = Camera.main;
        _cameraDistance = _camera.WorldToScreenPoint(transform.position).z;
        _maxDistance = 4f;
    }
    //Этот скрипт нужно переделать на нажатие на экран
    private void Update()
    {
        if (_isPressed)
        {
            mouseScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _cameraDistance);
            mouseWorldPosition = _camera.ScreenToWorldPoint(mouseScreenPosition);

            if (Vector3.Distance(mouseWorldPosition, worldAncher.position) > _maxDistance)
            {
                _transform.position = worldAncher.position + (mouseWorldPosition - worldAncher.position).normalized * _maxDistance;
            }

            else
            {
                _transform.position = mouseWorldPosition;
            }
        }
    }

    private void OnMouseDown()
    {
        _isPressed = true;
    }

    private void OnMouseUp()
    {
        _isPressed = false;
    }
}
