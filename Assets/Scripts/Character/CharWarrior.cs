using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharWarrior : CharactorMaster {
	public Transform targetEnemy;	//적군은 검색으로 했다는 가정...
	public float durationTime = 0.5f;
	bool bAttacking = false;
	Vector3 orginalPos;


	void OnEnable(){
		orginalPos = transform.position;
	}

	public virtual void SetTarget(Transform _t, AnimState _state){
		transform.position = orginalPos;
		StopAllCoroutines ();
		StartCoroutine (Co_MoveTaward (_t, _state));
	}

	protected IEnumerator Co_MoveTaward(Transform _target, AnimState _state){
		float _endTime = Time.time + durationTime;
		Vector3 _dir = _target.position - transform.position;
		float _distance = _dir.magnitude;
		float _speed = _distance / durationTime;

		//Char  -> Enemy
		while (Time.time < _endTime) {
			transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
			yield return null;
		}

		//Skill
		bAttacking = true;
		ChangeState (_state);
		while (bAttacking) {
			yield return null;
		}
		Debug.Log ("#### > 데미지 입히기, 이펙트 처리하기");

		//Char <- Enemy
		_endTime = Time.time + durationTime;
		while (Time.time < _endTime) {
			transform.position = Vector3.MoveTowards(transform.position, orginalPos, _speed * Time.deltaTime);
			yield return null;
		}

	}
	protected override void AnimationComplete(int _idx){
		bAttacking = false;
	}


	//-------------------------------------
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			SetTarget(targetEnemy, AnimState.Attack01);
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			SetTarget(targetEnemy, AnimState.Attack02);
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			SetTarget(targetEnemy, AnimState.Attack03);
		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			SetTarget(targetEnemy, AnimState.Skill01);
		} else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			SetTarget(targetEnemy, AnimState.Skill02);
		}		
	}
}