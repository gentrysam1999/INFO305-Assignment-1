using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseFinder : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject otherObject;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Pose poseThis = new Pose(this.gameObject.transform.position, this.gameObject.transform.rotation);
        Pose poseThat = new Pose(otherObject.transform.position, otherObject.transform.rotation);
        Pose poseRelative = this.gameObject.GetComponent<RelativePose>().ComputeRelativePose(poseThis, poseThat);
        Debug.Log(poseRelative);
    }
}
