using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResult : MonoBehaviour
{
    private Text result;
    private Text description;
    private int minutes, seconds;

    void Start()
    {
        result = GameObject.Find("Result").GetComponent<Text>();
        description = GameObject.Find("Description").GetComponent<Text>();

        if(PlayerPrefs.GetInt("score")>=PlayerPrefs.GetInt("maxScore")){
            result.text = "GANASTE!";
            float countdown = PlayerPrefs.GetFloat("spareTime");
            minutes = Mathf.FloorToInt(countdown / 60F);
            seconds = Mathf.FloorToInt(countdown - minutes * 60);
            description.text = "Te sobro " +  string.Format("{0:00}:{1:00}", minutes, seconds);
        }else{
            result.text = "Perdiste";
            description.text = "LLegaste a " + PlayerPrefs.GetInt("score").ToString() + " sigue intentando";
        }
    }
}
