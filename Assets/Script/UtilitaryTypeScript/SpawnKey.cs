using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKey : MonoBehaviour
{
    public GameObject keyContenaire;
    int randomPos;
    int[] spawnSelected;
    float distance;

    private void Start()
    {

        int childs = transform.childCount; // count child in parent of spawn
        int nbKeys = keyContenaire.transform.childCount; //count child in parent of key
        spawnSelected = new int[nbKeys];

        Debug.Log(childs);

        GameObject[] spawn = new GameObject[transform.childCount];
        GameObject[] allKeys = new GameObject[keyContenaire.transform.childCount];
        for (int i = 0; i < spawn.Length; i++)
        {
            spawn[i] = transform.GetChild(i).gameObject; 
            
        }
        for(int nb = 0; nb < allKeys.Length; nb++)
        {
            //get key object
            allKeys[nb] = keyContenaire.transform.GetChild(nb).gameObject;

            //select spawn with rand and position key
            randomPos = Random.Range(0, childs);
            Debug.Log(randomPos);
            spawnSelected[nb] = randomPos;
                
            
            if(nb>0) // check if spawn not to close from an other
            {
                for(int i=0; i<nb; i++)
                {
                    distance= Vector3.Distance(spawn[randomPos].transform.position, spawn[i].transform.position);
                    Debug.Log("distance " + distance);
                    if(distance <= 5)
                    {
                        randomPos = Random.Range(0, childs);
                        i = 0;
                    }
                }
                
            }
            allKeys[nb].transform.position = spawn[randomPos].transform.position;


            //remove spawn selected from tab
            childs -= 1;
            spawn[randomPos] = spawn[childs - 1];
        }

       
    }
}