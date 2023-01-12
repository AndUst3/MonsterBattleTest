using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _enemy;

    private float _distanceBetweenPlayerToEnemy;
    private float _cameraPositionX;
    private float _minCameraDistance;
    private float _maxCameraDistance;

    private void Awake()
    {
        _minCameraDistance = -6.7f;
        _maxCameraDistance = -60f;
    }

    void LateUpdate()
    {
        _cameraPositionX = (_player.position.x + _enemy.transform.position.x) * 0.5f;
        _distanceBetweenPlayerToEnemy = Vector3.Distance(_player.transform.position, _enemy.transform.position);

        CountCurrentCameraPosition();
    }

    private void CountCurrentCameraPosition()
    {
        if (-_distanceBetweenPlayerToEnemy * 2.5f < _minCameraDistance)
        {
            transform.position = CameraPosAtApproach();
        }

        else
        {
            transform.position = CameraPosToMinDistance();
        }

        if (-_distanceBetweenPlayerToEnemy * 2.5f > _maxCameraDistance)
        {
            transform.position = ChangeCameraPosAfterPart();
        }

        else
        {
            transform.position = CameraPosToMaxDistance();
        }
    }

    private Vector3 CameraPosToMinDistance()
    {
        return new Vector3(_cameraPositionX, transform.position.y, _minCameraDistance);
    }

    private Vector3 CameraPosToMaxDistance()
    {
        return new Vector3(_cameraPositionX, transform.position.y, _maxCameraDistance);
    }

    private Vector3 CameraPosAtApproach()
    {
        return new Vector3(_cameraPositionX, transform.position.y, -_distanceBetweenPlayerToEnemy * 2.5f);
    }

    private Vector3 ChangeCameraPosAfterPart()
    {
        return new Vector3(_cameraPositionX, transform.position.y, transform.position.z - _player.position.z);
    }
}
