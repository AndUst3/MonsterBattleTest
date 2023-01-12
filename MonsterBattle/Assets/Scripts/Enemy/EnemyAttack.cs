using UnityEngine;

public class EnemyAttack : CharacterAnimatoins
{
    private Animator _enemyAnimator;

    private EnemyMove enemyMove;

    public static bool enemyAttack;

    private void Awake()
    {
        _enemyAnimator = GetComponent<Animator>();  
        enemyMove = GetComponent<EnemyMove>();
    }

    private void Update()
    {
        if (PlayerAnimations.playerWakeUp == false && enemyMove._isNearToPlayer == true)
        {
            _enemyAnimator.SetBool(IsAttack, true);
        }

        else if (PlayerAnimations.playerWakeUp == true && enemyMove._isNearToPlayer == false)
        {
            _enemyAnimator.SetBool(IsAttack, false);
        }

        if (_enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            enemyAttack = true;  

        else
            enemyAttack = false;
    }
}
