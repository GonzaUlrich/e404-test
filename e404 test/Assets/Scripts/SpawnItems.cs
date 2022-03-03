using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnItems : MonoBehaviour
{
    public DificultyMode[] dificulties;
    public DificultyMode actualDificulty;
    public List<GameObject> posItems;
    private GameObject[] items;
    private int[] chance;
    private float timerSpawn;
    private float _timerSpawn;
    private float actualTime;
    private float randomVariableSuma;
    private float randomVariableResta;
    private float separationRatio;
    private Camera cam;
    float camHeight ;
    float camWidth ;
 
    void Start()
    {
        //Se toman los bounds de la camara
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;

        //Se chequea que dificultad se eligio
        for(int i=0;i<dificulties.Length;i++){
            if(PlayerPrefs.GetString("dificulty")==dificulties[i].name)
                actualDificulty=dificulties[i];
        }

        //se hace guardan los datos de esta dificultad
        items = new GameObject[actualDificulty.items.Length];
        chance = new int[actualDificulty.chance.Length];
        System.Array.Copy(actualDificulty.items,items,actualDificulty.items.Length);
        System.Array.Copy(actualDificulty.chance,chance,actualDificulty.chance.Length);
        timerSpawn = actualDificulty.timerSpawn;
        _timerSpawn = timerSpawn;
        randomVariableSuma = actualDificulty.randomVariableSuma;
        randomVariableResta = actualDificulty.randomVariableResta;
        separationRatio = actualDificulty.separationRatio;

        //Se elige un valor random para la 1era vuelta
        RandomTime();
    }

    void Update()
    {
        actualTime += Time.deltaTime;
        if(actualTime>timerSpawn){
            
            InstanciateObj(ItemChance());
            actualTime-=timerSpawn;
            timerSpawn=_timerSpawn;
            RandomTime();
        }

    }

    private void RandomTime(){
        //si es menos de 33 se suma si es mas de 66 se resta y lo que esta en el medio no se hace nada
        // a su vez se le da un valor random dentro de esos valores
        int randomNum = Random.Range(1,100);
        if(randomNum<33){
            timerSpawn+= Random.Range(0,randomVariableSuma);
        }else if(randomNum>66){
            timerSpawn-= Random.Range(0,randomVariableResta);
        }
    }

    private void InstanciateObj(int num){
        
        //min y max del alto de la pantalla para dar un valor random entre ellos
        float randHeight = Random.Range(cam.transform.position.x - (camWidth/2.0f),cam.transform.position.x + (camWidth/2.0f));
        //min y max del ancho de la pantalla para dar un valor random entre ellos
        float randWidth = Random.Range(cam.transform.position.y - (camHeight/2.0f),cam.transform.position.x + (camHeight/2.0f));
        
        for(int i=0;i<posItems.Count;i++){
            //remuevo los items borrados
            for(int j=0;j<posItems.Count;j++){
                if(posItems[j]==null)
                posItems.RemoveAt(j);
            }
            //en caso que un obj no este
            if(i>posItems.Count){
                i=0;
            }
            //chequeo que no sea null
            if(posItems[i]!=null){
                while(posItems[i].transform.position.x+separationRatio>randHeight && 
                    posItems[i].transform.position.x-separationRatio<randHeight &&
                    posItems[i].transform.position.y+separationRatio>randWidth  &&
                    posItems[i].transform.position.y-separationRatio<randWidth){
                        randHeight = Random.Range(cam.transform.position.x - (camWidth/2.0f),cam.transform.position.x + (camWidth/2.0f));
                        randWidth = Random.Range(cam.transform.position.y - (camHeight/2.0f),cam.transform.position.x + (camHeight/2.0f));
               }
            }
            
        }
        posItems.Add(Instantiate(items[num],new Vector3(randHeight,randWidth,0), items[num].transform.rotation));  
    }

    private int ItemChance(){
        //Se tira un dado de 100 caras y se chequea en que rango salio para instanciar el obj
        int randomItem = Random.Range(1,100);
        int num=0;
        int item=-1;
        
        while(randomItem>=num){
            num+=chance[item+1];
            item++;
        }
        return item;
    }

    public void SeveralSpawns(int cant, string name){

        //Buscamos el obj que se quiera spawnear y lo invocamos x cant de veces
        for(int i=0;i<items.Length;i++){
            if(items[i].name==name){
                for(int j=0;j< cant;j++ ){
                    InstanciateObj(i);
                }
            }
        }
        
    }

}
