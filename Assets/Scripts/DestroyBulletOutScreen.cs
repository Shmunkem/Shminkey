using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulletOutScreen : MonoBehaviour
{
    private float LeftBound = -90f;
    private float RightBound = 90;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < LeftBound || transform.position.x > RightBound)
        {
			Destroy(gameObject);
			
        }
    }
}
