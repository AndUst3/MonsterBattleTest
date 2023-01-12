using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Image _youWin;
    [SerializeField] private Image _youLose;
    [SerializeField] private Button _restartButton;
    [SerializeField] private GameObject _gameOverMenu;

    private int _currentLevel;
    private float _timeDelay;

    private void Awake()
    {
        _youWin.gameObject.SetActive(false);
        _gameOverMenu.gameObject.SetActive(false);
        _restartButton.onClick.AddListener(Restart);
        _currentLevel = SceneManager.GetActiveScene().buildIndex;
        _timeDelay = 2.5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_currentLevel <= 5)
        {
            if (other.CompareTag("Enemy"))
            {
                _youWin.gameObject.SetActive(true);
                StartCoroutine(LevelLoader());
            }

            if (other.CompareTag("Player"))
            {
                _gameOverMenu.gameObject.SetActive(true);
            }
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(_currentLevel);
    }

    IEnumerator LevelLoader()
    {
        yield return new WaitForSeconds(_timeDelay);

        if (_currentLevel < 5)
            SceneManager.LoadScene(_currentLevel + 1);     

        else if (_currentLevel == 5)
            SceneManager.LoadScene(1);
    }
}
