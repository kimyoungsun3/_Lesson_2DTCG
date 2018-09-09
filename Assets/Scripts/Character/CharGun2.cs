using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharGun2 : CharactorMaster {
	public Transform spawnPoint;

	[Space]
	//메모리 검색. 리스트에서 나와야한다...
	public Transform tempEnemy;
	public float damage;

	//이함수를 animation event로 1번만 불러야 하는데....
	//12 frame -> 2번
	//60 frame -> 다수가 불리는데 
	//어떻게 해야 1번만 부를나요?
	//Anmation의 동작이 loop가 아니여야한다...
	protected override void AnimationComplete(int _idx){
		//Debug.Log (" > " + _idx);
		GameObject _go = PoolManager.ins.Instantiate ("Bullet2", spawnPoint.position, spawnPoint.rotation);

		Bullet2 _scp = _go.GetComponent<Bullet2> ();
		_scp.SetTarget (tempEnemy, damage);
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
