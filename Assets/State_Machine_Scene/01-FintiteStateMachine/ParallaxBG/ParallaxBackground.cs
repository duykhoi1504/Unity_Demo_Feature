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
        xPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //move to play
        float distanceMove = cam.transform.position.x * (1 - parallaxEffect);
        float distanceToMove = cam.transform.position.x * parallaxEffect;
        transform.position = new Vector2(xPos + distanceToMove, transform.position.y);
        
        //reset
        if (distanceMove > xPos + length)
            xPos = xPos + length;
        else if (distanceMove < xPos - length)
            xPos = xPos - length;
    }
}
