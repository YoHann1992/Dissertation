using UnityEngine;
using System.Collections;

public class CameraSelector : MonoBehaviour 
{
    GameObject fpCamera;
    GameObject tpCamera;
    bool FPCameraFlag;

	// Use this for initialization
	void Start () 
    {
        //Storing the First person camera in the scene
        if (fpCamera == null)
            fpCamera = GameObject.Find("First Person Camera");          //Assign the gameObject of the First person camera to the variable

        if (tpCamera == null)
            tpCamera = GameObject.Find("FPSController");          //Assign the gameObject of the Third person camera to the variable
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (FPCameraFlag == false)
            {
                fpCamera.SetActive(true);
                tpCamera.SetActive(false);

                Debug.Log("FP Camera Active");
                
                FPCameraFlag = true;
            }
            else if (FPCameraFlag == true)
            {
                fpCamera.SetActive(false);
                tpCamera.SetActive(true);
                
                Debug.Log("FP Camera disabled");
                
                FPCameraFlag = false;
            }
        }
	}
}
