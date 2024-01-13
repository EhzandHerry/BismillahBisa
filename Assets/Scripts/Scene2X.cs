using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scene2X : MonoBehaviour
{
    public TextMeshProUGUI display_nama;
    // Start is called before the first frame update
    void Start()
    {
        TampilNama();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TampilNama()
    {
        display_nama.text = MainManager.Instance.player_name;
    }
}
