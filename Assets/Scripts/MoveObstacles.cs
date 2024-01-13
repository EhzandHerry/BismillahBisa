using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacles : MonoBehaviour
{
    PlayerController playerScript;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!playerScript.gameOver)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

    }
}
