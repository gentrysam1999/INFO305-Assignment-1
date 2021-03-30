using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTest : MonoBehaviour
{
    //private GameObject cameraObj;
    private string camPosX;
    private string camPosY;
    private string camPosZ;
    private string allCamPosCsv;
    private bool testing = false;
    private float timer = 0.0f;
    private float waitTime = 5.0f;
    //private var startTime = 0;
    //private var timeTaken = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        camPosX = this.gameObject.transform.position.x.ToString();
        camPosY = this.gameObject.transform.position.y.ToString();
        camPosZ = this.gameObject.transform.position.z.ToString();
        while (testing == true)
        {
            timer += Time.deltaTime;
            if (timer <= waitTime)
            {
                allCamPosCsv += (camPosX + "," + camPosY + "," + camPosZ + ",\n");
                //Debug.Log(timer);
            }
            else
            {
                timer = 0.0f;
                this.gameObject.GetComponent<RecordData>().WriteData("test.csv", allCamPosCsv);
                testing = false;
            }                    
        }
    }
    
    public void Test()
    {
        //Debug.Log("button clicked");
        testing = true;  
        
    }

}
