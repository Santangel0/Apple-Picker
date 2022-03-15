using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in inspector")] 
    public GameObject basketPrefab;

    public int numsOfBaskets = 3;

    public float basketBottomY = -14.5f;
    public float basketSpacingY = 2f;
    public static List<GameObject> basketList;
    
    
    
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numsOfBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleDestroyed(string tag)
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        GameObject[] tAppleArrayB = GameObject.FindGameObjectsWithTag("AppleB");
        if (tag == "Apple")
        {
            foreach (GameObject tGO in tAppleArray)
            {
                Destroy(tGO);
            }
            foreach (GameObject tGO in tAppleArrayB)
            {
                Destroy(tGO);
            }
            
            Basket.justScore -= 1;
            Basket.scoreT.text = Basket.justScore.ToString();
            BasketDestroyed();
        }
            
            
    }

    public static void BasketDestroyed()
    {
        // Удалить одну корзину и получить индекс последней в Листе
        int basketIndex = basketList.Count - 1;
        
        // Получить ссылку на игровой объект Basket
        GameObject tBasketGO = basketList[basketIndex];
            
        
        // Удаление из Листа и из игры
        basketList.Remove(tBasketGO);
        Destroy(tBasketGO);
        //Basket.score = 0;
        if (basketList.Count >= 1)
        {
            GameObject tBasketGOtech = basketList[basketIndex - 1];
            tBasketGOtech.GetComponent<BoxCollider>().enabled = true;
        }

        if (basketList.Count == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

   
}
