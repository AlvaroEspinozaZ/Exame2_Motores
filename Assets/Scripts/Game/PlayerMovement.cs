using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public KeyCode up;
    public KeyCode down;
    private Rigidbody2D myRB;
    [SerializeField]
    private float speed;
    private float limitSuperior;
    private float limitInferior;
    public int player_lives = 4;
    public int score = 0;
    int tmp = 0;
    int tmp2 = 3;
    [Header("Sonidos")]
    [SerializeField] private SoundsScritableO sonidoGolpe;
    [SerializeField] private SoundsScritableO sonidoPunto;
    [Header("Input Settings")]
    public PlayerInput playerInput;
    // Start is called before the first frame update
    void Start()
    {
        if (up == KeyCode.None) up = KeyCode.UpArrow;
        if (down == KeyCode.None) down = KeyCode.DownArrow;
        myRB = GetComponent<Rigidbody2D>();
        SetMinMax();
        tmp = score;
    }

    // Update is called once per frame
    void Update()
    {/*
        if (Input.GetKey(up) && transform.position.y < limitSuperior)
        {
            myRB.velocity = new Vector2(0f, speed);
        }
        else if (Input.GetKey(down) && transform.position.y > limitInferior)
        {
            myRB.velocity = new Vector2(0f, -speed);
        }
        else
        {
            myRB.velocity = Vector2.zero;
        }*/
    }

    void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        limitInferior = -bounds.y;
        limitSuperior = bounds.y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Candy")
        {                       
            CandyGenerator.instance.ManageCandy(other.gameObject.GetComponent<CandyController>(), this);
            CandyGenerator.instance.ManagePoints(other.gameObject.GetComponent<CandyController>(), this);
            sonidoPunto.CreateSound();          
        }
        if (other.tag == "Enemy")
        {
                sonidoGolpe.CreateSound();
            CandyGenerator.instance.ManageCandy(other.gameObject.GetComponent<CandyController>(), this);
        }
    }
    public void OnMove(InputAction.CallbackContext value)
    {
        Debug.Log("aver");
        Vector2 inputMovement = value.ReadValue<Vector2>();

        myRB.velocity = inputMovement * speed;

    }

    public void OnChange()
    {
        Debug.Log("Change");
        Debug.Log(playerInput.devices.Count);
    }
}
