using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTest : MonoBehaviour
{
    private GameObject cameraObj;
    private string camPosX;
    private string camPosY;
    private string camPosZ;
    private string allCamPosCsv;
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
        
    }
    
    public void Test()
    {
        //Debug.Log("button clicked");
        allCamPosCsv += (camPosX + "," + camPosY + "," + camPosZ + ",\n");
        this.gameObject.GetComponent<RecordData>().WriteData("test.csv", allCamPosCsv);  
    }
}
