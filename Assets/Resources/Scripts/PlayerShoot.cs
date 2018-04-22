using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	public PlayerWeapon weapon;

	[SerializeField]
	private Camera cam;

	[SerializeField]
	private LayerMask mask;

	void Start()
	{
		if(cam == null)
		{
			Debug.LogError("PlayerShoot: No Camera Referenced!");
			this.enabled = false;
		}
	}

	void Update()
	{
		if(Input.GetButtonDown("Fire1")){
			Shoot();
		}
	}

	void Shoot()
	{
		RaycastHit _hit;
		if(Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask))
		{
			//Hit Something
			Debug.Log("We hit" + _hit.collider.name);
		}
	}

}
