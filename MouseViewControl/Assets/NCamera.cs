using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NJSUnity;

public class NCamera : MonoBehaviour {

    NMouse nmouse;

	// Use this for initialization
	void Awake () {
        nmouse = new NMouse();
        nmouse.transform.position = new Vector3(0,-3,10);
        nmouse.distanceMax = 1000f;
        nmouse.panWeight = 0.2f;
        nmouse.Type(NMouse.preset.Rhino);
        nmouse.Init();
    }
	
	// Update is called once per frame
	void LateUpdate () {
        nmouse.UpdateLate();

    }
}
