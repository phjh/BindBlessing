using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackShaderControl : MonoBehaviour
{
    public Material AttackOutlineMat;
    public Color DefaultColor;
    public Color AttackColor;

	[SerializeField,Range(0, 10)] private float changeTime = 1f;

	private void Start()
	{
		AttackOutlineMat.color = DefaultColor;
	}

	public void SetAttackColor()
	{
		Debug.Log("Change Attack Color");
		StopAllCoroutines();
		StartCoroutine(ColorChange(false, changeTime));
	}

	public void SetDefaultColor()
	{
		Debug.Log("Change Default Color");
		StopAllCoroutines();
		StartCoroutine(ColorChange(true, changeTime));
	}

	private IEnumerator ColorChange(bool isDefault, float time)
	{
		float curTime = 0f;
		float timeTick = 1 / time;
		Debug.Log("Start Change");
		while (curTime <= time)
		{
			curTime += Time.deltaTime * timeTick;
			if(isDefault)
			AttackOutlineMat.SetFloat("_ColorRValue", Mathf.Lerp(1, 0, curTime));
			else
			AttackOutlineMat.SetFloat("_ColorRValue", Mathf.Lerp(0, 1, curTime));
			yield return null;
		}
		if(isDefault) AttackOutlineMat.SetFloat("_ColorRValue", 0);
		else AttackOutlineMat.SetFloat("_ColorRValue", 1);
	}
}
