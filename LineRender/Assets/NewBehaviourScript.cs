using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NJSUnity;

public class NewBehaviourScript : MonoBehaviour {


    List<Vector3> vec = new List<Vector3>();
    NPolyline pl;
    NPolyline pl2;

    GLRender gl;

    NLine ln;

    void Start()
    {
        vec.Add(new Vector3(0, 0, 0));
        vec.Add(new Vector3(10, 0, 0));
        vec.Add(new Vector3(10, 0, 10));
        vec.Add(new Vector3(0, 10, 10));
        pl = new NPolyline();

        pl.Add(vec);
        pl.ClosePolyline();
        pl.Render();


        pl2 = new NPolyline();
        pl2.Add(new Vector3(10, 10, 10));
        pl2.Add(new Vector3(10, 15f, 10));
        pl2.Add(new Vector3(11, 10f, 15));
        pl2.Add(new Vector3(5, 5, 5));
        pl2.ClosePolyline();
        pl2.Render();

        gl = new GLRender();
        gl.theColor = new Color(1, 1, 0, 1);
        gl.Add(new Vector3(-2, -2, 0));
        gl.Add(new Vector3(2, -2, 0));
        gl.Add(new Vector3(2, 2, 0));
        gl.Add(new Vector3(-2, 2, 0));

        ln = new NLine();
        
    }
    void Update(){
        pl.MovePos(1, 0, 0, 0.1f);
        ln.MoveP0(new Vector3(-0.01f, 0, -0.01f));

    }
    void OnPostRender() {
        gl.PostRender(GLRender.RenderType.POLYLINE);
        Debug.Log("post render");
    }
}



























