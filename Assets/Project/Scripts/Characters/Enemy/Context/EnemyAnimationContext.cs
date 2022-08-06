using UnityEngine;

public class EnemyAnimationContext
{
    private const string IS_FOLLOW_ANIMATION_KEY = "IsFollow";
    private const string IS_ATTACK_ANIMATION_KEY = "IsAttack";
    private const string WALKING_SPEED = "WalkingSpeed";

    // private const string ATTACK_ANIMATION_NAME = "DownwardAttack";

    private readonly Animator _animator;
    private readonly RagdollControl _ragdollControl;

    private readonly int _isFollowHash;
    private readonly int _isAttackHash;
    private readonly int _walkingSpeedHash;

    // public bool IsAnimationAttack =>
    //     _animator.GetCurrentAnimatorStateInfo(0).IsName(ATTACK_ANIMATION_NAME);

    // public float CurrentAnimationLenght => _animator.GetCurrentAnimatorStateInfo(0).length;

    public Vector3 PushDirection { get; set; }

    public bool IsFollow
    {
        get => _animator.GetBool(_isFollowHash);
        set => _animator.SetBool(_isFollowHash, value);
    }

    public bool IsAttack
    {
        get => _animator.GetBool(_isAttackHash);
        set => _animator.SetBool(_isAttackHash, value);
    }

    public float WalkingSpeed
    {
        get => _animator.GetFloat(_walkingSpeedHash);
        set => _animator.SetFloat(_walkingSpeedHash, value);
    }

    public EnemyAnimationContext(Animator animator, RagdollControl ragdollControl)
    {
        _animator = animator;
        _ragdollControl = ragdollControl;

        _isFollowHash = Animator.StringToHash(IS_FOLLOW_ANIMATION_KEY);
        _isAttackHash = Animator.StringToHash(IS_ATTACK_ANIMATION_KEY);
        _walkingSpeedHash = Animator.StringToHash(WALKING_SPEED);
    }

    public void DisableAnimation()
    {
        _animator.enabled = false;
    }

    public void SwitchToRagdoll()
    {
        _ragdollControl.SwitchToPhysical();
    }

    public void PushToBody()
    {
        _ragdollControl.PushToBody(PushDirection);
    }
}