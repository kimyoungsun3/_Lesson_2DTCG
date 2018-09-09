using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharMagic : CharactorMaster {
	protected override void AnimationComplete(int _idx){
		Debug.Log ("Magic call");
	}
}