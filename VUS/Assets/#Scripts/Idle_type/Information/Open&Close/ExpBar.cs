using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Slider>().interactable = false;//Bar가 터치가 안되도록 설정
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
