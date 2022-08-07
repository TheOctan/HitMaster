using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private PlatformGroupManager _platformGroupManager;
    [SerializeField] private ProgressBarView _progressBarView;

    private Transform _target;
    private List<Transform> _enemies;
    private int _killedEnemiesCount;

    private void Start()
    {
        _target = _platformGroupManager.Target;
        if (_target.TryGetComponent(out IPlayer player))
        {
            player.OnDie += OnPlayerDieHandler;
        }

        _enemies = _platformGroupManager.GetEnemies().ToList();
        foreach (Transform enemyTransform in _enemies)
        {
            if (enemyTransform.TryGetComponent(out IEnemy enemy))
            {
                enemy.OnDie += OnEnemyDieHandler;
            }
        }

        int enemiesCount = _enemies.Count;
        _progressBarView.MaximumValue = enemiesCount;
        _progressBarView.SetValue(0);
    }

    private void OnPlayerDieHandler()
    {
        
    }

    private void OnEnemyDieHandler()
    {
        _killedEnemiesCount++;
        _progressBarView.SetValue(_killedEnemiesCount);
    }
}
