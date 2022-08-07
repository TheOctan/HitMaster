using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private PlatformGroupManager _platformGroupManager;
    [SerializeField] private TutorialManager _tutorialManager;
    [SerializeField] private ProgressBarView _progressBarView;
    [SerializeField] private GameOverScreenView _gameOverScreenView;

    private Transform _target;
    private List<Transform> _enemies;
    private int _killedEnemiesCount;

    private IEnemy _nearestEnemy;

    private void Start()
    {
        InitPlayerTarget();
        InitEnemies();
        InitProgressBar();

        _gameOverScreenView.OnRestartButtonClicked += OnRestartButtonClickedHandler;

        float distance = _enemies.Min(e => (e.position - _target.position).sqrMagnitude);
        _nearestEnemy = _enemies.First(e => (e.position - _target.position).sqrMagnitude <= distance)
            .GetComponent<IEnemy>();
    }

    private void Update()
    {
        _tutorialManager.SetTargetPosition(_nearestEnemy.HeadPosition);
    }

    private void InitPlayerTarget()
    {
        _target = _platformGroupManager.Target;
        if (_target.TryGetComponent(out IPlayer player))
        {
            player.OnDie += OnPlayerDieHandler;
            player.OnShoot += OnPlayerShootHandler;
        }
    }

    private void InitEnemies()
    {
        _enemies = _platformGroupManager.GetEnemies().ToList();
        foreach (Transform enemyTransform in _enemies)
        {
            if (enemyTransform.TryGetComponent(out IEnemy enemy))
            {
                enemy.OnDie += OnEnemyDieHandler;
            }
        }
    }

    private void InitProgressBar()
    {
        int enemiesCount = _enemies.Count;
        _progressBarView.MaximumValue = enemiesCount;
        _progressBarView.SetValue(0);
    }

    private void OnPlayerDieHandler()
    {
        _gameOverScreenView.gameObject.SetActive(true);
    }

    private void OnPlayerShootHandler()
    {
        _tutorialManager.Stop();
    }

    private void OnEnemyDieHandler()
    {
        _killedEnemiesCount++;
        _progressBarView.SetValue(_killedEnemiesCount);
    }

    private static void OnRestartButtonClickedHandler()
    {
        SceneManager.LoadScene(0);
    }
}
