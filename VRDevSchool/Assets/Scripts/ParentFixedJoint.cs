using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class ParentFixedJoint : MonoBehaviour {
	SteamVR_TrackedObject trackedObject;
	SteamVR_Controller.Device device;
	public Transform sphere;

	FixedJoint fixedJoint;
	public Rigidbody rigidBodyAttachPoint;
	void Awake () {
		trackedObject = GetComponent<SteamVR_TrackedObject>();
	}
	
	
	void FixedUpdate () {
		device = SteamVR_Controller.Input((int)trackedObject.index);

		if(device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad)) {
			sphere.transform.position = new Vector3(-0.62f, 0.26f, 0.63f);
			sphere.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
			sphere.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
		}
	}

	void OnTriggerStay(Collider col) {
		if(fixedJoint == null && device.GetTouch(SteamVR_Controller.ButtonMask.Trigger)) {
			fixedJoint = col.gameObject.AddComponent<FixedJoint>();
			fixedJoint.connectedBody = rigidBodyAttachPoint;
		}
		else if( fixedJoint != null && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger)) {
			GameObject go = fixedJoint.gameObject;
			Rigidbody rigidbody = go.GetComponent<Rigidbody>();
			Object.Destroy(fixedJoint);
			fixedJoint = null;
			tossObject(rigidbody);
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
