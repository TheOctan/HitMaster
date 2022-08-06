using System;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGroupManager : MonoBehaviour
{
    [Header("Destination")]
    [SerializeField] private Transform _target;

    [Header("Groups")]
    [SerializeField] private List<PlatformGroup> _platformGroups;

    private void Start()
    {
        AssignPlatformGroups((triggerListener, enemy) =>
        {
            enemy.SetFollowTarget(_target);
            triggerListener.OnPlayerEnter += enemy.StartFollowing;
            triggerListener.OnPlayerExit += enemy.StopFollowing;
        });
    }

    private void OnDestroy()
    {
        AssignPlatformGroups((triggerListener, enemy) =>
        {
            enemy.SetFollowTarget(null);
            triggerListener.OnPlayerEnter -= enemy.StartFollowing;
            triggerListener.OnPlayerExit -= enemy.StopFollowing;
        });
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