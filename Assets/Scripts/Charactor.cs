using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactor : MonoBehaviour {
	public CharData data;
	Animator animator;
	SpriteRenderer renderer;

	string stateState = "State";
	string stateAttack = "Attack2";
	int stateStateHash, stateAttackHash;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		renderer = GetComponent<SpriteRenderer> ();
		stateStateHash = Animator.StringToHash (stateState);
		stateAttackHash = Animator.StringToHash (stateAttack);
	}

	//-------------------------------------
	//Animation end is calll....
	void AnimationAttackComplete(){
		Debug.Log ("AnimationAttackComplete > ");
		ChangeState("Char001_Idle");
		//ChangeState (AnimState.Idle);		
	}

	void InvokeStateIdle(int _x){
		Debug.Log ("InvokeStateIdle > " + _x);
		//animator.SetInteger (stateHash, (int)AnimState.Idle);
		//ChangeState (AnimState.Idle);
	}

	void ChangeState(AnimState _state){
		Debug.Log ("ChangeState > " + _state + " > " + ((int)_state));
		animator.SetInteger (stateStateHash, (int)_state);
	}


	void ChangeState(string _name){
		animator.Play (_name);
	}

	//-------------------------------------
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			ChangeState (AnimState.Idle);
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			ChangeState (AnimState.Move);
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			ChangeState (AnimState.Attack01);
		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			animator.SetTrigger (stateAttackHash);
		} else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			//ChangeState (AnimState.Attack03);
			ChangeState("Char001_Attack03");
		} else if (Input.GetKeyDown (KeyCode.Alpha6)) {
			ChangeState (AnimState.Skill01);
		} else if (Input.GetKeyDown (KeyCode.Alpha7)) {
			ChangeState (AnimState.Skill02);
		}		
	}

	//----------------------------------

	[System.Serializable]
	public class CharData  {
		public CharType type;
		public float level;

		public float hp;
		public float hpmax;
		public float mp;
		public float mpmax;
		public float tp;
		public float tpmax;
	}
}
