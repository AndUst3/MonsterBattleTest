using UnityEngine;

public class PlayerBodyParts : MonoBehaviour
{
    private Animator _enemyAnimator;
    private const string _enemyName = "Enemy";

    private void Start()
    {
        _enemyAnimator = GameObject.FindGameObjectWithTag(_enemyName).GetComponent<Animator>();
    }
}
