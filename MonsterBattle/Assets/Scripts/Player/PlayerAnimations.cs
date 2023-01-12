using System.Collections;
using UnityEngine;

public class PlayerAnimations : CharacterAnimatoins
{
    [SerializeField] private GameObject _playerSmokeEffect;

    private Animator _playerAnimator;

    private bool _isCoroutineStart;
    public static bool playerWakeUp;

    private void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
        _playerSmokeEffect.gameObject.SetActive(false);
        playerWakeUp = false;
    }

    private void Update()
    {
        _playerSmokeEffect.transform.position = transform.position;

        if (!_playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("HuggyBack"))
            playerWakeUp = false;

        else
            playerWakeUp = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isCoroutineStart = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _playerAnimator.enabled = false;
            _isCoroutineStart = true;
            playerWakeUp = true;
            _playerSmokeEffect.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            StartCoroutine(WakeUp());
            _playerSmokeEffect.gameObject.SetActive(false);
        }
    }

    IEnumerator WakeUp()
    {
        if (_isCoroutineStart)
        {
            yield return new WaitForSeconds(0.1f);
            _playerAnimator.enabled = true;
            _playerAnimator.SetBool(IsWakeUp, true);

            yield return new WaitForFixedUpdate();
            _playerAnimator.SetBool(IsWakeUp, false);
        }
    }
}
