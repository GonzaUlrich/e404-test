using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    [Range(0,10)]
    public int lives = 1;
    [Range(0,10)]
    public int timeAlive = 5;
    [Range(-10,10)]
    public int points = 1;
    public bool loosePointsOnDesappear=false;
    [Range(0,10)]
    public int pointsOnDesappear = 1;
    public bool specialInvokeOnDestroy= false;
    [Range(0,10)]
    public int cantSpawns = 0;
    public string nameOfItem;
    public GameObject explosion;

    private GameObject score;
    private GameObject spawner;
    private float timer;

    private void Start() {
        score = GameObject.Find("EventSystem");
        spawner =  GameObject.Find("Spawner");
    }

    
    private void Update() {
        timer+=Time.deltaTime;
        if(timer>timeAlive){
            if(loosePointsOnDesappear){
                score.GetComponent<Score>().AddScore(pointsOnDesappear*-1);
            }
            Destroy(gameObject);
        }
    }

    private void OnMouseDown() {
        lives--;
        if(lives<=0){
            score.GetComponent<Score>().AddScore(points);
            Instantiate(explosion,transform.position,explosion.transform.rotation);
            //animaciones de explociones
            if(specialInvokeOnDestroy){
                spawner.GetComponent<SpawnItems>().SeveralSpawns(cantSpawns,nameOfItem);
            }
            Destroy(gameObject);
            
        }
    }
}
