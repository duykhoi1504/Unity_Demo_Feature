using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject cam;
    [SerializeField] private float parallaxEffect;
    private float xPos;
    private float length;
    
    void Start()
    {
        cam = GameObject.Find("Virtual Camera");
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        // Debug.Log("do dai cua anh: "+length);
        xPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //move to play
        //Tính toán khoảng cách mà camera đã di chuyển
        //(1 - parallaxEffect) Điều này giúp tính ra khoảng cách mà nền cần di chuyển ngược lại để tạo hiệu ứng parallax
        float distanceMove = cam.transform.position.x * (1 - parallaxEffect);

        //Tính toán khoảng cách mà lớp nền này cần di chuyển
        float distanceToMove = cam.transform.position.x * parallaxEffect;
       

        //Cập nhật vị trí của lớp nền dựa trên khoảng cách di chuyển
        transform.position = new Vector2(xPos + distanceToMove, transform.position.y);
        
        //reset
        if (distanceMove > xPos + length)
            xPos += length;
        else if (distanceMove < xPos - length)
            xPos -= length;
    }
}
