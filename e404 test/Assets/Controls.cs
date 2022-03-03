using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public GameObject menu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 0){
                Time.timeScale =1;
                menu.SetActive(false);
            }else{
                Time.timeScale = 0;
                menu.SetActive(true);
            }
        }
    }
}
