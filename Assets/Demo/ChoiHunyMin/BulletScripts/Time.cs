using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Test : MonoBehaviour
{
    void Update()
    {
         stop();
        
    }
    public static void stop()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Time.timeScale = 1;
        }
    }
}
