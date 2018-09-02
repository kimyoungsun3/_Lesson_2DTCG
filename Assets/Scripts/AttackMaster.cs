using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMaster : MonoBehaviour {
	public float durationTime = 0.5f;
	public virtual void SetTarget(Transform _t, float _damage){
		StartCoroutine (Co_MoveTaward (_t, _damage));
	}

	protected IEnumerator Co_MoveTaward(Transform _target, float _damage){
		float _endTime = Time.time + durationTime;
		Vector3 _dir = _target.position - transform.position;
		float _distance = _dir.magnitude;
		float _speed = _distance / durationTime;

		while (Time.time < _endTime) {
			transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
			yield return null;
		}

		Debug.Log ("#### > 데미지 입히기");
		Debug.Log ("#### > 이펙트 처리하기");
		Destroy (gameObject);
	}
}
