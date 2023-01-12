using UnityEngine;

public class VFXController : MonoBehaviour
{
    [SerializeField] private GameObject _playerEffect;
    [SerializeField] private GameObject _enemyEffect;
    [SerializeField] private GameObject _wallEffect;
    [SerializeField] private GameObject _upgradeEffect;
    [SerializeField] private GameObject _defenseEffect;
    [SerializeField] private Transform _playerTransfom;
    [SerializeField] private Transform _enemyTransfom;
    [SerializeField] private Transform _upgradeSpawn;

    private void Awake()
    {
        GlobalEvents.PlayerEffect.AddListener(PlayerHitEffect);
        GlobalEvents.EnemyEffect.AddListener(EnemyHitEffect);
        GlobalEvents.WallPlayerEffect.AddListener(WallPlayerEffect);
        GlobalEvents.WallEnemyEffect.AddListener(WallEnemyEffect);
        GlobalEvents.UpgradeEffect.AddListener(UpgradeEffect);
        GlobalEvents.DefenseEffect.AddListener(DefenseEffect);
    }

    private void PlayerHitEffect()
    {
        Instantiate(_playerEffect, _playerTransfom.position, Quaternion.identity);
    }

    private void EnemyHitEffect()
    {
        Instantiate(_enemyEffect, _enemyTransfom.position, Quaternion.identity);
    }

    private void WallPlayerEffect()
    {
        Instantiate(_wallEffect, _playerTransfom.position, Quaternion.identity);
    }

    private void WallEnemyEffect()
    {
        Instantiate(_wallEffect, _enemyTransfom.position, Quaternion.identity);
    }

    private void UpgradeEffect()
    {
        Instantiate(_upgradeEffect, _upgradeSpawn.position, Quaternion.identity);
    }

    private void DefenseEffect()
    {
        Instantiate(_defenseEffect, _upgradeSpawn.position, Quaternion.identity);
    }
}
