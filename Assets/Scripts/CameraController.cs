using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;

    //deklarasi parameter mengikuti
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        //kamera mengikuti player
        offset = new Vector3(0, 5, -6);
    }

    void Update()
    {

    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Player.transform.position + offset;
    }
}
