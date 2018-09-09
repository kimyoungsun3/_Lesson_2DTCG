using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimState 
{	
	Idle 		= 0,
	Attack01, Attack02, Attack03,
	Skill01, Skill02
}

public enum CharType { 
	Warrior, Healer, Magics, Gun 
}

[System.Serializable]
public class CharData  {
	public CharType type;
	public float exp;

	public float hp, hpmax;
	public float tp, tpmax;
}

public class CharactorMaster : MonoBehaviour {
	public CharData data;
	protected Animator animator;
	protected SpriteRenderer renderer;

	string[] stateState = {
		"State", 
		"Attack01", 	"Attack02", 	"Attack03",
		"Skill01", 		"Skill02"
	};

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		renderer = GetComponent<SpriteRenderer> ();
	}

	//-------------------------------------
	//Animation end is calll....
	protected virtual void AnimationStart(int _idx){
		//Debug.Log (this + " > " + _idx);
	}

	//Animation end is calll....
	protected virtual void AnimationComplete(int _idx){
		//Debug.Log (this + " > " + _idx);
	}

	protected void ChangeState(AnimState _state){
		int _idx = (int)_state;

		switch (_state) {
		case AnimState.Idle:
			//Debug.Log ((string)_state);
			animator.SetInteger (stateState [_idx], 1);
			break;
		case AnimState.Attack01:
		case AnimState.Attack02:
		case AnimState.Attack03:
		case AnimState.Skill01:
		case AnimState.Skill02:
			animator.SetTrigger (stateState [_idx]);
			break;
		}
	}


	protected void ChangeState(string _name){
		animator.Play (_name);
	}


	//----------------------------------

}
