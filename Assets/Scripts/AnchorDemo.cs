using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.WSA.Persistence;

public class AnchorDemo : MonoBehaviour
{
    WorldAnchorStore store;
    UnityEngine.XR.WSA.WorldAnchor worldAnchor;
	
    bool savedRoot;
    // Start is called before the first frame update
    void Awake()
    {
        WorldAnchorStore.GetAsync(StoreLoaded);

    }

    [System.Obsolete]
    private void StoreLoaded(WorldAnchorStore store)
    {
        this.store = store;
        string[] ids = this.store.GetAllIds();
        foreach (string id in ids)
        {
            //this.GetComponent<TextMesh>().text = this.GetComponent<TextMesh>().text + "\r\n" + "id " + id;
        }
        savedRoot = this.store.Load("test", this.gameObject);
        if (!savedRoot)
        {
            //this.GetComponent<TextMesh>().text = "no anchor stored, cannot load";
            this.gameObject.AddComponent<UnityEngine.XR.WSA.WorldAnchor>();
            this.store.Save("test", this.gameObject.GetComponent<UnityEngine.XR.WSA.WorldAnchor>());
            //this.GetComponent<TextMesh>().text = this.GetComponent<TextMesh>().text + "\r\n" + "saved ";
        }
        else
        {
            //this.GetComponent<TextMesh>().text = "clearing store";
            store.Delete("test");
        }

    }
	
	//note that this will fixate the object in space!
	//if you want to change its rotation/placement delete the anchor, wait till all updating is done, add the anchor again (potentially on the next frame)
}