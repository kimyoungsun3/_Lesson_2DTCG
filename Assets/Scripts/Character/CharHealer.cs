using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharHealer : CharactorMaster {
	protected override void AnimationComplete(int _idx){
		if (_idx == 1) {
			Debug.Log ("1 target Healing");
		} else if (_idx == 2) {
			Debug.Log ("all Healing");
		}
	}

	public void OneTargetHeal(){
		Debug.Log (" 1 heal");
	}

	public void AllTargetHeal(){
		Debug.Log (" All heal");
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
}
