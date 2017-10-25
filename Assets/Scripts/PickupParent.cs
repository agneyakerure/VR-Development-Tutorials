using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PickupParent : MonoBehaviour {

	SteamVR_TrackedObject trackedObject;
	SteamVR_Controller.Device device;
	public Transform sphere;
	void Awake() {
		trackedObject = GetComponent<SteamVR_TrackedObject>();
	}
	
	void FixedUpdate() {
		device = SteamVR_Controller.Input((int)trackedObject.index);
		if(device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log("You are holding down the trigger");
		}

		if(device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log("You have squeezed the trigger completely");
		}

		if(device.GetTouchUp (SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log("You have left the trigger");
		}

		if(device.GetPress(SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log("GetPress");
		}

		if(device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log("PressDown");
		}

		if(device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log("PressUp");
		}
		if(device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad)) {
			sphere.transform.position = new Vector3(-0.62f, 0.26f, 0.63f);
			sphere.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
			sphere.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
		}
	}

	void OnTriggerStay(Collider col) {
		Debug.Log("yOU HAVE COLLID3D! " + col.name);

		if(device.GetTouch(SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log("You have collided with " + col.name);
			col.attachedRigidbody.isKinematic = true;
			col.gameObject.transform.SetParent(this.gameObject.transform);
		}
		if(device.GetTouchUp (SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log("You have left the trigger");
			col.gameObject.transform.SetParent(null);
			col.attachedRigidbody.isKinematic = false;
			
			tossObject(col.attachedRigidbody);
		}
	}

    void tossObject(Rigidbody rigidbody) {
		Transform origin = trackedObject.origin ? trackedObject.origin : trackedObject.transform.parent;
		if(origin != null) {
			rigidbody.velocity = origin.TransformVector(device.velocity);
			rigidbody.angularVelocity = origin.TransformVector(device.angularVelocity);
		}
        else {
			rigidbody.velocity = device.velocity;
			rigidbody.angularVelocity = device.angularVelocity;
		}
    }
}
