using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomBorderY = -20f;



    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomBorderY)
        {
            Destroy(this.gameObject);
            
            // Ссылка на компонент ApplePicker главной камеры
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            
            
            apScript.AppleDestroyed(gameObject.tag);
        }
        
        
        
    }
}
