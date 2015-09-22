using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kinect = Windows.Kinect;
using System;

public class ObjectManager : MonoBehaviour
{
    public Dictionary<string, Vector3> _InitialTransforms = new Dictionary<string, Vector3>();
    public Dictionary<string, Vector3> _ComponentTransforms = new Dictionary<string, Vector3>();

    private GameObject Model = null;
    private GameObject HandLeft = null;
    private GameObject HandRight = null;

    Collider[] hitColliders;
    private string ClosestObjectName;

    private int counter;
    public static bool HandRightGrabbed = false;

    // Use this for initialization
    void Start()
    {
        Model = GameObject.Find("Model");
        counter = 0;
        PrepDictionary();
    }

    private void PrepDictionary()
    {
        foreach (Transform child in Model.GetComponentInChildren<Transform>())
        {
            _InitialTransforms.Add(child.name.ToString(), child.transform.position);
            _ComponentTransforms.Add(child.name.ToString(), child.transform.position);
        }
        Debug.Log("Dictionary Prepared!");
    }

    // Update is called once per frame
    void Update()
    {
        if (HandLeft == null)
        {
            HandLeft = GameObject.Find("HandLeft");
        }

        if (HandRight == null)
        {
            HandRight = GameObject.Find("HandRight");
        }
        if (HandRight != null && HandRightGrabbed == true)
        {
            ObjectCheck();
        }
        
        if(HandRightGrabbed == false)
        {
            ClosestObjectName = null;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }

    private void ObjectCheck()
    {
        if(ClosestObjectName == null)
        {
            try
            {
                hitColliders = Physics.OverlapSphere(HandRight.transform.position, 2.0f);
            }
            catch (NullReferenceException) {}

            counter = 0;

            while (hitColliders.Length != 0 && counter < hitColliders.Length)
            {
                if ((hitColliders[counter].transform.position - HandRight.transform.position).sqrMagnitude < 3.0f)
                {
                    ClosestObjectName = hitColliders[counter].name;
                    break;
                }
                counter++;
            }
        }

        if (ClosestObjectName != null)
        {
            GameObject.Find(ClosestObjectName).transform.position = HandRight.transform.position;
            GameObject.Find(ClosestObjectName).transform.rotation = HandLeft.transform.rotation;

            _ComponentTransforms[ClosestObjectName] = HandRight.transform.position;
        }
    }

    private void Reset()
    {
        
    }
}
