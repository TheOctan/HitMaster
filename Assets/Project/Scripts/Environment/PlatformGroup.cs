using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct PlatformGroup
{
    public IPlayerTriggerListener Platform => _platform;
    public IEnumerable<EnemyController> Enemies => _enemies;

    [SerializeField] private PlayerTriggerListener _platform;
    [SerializeField] private List<EnemyController> _enemies;
}