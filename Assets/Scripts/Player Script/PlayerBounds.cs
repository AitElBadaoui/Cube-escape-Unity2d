using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    public float min_X = -2.6f, max_X = 2.6f;
    public float min_Y = -5.6f, max_Y = 5.6f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        if (position.x > max_X)
            position.x = max_X;

        if (position.x < min_X)
            position.x = min_X;

        transform.position = position;

        //I should Add Vertical Bounds   
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.gameObject.tag == "TopSpike")
        {
            transform.position = new Vector2(1000f, 1000f);
            //TO-DO : DeathSound
            //GameManager : Restart()
        }
    }
}
