using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private PlatformGroupManager _platformGroupManager;
    [SerializeField] private ProgressBarView _progressBarView;
    [SerializeField] private GameOverScreenView _gameOverScreenView;

    private Transform _target;
    private List<Transform> _enemies;
    private int _killedEnemiesCount;

    private void Start()
    {
        InitPlayerTarget();
        InitEnemies();
        InitProgressBar();

        _gameOverScreenView.OnRestartButtonClicked += OnRestartButtonClickedHandler;
    }

    private void InitProgressBar()
    {
        int enemiesCount = _enemies.Count;
        _progressBarView.MaximumValue = enemiesCount;
        _progressBarView.SetValue(0);
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

    private void InitPlayerTarget()
    {
        _target = _platformGroupManager.Target;
        if (_target.TryGetComponent(out IPlayer player))
        {
            player.OnDie += OnPlayerDieHandler;
        }
    }

    private void OnPlayerDieHandler()
    {
        _gameOverScreenView.gameObject.SetActive(true);
    }

    private void OnEnemyDieHandler()
    {
        _killedEnemiesCount++;
        _progressBarView.SetValue(_killedEnemiesCount);
    }

    private void OnRestartButtonClickedHandler()
    {
        
    }
}
