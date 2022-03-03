using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Countdown : MonoBehaviour
{
    private int timer;
    private Text textTimer;
    [Header("Es en segundos el countdown")]
    public float countdown;
    private int minutes, seconds;

    private void Start() {
        textTimer = GameObject.Find("Timer").GetComponent<Text>();

    }
    void Update()
    {
        if(countdown>=0){
            countdown -= Time.deltaTime;
            minutes = Mathf.FloorToInt(countdown / 60F);
            seconds = Mathf.FloorToInt(countdown - minutes * 60);
            textTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else{
            //perdiste 
            PlayerPrefs.SetInt("score",GetComponent<Score>().GetScore());
            PlayerPrefs.SetFloat("spareTime",0);
            SceneManager.LoadScene("EndGame");      

        }
    }
    public float GetTime(){
        return countdown;
    }
}
