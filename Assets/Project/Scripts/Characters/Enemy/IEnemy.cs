using System;
using UnityEngine;

public interface IEnemy
{
    event Action OnDie;
    Vector3 HeadPosition { get; }
}