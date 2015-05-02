using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fp_Shooting : Photon.MonoBehaviour
{
	public Gun_Rifle gun_Rifle;
	public Gun_Pistol gun_Pistol;

	public GameObject bulletPrefab;
	public GameObject bulletCasePrefab;

	Text ammoText; 
	Text maxAmmoText; 

	public AudioSource audio1;
	public AudioSource audio2;
	public AudioSource audio3;

	public float caseSpeed = 10f;

	bool justFired = false;

	Gun gun;
	// Use this for initializa

	void Start ()
	{
		ammoText = Globals.instance.ammoText;
		maxAmmoText = Globals.instance.maxAmmo;

		gun_Rifle = new Gun_Rifle ();
		gun_Pistol = new Gun_Pistol ();


		SwitchGun (gun_Pistol);
	}

	void SwitchGun (Gun gun)
	{
		this.gun = gun;


		Transform parent = Camera.main.transform;
		foreach (Transform child in parent)
			Destroy (child.gameObject);

		GameObject gunGO = (GameObject)Instantiate (this.gun.gun, Vector3.zero, Quaternion.identity);
		gunGO.transform.SetParent (Camera.main.transform);
		gunGO.transform.localPosition = this.gun.gun.transform.position;
		gunGO.transform.localRotation = this.gun.gun.transform.rotation;
		ammoText.text = this.gun.currentAmmo.ToString ();
		maxAmmoText.text = this.gun.maxAmmo.ToString ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		int ammo = gun.currentAmmo;

		if (Input.GetAxisRaw ("Mouse ScrollWheel") != 0) {
			Debug.Log ("Switching weapon");
			if (gun == gun_Rifle)
				SwitchGun (gun_Pistol);
			else
				SwitchGun (gun_Rifle);
		}

		if (Input.GetButtonDown ("Fire1") && ammo > 0 || Input.GetAxis ("Fire1") == -1 && ammo > 0 && justFired == false) {
			Camera cam = Camera.main;
			//play gunshot sound
			audio1.Play ();
			//Make the bullet and shoot it
//			GameObject bullet = (GameObject)Instantiate (bulletPrefab, cam.transform.position, cam.transform.rotation);
//			bullet.GetComponent<Rigidbody> ().AddForce (cam.transform.forward * bulletSpeed, ForceMode.Impulse);

			Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
			Transform hitTransform;
			Vector3 hitPoint;

			hitTransform = FindClosestHitObject (ray, out hitPoint);

			if (hitTransform != null) {
				Debug.Log ("we hit: " + hitTransform.name);

				PlayerStats h = hitTransform.GetComponent<PlayerStats> ();

//				while(h == null && hitTransform.parent) {
//					hitTransform = hitTransform.parent;
//					h = hitTransform.GetComponent<PlayerStats>();
//				}

				if (h != null) {
					Debug.Log (PhotonPlayer.Find(h.photonPlayer).name + " is taking damage");
					h.photonView.RPC ("TakeDamage", PhotonTargets.All, 20);
					//Debug.Log (h.photonPlayer.name + " health is now: " + h.currentHealth);
				}

			}


			//Make the Bullet case and eject it
			GameObject bulletCase = (GameObject)Instantiate (bulletCasePrefab, cam.transform.position, cam.transform.rotation);
			bulletCase.GetComponent<Rigidbody> ().AddForce (cam.transform.right + cam.transform.forward * caseSpeed, ForceMode.Impulse);
			//Account for the bullet fired
			gun.currentAmmo = (ammo - 1);
			ammoText.text = gun.currentAmmo.ToString ();
			justFired = true;
			//anim.SetTrigger ("IsShooting");
		}
		if (Input.GetButton ("Fire2")) {
			Camera cam = Camera.main;
			cam.fieldOfView = 30;
		}
		if (Input.GetButtonUp ("Fire2")) {
			Camera cam = Camera.main;
			cam.fieldOfView = 90;
		}
		if (Input.GetButtonDown ("Fire1") && ammo == 0 || Input.GetAxis ("Fire1") == -1 && ammo == 0 && justFired == false) {
			audio2.Play ();
		}
		if (Input.GetButtonDown ("Fire3")) {
			audio3.Play ();
			gun.currentAmmo = gun.maxAmmo;
			ammoText.text = gun.currentAmmo.ToString ();
		}
		if (Input.GetAxis ("Fire1") == 0) {
			justFired = false;
		}
	}

	Transform FindClosestHitObject (Ray ray, out Vector3 hitPoint)
	{
		
		RaycastHit[] hits = Physics.RaycastAll (ray);
		
		Transform closestHit = null;
		float distance = 0;
		hitPoint = Vector3.zero;
		
		foreach (RaycastHit hit in hits) {
			Debug.Log (hit.transform);
			Debug.Log (this.transform);
			if (hit.transform != this.transform && (closestHit == null || hit.distance < distance)) {
				closestHit = hit.transform;
				distance = hit.distance;
				hitPoint = hit.point;
			}
			
		}

		return closestHit;
	}

	void Shoot ()
	{

	}
}
