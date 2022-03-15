using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AppleTree : MonoBehaviour
{
    [Header("Set in inspector")] 
    public GameObject applePrefab; // Яблоко
    public GameObject applePrefabB;
    public GameObject applePrefabG;

    public float speed = 10f; // Скорость яблони

    public float transformPosition = 20f; // Ограничитель перемещения яблони

    public float chanceOfTransform = 0.01f; // Вероятность перемещения

    public float secondsBetweenDrops = 2f; // Частота падения яблок
    
    
    void Start()
    {
        speed = 8f;
        Invoke("AppleDrops", 2f);
    }
    
    void Update()
    {

        // Простое перемещение
        Vector3 pos = transform.position; // Записываем в pos текущую позицию
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        
        
        // Изменение направления
        if (pos.x < -transformPosition)
        {
            speed = Mathf.Abs(speed);
        } else if (pos.x > transformPosition)
        {
            speed = -Mathf.Abs(speed);
        } 

    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(speed) < 15)
        {
            if (speed < 0)
                speed -= 0.001f;
            if (speed > 0)
                speed += 0.001f;
        }
        
        //Debug.Log(speed);

        if (secondsBetweenDrops > 0.28f)
        {
            secondsBetweenDrops -= 0.003f;
            //Debug.Log(secondsBetweenDrops);
        }
        
        
        // Рандомная смена направления
        if (chanceOfTransform >= Random.value)
        {
            speed *= -1;
        }
    }

    void AppleDrops()
    {
        GameObject apple;
        int chance = Random.Range(0, 101);
        if (chance > 10)
        {
            apple = Instantiate<GameObject>(applePrefab);
            //GameObject apple = Instantiate(applePrefab) as GameObject;
            
        }
        else if (chance > 3)
        {
            apple = Instantiate<GameObject>(applePrefabG);
        }
        else
        {
            apple = Instantiate<GameObject>(applePrefabB);
        }

        apple.transform.position = transform.position;
        Invoke("AppleDrops", secondsBetweenDrops);
    }
}
