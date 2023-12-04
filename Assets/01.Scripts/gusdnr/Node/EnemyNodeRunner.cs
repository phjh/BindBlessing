using UnityEngine;
using System.Collections.Generic;

public enum EnemyNodeEnum
{
    Idle,
    Attack,
    Die,
}

public class EnemyNodeRunner
{
    public EnemyNode CurrentNode { get; private set; }
    public Dictionary<EnemyNodeEnum, EnemyNode> StateDictionary =
        new Dictionary<EnemyNodeEnum, EnemyNode>();

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
