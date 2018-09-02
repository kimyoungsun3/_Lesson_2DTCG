using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimState 
{
	Idle 		= 0,
	Attack01, Attack02, Attack03,
	Skill01, Skill02
}
public class CharactorMaster : MonoBehaviour {
	//public CharData data;
	Animator animator;
	SpriteRenderer renderer;

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
	protected virtual void AnimationComplete(int _idx){
		//Debug.Log (this + " > " + _idx);
	}

	void ChangeState(AnimState _state){
		int _idx = (int)_state;

		switch (_state) {
		case AnimState.Idle:
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


	void ChangeState(string _name){
		animator.Play (_name);
	}

	//-------------------------------------
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			ChangeState (AnimState.Attack01);
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			ChangeState (AnimState.Attack02);
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			ChangeState (AnimState.Attack03);
		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			ChangeState (AnimState.Skill01);
		} else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			ChangeState (AnimState.Skill02);
		}		
	}

	//----------------------------------

	//[System.Serializable]
	//public class CharData  {
	//	public CharType type;
	//	public float level;
	//
	//	public float hp;
	//	public float hpmax;
	//	public float mp;
	//	public float mpmax;
	//	public float tp;
	//	public float tpmax;
	//}
}
