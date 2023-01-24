using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{

    public GameObject camera1;
    public GameObject camera2;

    bool camera1Enabled=true;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            camera1Enabled=!camera1Enabled;
            if (camera1Enabled)
            {
                camera1.GetComponent<Camera>().enabled = true;
                camera1.GetComponent<AudioListener>().enabled = true;

                camera2.GetComponent<Camera>().enabled = false;
                camera2.GetComponent<AudioListener>().enabled = false;
            }
            else
            {

                camera2.GetComponent<Camera>().enabled = true;
                camera2.GetComponent<AudioListener>().enabled = true;

                camera1.GetComponent<Camera>().enabled = false;
                camera1.GetComponent<AudioListener>().enabled = false;
            }
        }
    }
}
