using System.Collections;
using System.Collections.Generic;
using Lesson_6;
using Lesson_6.Animals;
using UnityEngine;

public class Zoo : MonoBehaviour
{
    public float AmountOfSquareSides;
    public float PenAmount; 
    public int zAxis = 0;
    public int xAxis = 0;

    public List<GameObject> AnimalPrefabs;
    public List<GameObject> PrefabList;

    public List<AnimalPen> Pens;
    public List<Animal> AllAnimals;

    public GameObject AnimalPen;
    public GameObject AnimalPen1;
    public GameObject AnimalPen2;
    public GameObject AnimalPen3;
    public GameObject AnimalPen4;

    protected void Start()
    {
    //Change number depending on how big the square should be
        AmountOfSquareSides = 3;

    //Take the amount of sides^2, to get the pen amount, since it's a square
        PenAmount = Mathf.Pow(AmountOfSquareSides, 2); 
        Pens = new List<AnimalPen>();
        AllAnimals = new List<Animal>();
        PrefabList.Add(AnimalPen);
        PrefabList.Add(AnimalPen1);
        PrefabList.Add(AnimalPen2);
        PrefabList.Add(AnimalPen3);
        PrefabList.Add(AnimalPen4);

        for (int i = 1; i < (PenAmount + 1); i++)
        {
            AnimalPen pen = Spawner(i);
            AllAnimals.AddRange(pen.Animals);
            Pens.Add(pen);
        }
    }

    private AnimalPen Spawner(int counter)
    {
        //Spawn animal pen
        int prefabIndex = UnityEngine.Random.Range(0,4);
        GameObject go = Instantiate(PrefabList[prefabIndex], transform);
        
        //Set the position of the pen to be 50 units away from the previous pen in both x and z
        if (counter % Mathf.Sqrt(PenAmount) != 0)
        {
            Vector3 spawnLocation = new Vector3((xAxis + 1) * 50, 0, zAxis * 50);
            go.transform.SetPositionAndRotation(spawnLocation, Quaternion.Euler(0, Random.Range(0, 4) * 90, 0));
            xAxis++;
        }
        else
        {
            Vector3 spawnLocation = new Vector3(0, 0, zAxis * 50);
            go.transform.SetPositionAndRotation(spawnLocation, Quaternion.Euler(0, Random.Range(0, 4) * 90, 0));
            xAxis = 0;
            zAxis++;
        }

        AnimalPen pen = go.GetComponent<AnimalPen>();

        //Spawn animals in the pen using different methods
        switch (counter)
        {
            //Spawn 5 pigs using a dictionary
            case 0:
                Dictionary<GameObject, int> spawns = new Dictionary<GameObject, int>();
                spawns.Add(AnimalPrefabs[0], 5);
                pen.SpawnAnimals(spawns);
                break;

            //Spawn 50 cats using a 2D array
            case 1:
                int[][] matrix = new int[10][];
                for (int i = 0; i < matrix.Length; i++)
                {
                    matrix[i] = new int[5];
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] = 1;
                    }
                }
                pen.SpawnAnimals(AnimalPrefabs[1], matrix);
                break;

            //Spawn 4 pigs using a 2D array
            case 2:
                int[,] matrixs = new int[2, 2];
                for (int i = 0; i < matrixs.GetLength(0); i++)
                {
                    for (int j = 0; j < matrixs.GetLength(1); j++)
                    {
                        matrixs[i, j] = 1;
                    }
                }
                pen.SpawnAnimals(AnimalPrefabs[0], matrixs);
                break;

            //Spawn 4 pigs using a list
            case 3:
                List<GameObject> anims = new List<GameObject>();
                anims.Add(AnimalPrefabs[0]);
                anims.Add(AnimalPrefabs[0]);
                anims.Add(AnimalPrefabs[0]);
                anims.Add(AnimalPrefabs[0]);
                pen.SpawnAnimals(anims);
                break;
            //Spawn 2 pigs using a hashset
            case 4:
                HashSet<GameObject> set = new HashSet<GameObject>();
                set.Add(AnimalPrefabs[0]);
                set.Add(AnimalPrefabs[0]);
                pen.SpawnAnimals(set);
                break;
            
            default:
                break;
        }
        return pen;
    }
}
