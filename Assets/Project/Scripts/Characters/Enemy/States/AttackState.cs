using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

    public class AttackState : BaseState<EnemyState>
    {
        public AttackState(BaseStateMachine<EnemyState> stateMachine,
            PlayerMovementContext movementContext,
            EnemyAnimationContext animationContext)
            : base(stateMachine/*, movementContext, animationContext*/)
        {
        }

        public override void EnterState()
        {
            // AnimationContext.IsAttack = true;
            // AnimationContext.AnimatedTool.gameObject.SetActive(true);
        }

        public override void UpdateState()
        {
            // if (AnimationContext.IsAnimationAttack && AnimationContext.IsAttack)
            // {
            //     AnimationContext.IsAttack = false;
            //     ExitFromStateByDelayAsync(AnimationContext.CurrentAnimationLenght - 0.15f);
            // }
        }

        public override void ExitState()
        {
            // AnimationContext.AnimatedTool.gameObject.SetActive(false);
        }

        private async void ExitFromStateByDelayAsync(float delay)
        {
            await Task.Delay((int)(delay * 1000));

            // if (MovementContext.IsMoved)
            // {
            //     
            //     SwitchState(PlayerState.Walk);
            // }
            // else
            // {
            //     SwitchState(PlayerState.Idle);
            // }
        }
    }
