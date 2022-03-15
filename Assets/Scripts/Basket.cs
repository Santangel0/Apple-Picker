using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{

    //public int score;
    [Header("Set dynamically")] 
    public static Text scoreT;

    public static int justScore;

    public BoxCollider BascetBoxCollider;
    // Start is called before the first frame update
    void Start()
    {
        BascetBoxCollider = this.gameObject.GetComponent<BoxCollider>();
        // Получить ссылку на игровой объект ScoreCounter
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Получить компонент Text этого игрового объекта
        scoreT = scoreGO.GetComponent<Text>();
        scoreT.text = "0"; // Начальный параметр
    }

    
    void Update()
    {
        if (!(ApplePicker.basketList.IndexOf(gameObject) == ApplePicker.basketList.Count - 1))
        {
            BascetBoxCollider.enabled = false;
        }
        // Получить текущие координаты мыши X & Y
        Vector3 mousePos2D = Input.mousePosition;

        // Здесь задаём значение Z противоположное камере, чтобы при трансформации в 3D оно стало 0
        mousePos2D.z = -Camera.main.transform.position.z;
        
        // 2D точку в 3D
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        if (Time.timeScale == 1f)
        {
            // Меняем координату Х
            Vector3 pos = transform.position;
            pos.x = mousePos3D.x;
            pos.x = Mathf.Clamp(pos.x, -26.5f, 26.5f);
            transform.position = pos;
        }
    }

    // Вызов при столкновении с корзиной
    // Аргумент - данные о столкновении
    
    void OnCollisionEnter(Collision coll)
    {
        
        GameObject collidedWith = coll.gameObject; // Достаём из данных GO
        string name = collidedWith.ToString();
        justScore = Convert.ToInt32(scoreT.text);
        if ((collidedWith.tag == "Apple" || collidedWith.tag == "AppleB")
            && ApplePicker.basketList.IndexOf(gameObject) == ApplePicker.basketList.Count - 1)
        {
            if (name.Contains("AppleG"))
            {
                Destroy(collidedWith);
                // Текст переводим в число
                //score = Convert.ToInt32(scoreT.text);
                justScore += 2;
                scoreT.text = justScore.ToString();
            }
            else if(name.Contains("AppleB"))
            {
                Destroy(collidedWith);
                justScore -= 1;
                scoreT.text = justScore.ToString();
                ApplePicker.BasketDestroyed();
                
            }
            else
            {
                Destroy(collidedWith);
                // Текст переводим в число
                //score = Convert.ToInt32(scoreT.text);
                justScore += 1;
                scoreT.text = justScore.ToString();
            }
            

            if (justScore > HighScore.score)
                HighScore.score = justScore;
        }
    }
    
    
}
