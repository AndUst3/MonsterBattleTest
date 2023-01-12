using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button _upgradeAttack;
    [SerializeField] private Button _upgradeDeff;
    [SerializeField] private GameObject _hideAfterStart;

    public static bool startGame;

    private void Awake()
    {
        GlobalEvents.StartGame.AddListener(HideUI);

        _hideAfterStart.gameObject.SetActive(true);
        startGame = false;

        _upgradeAttack.onClick.AddListener(UpgradeButton);
        _upgradeDeff.onClick.AddListener(DeffButton);
    }

    private void HideUI()
    {
        startGame = true;
        _hideAfterStart.gameObject.SetActive(false);
    }

    private void UpgradeButton()
    {
        GlobalEvents.UpgradeEffect?.Invoke();
    }

    private void DeffButton()
    {
        GlobalEvents.DefenseEffect?.Invoke();
    }
}
