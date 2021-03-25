using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    public GameObject cameraObj;
    private string camPos;
    public bool found = false;
    public string allCamPos;
    private string camPosX;
    public string allCamPosX;
    private string camPosY;
    public string allCamPosY;

    // Start is called before the first frame update
    void Start()
    {
        cameraObj = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        camPos = cameraObj.transform.position.ToString();
        camPosX = cameraObj.transform.position.x.ToString();
        camPosY = cameraObj.transform.position.y.ToString();
        allCamPos += (camPos+"\n");
        allCamPosX += (camPosX + "\n");
        allCamPosY += (camPosY + "\n");

        this.gameObject.GetComponent<TextMesh>().text = (camPos + "\nFound = "+ found);

    }

    public void Demo()
    {
        found = true;
    }

    public void ButtonTest()
    {
        Debug.Log("button clicked");
    }
}
