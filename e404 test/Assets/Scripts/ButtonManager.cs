using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject credits;
    public GameObject dificulty;

    public void Play(){
        if(dificulty.activeInHierarchy){
            dificulty.SetActive(false);
        }else{
            dificulty.SetActive(true);
        }
    }
    public void EasyButton(){
        PlayerPrefs.SetString("dificulty","Easy");
        SceneManager.LoadScene("Game");
    }
    public void MediumButton(){
        PlayerPrefs.SetString("dificulty","Medium");
        SceneManager.LoadScene("Game");
    }
    public void HardButton(){
        PlayerPrefs.SetString("dificulty","Hard");
        SceneManager.LoadScene("Game");
    }
    public void Config(){
        
    }
    public void Credits(){
        if(credits.activeInHierarchy){
            credits.SetActive(false);
        }else{
            credits.SetActive(true);
        }
    }
    public void Exit(){
        Application.Quit();
    }
    public void Menu(){
        SceneManager.LoadScene("Menu");
        Time.timeScale =1;
    }
    public void RePlay(){
        SceneManager.LoadScene("Game");
    }

}
