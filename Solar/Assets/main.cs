using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NJSUnity;

public class main : MonoBehaviour {
    NJSUnity.View.ViewControl viewControl;
    // Use this for initialization
    void Start () {


        viewControl = new NJSUnity.View.ViewControl();
        viewControl.distanceMax = 1000f;
        viewControl.panWeight = 0.2f;
        viewControl.Type(NJSUnity.View.ViewControl.preset.Rhino);
        viewControl.Init();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void LateUpdate()
    {
        viewControl.UpdateLate();

    }
}
