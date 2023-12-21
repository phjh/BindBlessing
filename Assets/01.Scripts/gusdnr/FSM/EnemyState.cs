using UnityEngine;

public class EnemyState
{
    protected EnemyMain _enemyMain;
    protected EnemyStateMachine _stateManchine;

    protected Rigidbody _rigidbody;

    protected int _animBoolHash;
    protected bool _endTriggerCalled;
    protected bool _playingTriggerCalled;

	public EnemyState(EnemyMain enemyMain, EnemyStateMachine stateMachine, string animationBoolName)
    {
        _enemyMain = enemyMain;
        _stateManchine = stateMachine;
        _animBoolHash = Animator.StringToHash(animationBoolName);
        _rigidbody = enemyMain.RigidCompo;
    }

	public virtual void Enter()
    {
        if(_animBoolHash != 0)
        _enemyMain.AnimatorCompo.SetBool(_animBoolHash, true);
        _endTriggerCalled = false;
        _playingTriggerCalled = false;
    }

    public virtual void UpdateState()
    {
        if(_enemyMain.HP <= 0) _stateManchine.ChangeState(EnemyStateEnum.Die);
    }

    public virtual void Exit()
    {
        _enemyMain.AnimatorCompo.SetBool(_animBoolHash, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        _endTriggerCalled = true;
    }

    public virtual void AnimationPlayingTrigger()
    {
        _playingTriggerCalled = true;
    }

}
