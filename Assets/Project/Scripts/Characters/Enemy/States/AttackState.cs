using System.Threading.Tasks;
using UnityEngine;

public class AttackState : BaseState<EnemyState>
    {
        public AttackState(BaseStateMachine<EnemyState> stateMachine,
            EnemyMovementContext movementContext,
            EnemyAnimationContext animationContext)
            : base(stateMachine, movementContext, animationContext)
        {
        }

        public override void EnterState()
        {
            AnimationContext.IsAttack = true;
        }

        public override void UpdateState()
        {
            if (AnimationContext.IsAnimationAttack && AnimationContext.IsAttack)
            {
                AnimationContext.IsAttack = false;
                ExitFromStateByDelayAsync(AnimationContext.CurrentAnimationLenght - 0.15f);
            }
        }

        public override void ExitState()
        {
        }

        private async void ExitFromStateByDelayAsync(float delay)
        {
            await Task.Delay((int)(delay * 1000));
            SwitchState(EnemyState.Idle);
        }
    }
