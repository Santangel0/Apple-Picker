using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        Text gt = this.GetComponent<Text>();
        gt.text = "Score: " + Basket.justScore.ToString();
        
        RectTransform m_RectTransform;
        //Fetch the RectTransform from the GameObject
        m_RectTransform = GetComponent<RectTransform>();
        //Initiate the x and y positions
        if (Basket.justScore < 10)
        {
            float m_XAxis = 278f;
            float m_YAxis = -50f;
            
            m_RectTransform.anchoredPosition = new Vector2(m_XAxis, m_YAxis);
        } 
        else if (Basket.justScore < 100)
        {
            float m_XAxis = 255f;
            float m_YAxis = -50f;
            
            m_RectTransform.anchoredPosition = new Vector2(m_XAxis, m_YAxis);
        } 
        else if (Basket.justScore < 1000)
        {
            float m_XAxis = 230f;
            float m_YAxis = -50f;
            
            m_RectTransform.anchoredPosition = new Vector2(m_XAxis, m_YAxis);
        }
        else
        {
            float m_XAxis = 205f;
            float m_YAxis = -50f;
            
            m_RectTransform.anchoredPosition = new Vector2(m_XAxis, m_YAxis);
        }






    }

    // Update is called once per frame
    
}
