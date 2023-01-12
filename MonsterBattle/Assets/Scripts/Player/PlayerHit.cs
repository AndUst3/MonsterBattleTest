using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHit : MonoBehaviour
{
    private GameObject _player;
    private const string _playerName = "Player";

    [SerializeField] private string _nameThisObject;
    public static string nameToChange;

    [SerializeField] private Image _circleThisBodyPart;

    private Vector3 _startScale;
    private Vector3 _firstPosition;
    private Vector3 _lastPosition;

    public static bool isHit = false;
    private bool _isFirstAttack = true;


    private int _stage = 0;
    private float _changeValue = 0;
    private float forceForShift;

    private void Start()
    {
        isHit = false;
        _player = GameObject.FindGameObjectWithTag(_playerName);
        _startScale = transform.localScale;
    }
    private void LateUpdate()
    {
        if (isHit)
        {
            PlayerAttack.isAttack = true;
            this.transform.localScale = _startScale;

            if (_stage == 1)
            {
                _player.transform.position = new Vector3(_player.transform.position.x - forceForShift, _player.transform.position.y, _player.transform.position.z);
                _changeValue -= forceForShift;
                this.gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(_lastPosition.x, _lastPosition.y, _lastPosition.z), 20f * Time.deltaTime);

                if (this.transform.position == _lastPosition)
                {
                    _stage = 2;
                }
            }

            else if (_stage == 2)
            {
                this.gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(_firstPosition.x + _changeValue, _firstPosition.y, _firstPosition.z), 20f * Time.deltaTime);
                transform.localScale = _startScale;
                if (this.transform.position == new Vector3(_firstPosition.x + _changeValue, _firstPosition.y, _firstPosition.z))
                {
                    PlayerAttack.isAttack = false;
                    _stage = 0;
                    PlayerAttack.isAttack = false;
                    isHit = false;
                    _changeValue = 0;
                }
            }
        }
    }

    private void OnMouseDown()
    {
        PlayerMouseDown();
    }

    public void PlayerMouseDown()
    {
        _firstPosition = transform.position;
        nameToChange = _nameThisObject;

        if (_isFirstAttack)
        {
            GlobalEvents.StartGame?.Invoke();
            _isFirstAttack = false;
        }

        PlayerAttack.isAttack = true;
    }

    private void OnMouseDrag()
    {
        this.transform.localScale = _startScale;
    }

    private void OnMouseUp()
    {
        Vector3 currentPos = new Vector3(_firstPosition.x - transform.position.x, _firstPosition.y - transform.position.y, _firstPosition.z - transform.position.z);

        if (currentPos.x < 0)
        {
            forceForShift = 3.5f * Time.deltaTime;
        }

        else
        {

            forceForShift = -3.5f * Time.deltaTime;
        }

        _lastPosition = new Vector3(_firstPosition.x + currentPos.x, _firstPosition.y + currentPos.y, _firstPosition.z + currentPos.z);
        isHit = true;
        _stage = 1;
    }
}
