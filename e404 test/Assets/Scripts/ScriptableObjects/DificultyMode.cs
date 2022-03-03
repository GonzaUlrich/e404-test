using UnityEngine;

[CreateAssetMenu(fileName = "Dificulty", menuName ="DificultyMode")]
public class DificultyMode : ScriptableObject
{
    public GameObject[] items;
    [Header("Ingresar el % de cada uno para que el total de 100")]
    [Range(0,100)]
    public int[] chance;
    [Range(0,10)]
    public float timerSpawn;
    [Header("Le da una suma o resta radom")]
    [Range(0,2)]
    public float randomVariableSuma;
    [Range(0,2)]
    public float randomVariableResta;
    [Range(0,2)]
    public float separationRatio;
}
