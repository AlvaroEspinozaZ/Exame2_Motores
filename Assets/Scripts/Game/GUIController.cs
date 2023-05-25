using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GUIController : MonoBehaviour
{

    [SerializeField] private TMP_Text Lifes;
    [SerializeField] public TMP_Text score;
    [SerializeField] public int  pnts = 0;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Score_SO rankings;
    [SerializeField] public UserRegister user;
    private float _distanceScore=0;
    private int _totalScore=0;
    void Start()
    {
        
    }
    void Update()
    {
        _distanceScore += Time.deltaTime;
        _totalScore = (int)_distanceScore + player.score;
        Lifes.text = "Lifes: " + player.player_lives;
        score.text = "Score: " + _totalScore;

        if (player.player_lives <= 0)
        {
            user.SetScore(_totalScore);
            rankings.RegistryNewScore(user);
            SceneManager.LoadScene("GameOver");
        }
    }


}
