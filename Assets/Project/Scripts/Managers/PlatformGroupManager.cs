using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformGroupManager : MonoBehaviour
{
    [Header("Destination")]
    [SerializeField] private Transform _target;

    [Header("Groups")]
    [SerializeField] private List<PlatformGroup> _platformGroups;

    public Transform Target => _target;

    private void Start()
    {
        AssignPlatformGroups((triggerListener, enemy) =>
        {
            enemy.SetFollowTarget(_target);
            triggerListener.OnPlayerEnter += enemy.StartFollowing;
            triggerListener.OnPlayerExit += enemy.StopFollowing;
        });
    }

    public IEnumerable<Transform> GetEnemies()
    {
        return _platformGroups.SelectMany(
            x => x.Enemies.Select(e => e.transform));
    }

    private void AssignPlatformGroups(Action<IPlayerTriggerListener, EnemyController> callback)
    {
        foreach (PlatformGroup group in _platformGroups)
        {
            IPlayerTriggerListener triggerListener = group.Platform;
            foreach (EnemyController enemy in group.Enemies)
            {
                callback?.Invoke(triggerListener, enemy);
            }
        }
    }
}