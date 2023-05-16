using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GUIController : MonoBehaviour
{

    [SerializeField] private TMP_Text Lifes;
    [SerializeField] public TMP_Text score;
    [SerializeField] public int  pnts = 0;
    [SerializeField] private PlayerMovement player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Lifes.text = "Lifes: " + player.player_lives;
        score.text = "Score: " + player.score;
        
    }


}
