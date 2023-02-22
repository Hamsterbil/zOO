using System;
using System.Collections;
using System.Collections.Generic;
using Lesson_6;
using Lesson_6.Animals;
using UnityEngine;

public class AnimalPen : MonoBehaviour
{
    public List<Animal> Animals = new List<Animal>();

    public void SpawnAnimals(Dictionary<GameObject, int> spawns)
    {
        foreach (KeyValuePair<GameObject, int> kv in spawns)
        {
            for (int i = 0; i < kv.Value; i++)
            {
                Vector3 pos = transform.position;
                pos.y += 2;
                GameObject go = Instantiate(kv.Key, pos, Quaternion.identity);
                go.transform.SetParent(transform);

                FriendlyAnimal animal = go.GetComponent<FriendlyAnimal>();
                Animals.Add(animal);
                animal.Pen = this;
            }
        }
    }

    public void SpawnAnimals(GameObject prefab, int[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] == 1)
                {
                    Vector3 pos = transform.position;
                    pos.y += 2;
                    GameObject go = Instantiate(prefab, pos, Quaternion.identity);
                    go.transform.SetParent(transform);

                    FriendlyAnimal animal = go.GetComponent<FriendlyAnimal>();
                    Animals.Add(animal);
                    animal.Pen = this;
                }
            }
        }
    }
    
    public void SpawnAnimals(GameObject prefab, int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 1)
                {
                    Vector3 pos = transform.position;
                    pos.y += 2;
                    GameObject go = Instantiate(prefab, pos, Quaternion.identity);
                    go.transform.SetParent(transform);

                    FriendlyAnimal animal = go.GetComponent<FriendlyAnimal>();
                    Animals.Add(animal);
                    animal.Pen = this;
                }
            }
        }
    }

    public void SpawnAnimals(List<GameObject> anims)
    {
        for (int i = 0; i < anims.Count; i++)
        {
            Vector3 pos = transform.position;
            pos.y += 2;
            GameObject go = Instantiate(anims[i], pos, Quaternion.identity);
            go.transform.SetParent(transform);

            FriendlyAnimal animal = go.GetComponent<FriendlyAnimal>();
            Animals.Add(animal);
            animal.Pen = this;
        }
    }

    public void SpawnAnimals(HashSet<GameObject> animals)
    {
        foreach (GameObject anim in animals)
        {
            Vector3 pos = transform.position;
            pos.y += 2;
            GameObject go = Instantiate(anim, pos, Quaternion.identity);
            go.transform.SetParent(transform);

            FriendlyAnimal animal = go.GetComponent<FriendlyAnimal>();
            Animals.Add(animal);
            animal.Pen = this;
        }
    }
}
