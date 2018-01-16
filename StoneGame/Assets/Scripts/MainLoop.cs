using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLoop : MonoBehaviour {

    public GameObject[] stones = new GameObject[3];
    public float torque = 5.0f;
    public float minAntiGravity = 20.0f, maxAntiGavity = 40.0f;
    public float minLateralForce = -15.0f, maxLateralForce = 15.0f;
    public float minTimeBetweenStones = 1f, maxTimeBetweenStones = 3f;
    public float minX = -30f, maxX = 30f;
    public float minZ = -5f, maxZ = 5f;
    //public float minX = -30f, maxX = 30f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
