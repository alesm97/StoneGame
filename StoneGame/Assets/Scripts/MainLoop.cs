using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLoop : MonoBehaviour {

    public GameObject[] stones = new GameObject[3];
    public float torque = 5.0f;
    public float minAntiGravity = 20.0f, maxAntiGavity = 40.0f;
    public float minLateralForce = -15.0f, maxLateralForce = 15.0f;
    public float minTimeBetweenStones = 1f, maxTimeBetweenStones = 3f;
    public float minX = -30f, maxX = 30f;
    public float minZ = -5f, maxZ = 5f;
    public int amountStones = 20;

    private bool enableStones = true;
    private Rigidbody rigidbody;

    // Use this for initialization
    void Start () {
        StartCoroutine(ThrowStones());
	}

    // Update is called once per frame
    void Update () {
		
	}

    private IEnumerator ThrowStones()
    {

        yield return new WaitForSeconds(3.0f);

        while (enableStones)
        {
            GameObject stone = Instantiate(stones[UnityEngine.Random.Range(0, stones.Length)]);
            stone.transform.position = new Vector3(UnityEngine.Random.Range(minX, maxX), -30, UnityEngine.Random.Range(minZ, maxZ));
            stone.transform.rotation = UnityEngine.Random.rotation;

            rigidbody = stone.GetComponent<Rigidbody>();

            rigidbody.AddTorque(Vector3.up * torque, ForceMode.Impulse);
            rigidbody.AddTorque(Vector3.right * torque, ForceMode.Impulse);
            rigidbody.AddTorque(Vector3.forward * torque, ForceMode.Impulse);

            rigidbody.AddForce(Vector3.up * UnityEngine.Random.Range(minAntiGravity, maxAntiGavity), ForceMode.Impulse);
            rigidbody.AddForce(Vector3.right * UnityEngine.Random.Range(minLateralForce, maxLateralForce), ForceMode.Impulse);

            GameManager.stonesThrown++;
            if(GameManager.stonesThrown == amountStones)
            {
                enableStones = false;
                yield return new WaitForSeconds(6.0f);
            }
            else
            {
                yield return new WaitForSeconds(UnityEngine.Random.Range(minTimeBetweenStones, maxTimeBetweenStones));
            }
            
        }

        SceneManager.LoadScene("Final");
        
    }
}
