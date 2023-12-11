using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackShaderControl : MonoBehaviour
{
    public Material AttackOutlineMat;
    public Color DefaultColor;
    public Color AttackColor;

	private void Start()
	{
		AttackOutlineMat.color = DefaultColor;
	}

	public void SetAttackColor()
	{
		AttackOutlineMat.color = AttackColor;
	}

	public void SetDefaultColor()
	{
		AttackOutlineMat.color = DefaultColor;
	}
}
