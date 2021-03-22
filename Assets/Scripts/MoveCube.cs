using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public Vector3 pos;
    public GameObject plane;
    public GameObject plane1;

    void Start()
    {
        plane1 = GameObject.Find("Plane");

    }
    // Update is called once per frame
    void Update()
    {
        pos = this.transform.position;
        this.transform.position += new Vector3(Time.deltaTime*1, 0, 0);
    }
}
