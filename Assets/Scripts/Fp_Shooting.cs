using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fp_Shooting : Photon.MonoBehaviour
{
	public GameObject bulletPrefab;
	public GameObject bulletCasePrefab;
	Text ammoText; 
	Text maxAmmoText; 
	public GameObject gun;
	public AudioSource audio1;
	public AudioSource audio2;
	public AudioSource audio3;
	public int maxAmmo = 10;
	public float bulletSpeed = 100f;
	public float caseSpeed = 10f;

	public Animator anim;
	bool justFired = false;
	// Use this for initializa

	void Start ()
	{
		ammoText = Globals.instance.ammoText;
		maxAmmoText = Globals.instance.maxAmmo;
		ammoText.text = maxAmmo.ToString ();
		maxAmmoText.text = maxAmmo.ToString ();
	}
	
	// Update is called once per frame
	void Update ()
	{

		int ammo = int.Parse (ammoText.text);
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
					Debug.Log (h.name + " is taking damage");
					h.photonView.RPC ("TakeDamage", PhotonTargets.All, 20);
					Debug.Log (h.name + " health is now: " + h.currentHealth);
				}

			}


			//Make the Bullet case and eject it
			GameObject bulletCase = (GameObject)Instantiate (bulletCasePrefab, cam.transform.position, cam.transform.rotation);
			bulletCase.GetComponent<Rigidbody> ().AddForce (cam.transform.right + cam.transform.forward * caseSpeed, ForceMode.Impulse);
			//Account for the bullet fired
			ammoText.text = (ammo - 1).ToString ();
			justFired = true;
			anim.SetTrigger ("IsShooting");
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
			ammoText.text = maxAmmo.ToString ();
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
