using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicRandom : MonoBehaviour
{
    
    public GameObject phonk1;
    public GameObject phonk2;
    public GameObject phonk3;
    public GameObject phonk4;
    public GameObject phonk5;
    public GameObject phonk6;
    public GameObject phonk7;
    
    // Start is called before the first frame update
    void Start()
    {
        int chance = Random.Range(0, 7);
        Debug.Log(chance);
        switch (chance)
        {
           case 0:
               phonk1.SetActive(true);
               break;
           case 1:
               phonk2.SetActive(true);
               break;
           case 2:
               phonk3.SetActive(true);
               break;
           case 3:
               phonk4.SetActive(true);
               break;
           case 4:
               phonk5.SetActive(true);
               break;
           case 5: 
               phonk6.SetActive(true);
               break; 
           case 6:
               phonk7.SetActive(true);
               break; 
        }
     }
}
