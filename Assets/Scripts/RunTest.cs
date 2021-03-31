using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTest : MonoBehaviour
{
    public GameObject textObj;
    public GameObject zeroPoint;
    public GameObject imageTarget;

    private float testNum = 0;

    private Vector3 camAngle;
    private Vector3 tarAngle; 
    private Vector3 relAngle;

    private string camPosX;
    private string camPosY;
    private string camPosZ;
    private string camRotX;
    private string camRotY;
    private string camRotZ;
    
    private string allCamPosCsv;

    private string tarPosX;
    private string tarPosY;
    private string tarPosZ;
    private string tarRotX;
    private string tarRotY;
    private string tarRotZ;
    private string allTarPosCsv;

    private string relPosX;
    private string relPosY;
    private string relPosZ;
    private string relRotX;
    private string relRotY;
    private string relRotZ;
    private string allRelPosCsv;
    
    private bool testing = false;
    private float timer = 0.0f;
    private float waitTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        //Debug.Log(timer);
        if (timer <= waitTime & testing == true)
        {
            //get positions and rotations and add to string
            camPosX = this.gameObject.transform.position.x.ToString();
            camPosY = this.gameObject.transform.position.y.ToString();
            camPosZ = this.gameObject.transform.position.z.ToString();
            camAngle = this.gameObject.transform.rotation.eulerAngles;
            camRotX = camAngle.x.ToString();
            camRotY = camAngle.y.ToString();
            camRotZ = camAngle.z.ToString();
            allCamPosCsv += (timer.ToString() + "," + camPosX + "," + camPosY + "," + camPosZ + "," + camRotX + "," + camRotY + "," + camRotZ +",\n");

            tarPosX = imageTarget.transform.position.x.ToString();
            tarPosY = imageTarget.transform.position.y.ToString();
            tarPosZ = imageTarget.transform.position.z.ToString();
            tarAngle = imageTarget.transform.rotation.eulerAngles;
            tarRotX = tarAngle.x.ToString();
            tarRotY = tarAngle.y.ToString();
            tarRotZ = tarAngle.z.ToString();
            allTarPosCsv += (timer.ToString() + "," + tarPosX + "," + tarPosY + "," + tarPosZ + "," + tarRotX + "," + tarRotY + "," + tarRotZ +",\n");
            

            Pose headPose = new Pose(this.gameObject.transform.position, this.gameObject.transform.rotation);
            Pose targetPose = new Pose(imageTarget.transform.position, imageTarget.transform.rotation);
            Pose poseRelative = this.gameObject.GetComponent<RelativePose>().ComputeRelativePose(headPose, targetPose);

            relPosX = poseRelative.position.x.ToString();
            relPosY = poseRelative.position.y.ToString();
            relPosZ = poseRelative.position.z.ToString();
            relAngle = poseRelative.rotation.eulerAngles;
            relRotX = relAngle.x.ToString();
            relRotY = relAngle.y.ToString();
            relRotZ = relAngle.z.ToString();
            allRelPosCsv += (timer.ToString() + "," + relPosX + "," + relPosY + "," + relPosZ + "," + relRotX + "," + relRotY + "," + relRotZ +",\n");

            textObj.GetComponent<TextMesh>().text = (timer.ToString());
        }
        else if (timer>waitTime & testing ==true)
        {
            this.gameObject.GetComponent<RecordData>().WriteData("HeadsetPose"+ testNum +".csv", allCamPosCsv);
            this.gameObject.GetComponent<RecordData>().WriteData("TargetPose" + testNum + ".csv", allTarPosCsv);
            this.gameObject.GetComponent<RecordData>().WriteData("RelativePose" + testNum + ".csv", allRelPosCsv);
            testing = false;
        }
        else
        {
            timer = 0.0f;
        }                    
    }
    
    public void Test()
    {
        //Debug.Log("button clicked");
        testNum += 1;
        testing = true;  
        
    }

}
