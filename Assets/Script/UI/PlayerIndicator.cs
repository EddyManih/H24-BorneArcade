using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIndicator : MonoBehaviour
{
    private readonly Vector2 FlipRotation = new Vector3(0, 180);
    private bool isFlipped = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlipIndicator()
    {
        if (isFlipped)
        {
            transform.Rotate(FlipRotation);
        }
        else
        {
            transform.Rotate(-FlipRotation);
        }
    }
}
