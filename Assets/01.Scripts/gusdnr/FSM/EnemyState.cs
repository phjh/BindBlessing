using UnityEngine;

public class EnemyState
{
    protected EnemyMain _enemyMain;
    protected EnemyStateMachine _stateManchine;
    public EnemyStateEnum _stateEnum;

    protected Rigidbody _rigidbody;

    protected int _animBoolHash;
    protected bool _triggerCalled;
	private EnemyMain enemyMain;
	private EnemyStateMachine stateMachine;
	private string animationBoolName;

	public EnemyState(EnemyMain enemyMain, EnemyStateMachine stateMachine, string animationBoolName, EnemyStateEnum stateEnum)
    {
        _enemyMain = enemyMain;
        _stateManchine = stateMachine;
        _animBoolHash = Animator.StringToHash(animationBoolName);
        _rigidbody = enemyMain.RigidCompo;
        _stateEnum = stateEnum;
    }

	public EnemyState(EnemyMain enemyMain, EnemyStateMachine stateMachine, string animationBoolName)
	{
		this.enemyMain = enemyMain;
		this.stateMachine = stateMachine;
		this.animationBoolName = animationBoolName;
	}

	public virtual void Enter()
    {
        _enemyMain.AnimatorCompo.SetBool(_animBoolHash, true);
        _triggerCalled = false;
    }

    public virtual void UpdateState()
    {
        
    }

    public virtual void Exit()
    {
        _enemyMain.AnimatorCompo.SetBool(_animBoolHash, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        _triggerCalled = true;
    }
}
