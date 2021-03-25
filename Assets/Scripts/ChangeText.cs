using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    public GameObject cameraObj;
    private string camPos;
    public bool found = false;
    public string allCamPos;

    // Start is called before the first frame update
    void Start()
    {
        cameraObj = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        camPos = cameraObj.transform.position.ToString();
        allCamPos += (camPos+"\n");
        this.gameObject.GetComponent<TextMesh>().text = (camPos + "\nFound = "+ found);
        this.gameObject.GetComponent<RecordData>().WriteData("test.txt", allCamPos);
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
