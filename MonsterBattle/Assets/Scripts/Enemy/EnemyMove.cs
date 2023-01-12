using System.Collections;
using UnityEngine;

public class EnemyMove : CharacterAnimatoins
{
    [SerializeField] private GameObject _enemySmokeEffect;
    [SerializeField] private Transform _player;

    private Animator _enemyAnimator;

    private float _speed;
    public float _limitDistance;

    private bool _isCoroutineStart;
    private bool _isWalking;

    public bool _isNearToPlayer;
    public bool isGrounded;
    public static bool enemyWakeUp;

    private void Awake()
    {
        _enemyAnimator = GetComponent<Animator>();
        _enemySmokeEffect.gameObject.SetActive(false);
        _speed = 1.4f;
        _isWalking = false;
    }

    private void Update()
    {
        _enemySmokeEffect.transform.position = transform.position;

        if (UIController.startGame == true)
        {
            if (transform.position.x - _player.position.x < _limitDistance)
            {
                _isNearToPlayer = true;
                _isWalking = false;
            }

            else if (transform.position.x - _player.position.x > _limitDistance)
            {
                _isNearToPlayer = false;
                _isWalking = true;
            }

            if (_isWalking && !_enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("GetUp"))
            {
                MoveToPlayer();
            }

            if (_isNearToPlayer)
            {
                Stand();
            }

            if (!_enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("GetUp"))
                enemyWakeUp = false;

            else
                enemyWakeUp = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isCoroutineStart = false;
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isWalking = false;
            _enemyAnimator.enabled = false;
            _isCoroutineStart = true;
            isGrounded = false;
            _enemySmokeEffect.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            StartCoroutine(WakeUp());
            isGrounded = true;
            _enemySmokeEffect.gameObject.SetActive(false);
        }
    }

    private void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
        _enemyAnimator.SetBool(IsWalk, true);
    }

    private void Stand()
    {
        _enemyAnimator.SetBool(IsWalk, false);
    }

    IEnumerator WakeUp()
    {
        if (_isCoroutineStart)
        {
            yield return new WaitForSeconds(0.1f);
            _enemyAnimator.enabled = true;
            _enemyAnimator.SetBool(IsWalk, false);
            _enemyAnimator.SetBool(IsWakeUp, true);

            yield return new WaitForFixedUpdate();
            _enemyAnimator.SetBool(IsWakeUp, false);

            yield return new WaitForSeconds(2f);
            _isWalking = true;
        }
    }
}
