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
    //private var startTime = 0;
    //private var timeTaken = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //camPosX = this.gameObject.transform.position.x.ToString();
        //camPosY = this.gameObject.transform.position.y.ToString();
        //camPosZ = this.gameObject.transform.position.z.ToString();
        if (testing == true)
        {
            var startTime = Time.deltaTime;
            var timeTaken = Time.deltaTime - startTime;
            while (timeTaken <= 8)
            {
                //allCamPosCsv += (camPosX + "," + camPosY + "," + camPosZ + ",\n");
                Debug.Log(timeTaken);
                timeTaken = Time.deltaTime - startTime;
            }
            testing = false;
        }
    }
    
    public void Test()
    {
        //Debug.Log("button clicked");
        testing = true;
        
        //this.gameObject.GetComponent<RecordData>().WriteData("test.csv", allCamPosCsv);  
    }

}
