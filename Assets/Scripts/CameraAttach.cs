using UnityEngine;
using System.Collections;

public class CameraAttach : MonoBehaviour 
{
    public GameObject FPCamera = null;          //Variable to store the first person camera
    public GameObject LockPosition = null;      //Variable to store the joint to lock the camera on
    
	// Use this for initialization
	void Start () 
    {
        //Storing the First person camera in the scene
        if (FPCamera == null)
            FPCamera = GameObject.Find("First Person Camera");  //Assign the gameObject of the First person camera to the variable

        FPCamera.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Checking whether the joint exists in the scene i.e. whether somebody is being tracked or not
        if (LockPosition == null)
        {
            //if a person is being tracked, assign the head joint to the variable
            LockPosition = GameObject.Find("Head");
        }

        //If we already have a joint to lock the camera on, lock it
        if (LockPosition != null)
        {
            //transforming the camera according to the movement of the head joint
            FPCamera.transform.position = LockPosition.transform.position;
        }
        	
	}
}
