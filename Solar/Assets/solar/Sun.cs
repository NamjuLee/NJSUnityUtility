using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Globalization;

using NJSUnity;

public class Sun : MonoBehaviour
{

    Scrollbar ui_Lat;
    Scrollbar ui_Day;
    Scrollbar ui_Time;
    Scrollbar ui_SunDis;
    Scrollbar ui_South;

    Toggle sunVisToggle;

    Text sunLog;

    public GameObject sunSphere;
    Solar sun;

    void Awake()
    {
        ui_Lat = GameObject.Find("ui_Lat").GetComponent<Scrollbar>();
        ui_Day = GameObject.Find("ui_Day").GetComponent<Scrollbar>();
        ui_Time = GameObject.Find("ui_Time").GetComponent<Scrollbar>();
        ui_South = GameObject.Find("ui_south").GetComponent<Scrollbar>();

        sunLog = GameObject.Find("sunLog").GetComponent<Text>();
        

        ui_SunDis = GameObject.Find("ui_SunDis").GetComponent<Scrollbar>();
        sunVisToggle = GameObject.Find("sunVisToggle").GetComponent<Toggle>();

        sun = new Solar();
        sun.southDegree = -90f;
    }


    public float Lat = 45f;
    public float Day = 100;
    public float Time = 12;




    void Update()
    {
        float theSouth = (int)(ui_South.value * 360f) - 180f; 

        float theLat = (ui_Lat.value+0.001f) * 89f;
        int theDay = (int)Mathf.Floor(((ui_Day.value + 0.001f) * 364f)+1);
        float theHour = Mathf.Floor((ui_Time.value + 0.1f) * 22f-1f);

        sun.southDegree = theSouth;
        sun.UpdateSun(theLat, theDay, theHour, theSouth);
        transform.rotation = Quaternion.LookRotation(new Vector3(-sun.VectorSun.x, -sun.VectorSun.z, -sun.VectorSun.y));

        if (sunVisToggle.isOn)
        {
            sunSphere.transform.position = new Vector3(sun.VectorSun.x, sun.VectorSun.z, sun.VectorSun.y) * ((ui_SunDis.value + 0.2f) * 20f);
            sunSphere.transform.rotation = Quaternion.LookRotation(new Vector3(-sun.VectorSun.x, -sun.VectorSun.z, -sun.VectorSun.y));
        }
        else
        {
            sunSphere.transform.position = new Vector3(-1000f, 1000f);
        }
        sunLog.text = "Latitude: " + sun.latitude + " , Day:" + (int)sun.day + " , Hour:" + (int)sun.hour + " , South:" + theSouth + " degree";
    }


    public void UpdateLat(float val)
    {
        this.Lat = val;
        UpdatePos();
    }
    public void UpdateDay(float val)
    {
        this.Day = val;
        UpdatePos();
    }
    public void UpdateTime(float val)
    {
        this.Time = val;
        UpdatePos();
    }

    void UpdatePos()
    {
        sun.UpdateSun(Lat * 90f - 0.01f, Day * 360f, Time * 24);
        transform.rotation = Quaternion.LookRotation(new Vector3(-sun.VectorSun.x, -sun.VectorSun.z, -sun.VectorSun.y));

        
        if (sunVisToggle.isOn)
        {
            sunSphere.transform.position = new Vector3(sun.VectorSun.x, sun.VectorSun.z, sun.VectorSun.y) * ((ui_SunDis.value + 0.2f) * 20f);
            sunSphere.transform.rotation = Quaternion.LookRotation(new Vector3(-sun.VectorSun.x, -sun.VectorSun.z, -sun.VectorSun.y));
        }
        else
        {
            sunSphere.transform.position = new Vector3(-1000f, 1000f);
        }
        
    }
}


