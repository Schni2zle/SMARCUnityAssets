using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStabilizer : MonoBehaviour {

    // public bool StabilizeCamera = true;

    // // Update is called once per frame
    // void Update () {
    //     if (StabilizeCamera) {
    //         // We take the downward direction of the camera
    //         // Vector3 down = -transform.up;
	// 		// // make it so that it points down;
	// 		// down.x = 0;
	// 		// down.z = 0;
    //         // Use this to define the look-at direction of the camera;
    //         // transform.LookAt(transform.position + Vector3.down, transform.parent.up);
    //         transform.LookAt(transform.position + Vector3.up, Vector3.up);

    //         // transform.LookAt(transform.position + Vector3.up);
    //     } else {
    //         transform.rotation = transform.parent.rotation;
    //     }
    // }
    // Reference to the base_link transform (replace with the actual reference to the "base_link" Transform)
    public Transform baseLinkTransform;

    void Update() {
        // Step 1: Extract the yaw (Z-axis rotation) from base_link
        Quaternion baseLinkYawOnly = Quaternion.Euler(0, transform.parent.eulerAngles.y, 0);
        
        // Step 2: Set the camera to look down along the Y-axis in world space, but keep the yaw
        Quaternion lookDownRotation = baseLinkYawOnly * Quaternion.Euler(180, 0, 0); // 90 degrees to look down

        // Apply the calculated rotation to the camera
        transform.rotation = lookDownRotation;
    }
}
