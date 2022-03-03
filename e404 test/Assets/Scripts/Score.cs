using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int maxScore= 100;
    private int totalScore=0;
    private Text textScore;

    private void Start() {
        PlayerPrefs.SetInt("maxScore",maxScore);
        textScore = GameObject.Find("Score").GetComponent<Text>();
        textScore.text=0.ToString();
    }

    public int GetScore(){
        return totalScore;
    }
    public void AddScore(int num){
        totalScore+=num;
        textScore.text = totalScore.ToString();
        if(totalScore>=maxScore){
            //ganar 
            PlayerPrefs.SetFloat("spareTime", GetComponent<Countdown>().GetTime());
            PlayerPrefs.SetInt("score",totalScore);
            SceneManager.LoadScene("EndGame");
        }
    }

}
