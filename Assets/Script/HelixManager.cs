using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{ public GameObject [] helixRings;
public float yAxisSpawn = 0;
public float ringsDistance = 5;
public int numberOfRings = 7;
public GameObject BaseCylinder;

    void Start()
    {   // In this place we are spawning the helix rings in prefab randumly
         for (int i = 0; i < numberOfRings; i++){ 
            
            if(i ==0){ 
                spawnRing(0);
            }
            else
            {
                spawnRing(Random.Range(1, helixRings.Length -1));
    }
            }

            //What my first preFab to be the one at index 0 
            
  
  // this section we are trying to spawn the BaseCylinder ( the last ring)

     spawnRing(helixRings.Length -1);   
    }

    public void spawnRing(int ringIndex){ 

     GameObject go =   Instantiate(helixRings[ringIndex], transform.up * 
        yAxisSpawn, Quaternion.identity);
        go.transform.parent = transform;
        yAxisSpawn -= ringsDistance;
    }
    

}

