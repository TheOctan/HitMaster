﻿using UnityEngine;

public class FollowState : BaseState<EnemyState>
{
    public FollowState(BaseStateMachine<EnemyState> stateMachine,
        EnemyMovementContext movementContext,
        EnemyAnimationContext animationContext)
        : base(stateMachine, movementContext, animationContext)
    {
    }

    public override void EnterState()
    {
        AnimationContext.IsFollow = true;
        MovementContext.Start();
    }

    public override void UpdateState()
    {
        AnimationContext.WalkingSpeed = MovementContext.CurrentSpeed;

        float attackDistance = MovementContext.MinDistance;
        if (MovementContext.SqrDistanceToTarget < attackDistance * attackDistance)
        {
            SwitchState(EnemyState.Attack);
        }
    }

    public override void ExitState()
    {
        AnimationContext.IsFollow = false;
        MovementContext.Stop();
    }
}