#pragma strict

function Start () {

}

function Update () {

}
// Destroy everything that enters the trigger

	function OnTriggerEnter (other : Collider) {
		Destroy(other.gameObject);
	}