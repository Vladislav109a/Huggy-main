using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("����������")]
    private Rigidbody _rg;
    public int _speed = 10;
    public int _acelSpeed = 5;
    public float horizontal;
    //public float vertical;
    public Vector3 directionVector;
    public Transform playerTransfor;
    private Animator _anim;
    private int _Forcespeed = 40;

    public int Health;
    public Text txtHealth;


    [Header("�������� �� ������")]
    public bool _yesRoad;
    public float JumpForce;

    public GameObject StartButton;
    public GameObject PreStartPanel;
    public GameObject ShipiObject;

    [Header("������� � �.�")]
    public int coins;
    public Text txtCoins;
    private void Start()
    {
        _anim = GetComponent<Animator>();
        _rg = GetComponent<Rigidbody>();
        Health = 100;
        coins = 0;
    }
    private void Update()
    {
        //  if (YandexGame.EnvironmentData.isMobile == true)
        //  {
        //      horizontal = joystick.Horizontal;
        //      directionVector = new Vector3(horizontal * _accelerationSpeed, 0, 0);
        //      _rg.velocity = directionVector * _speed;
        //  }
        //  else
        //  {
        


        if (_anim.GetBool("isStartGame") == true)
        {
            horizontal = Input.GetAxis("Horizontal") * _speed;
            directionVector = new Vector3(horizontal * _acelSpeed, _rg.velocity.y, _acelSpeed);
            _rg.velocity = directionVector;
            //vertical = Input.GetAxis("Vertical") * _speed;
            if (horizontal == 1)
            {
                _anim.Play("RightRunMix");
            }
            if (horizontal == -1)
            {
                _anim.Play("LeftRunMix");
            }
            if (horizontal == 0)
            {
                _anim.Play("MixRun");
            }
                if (Input.GetKeyDown(KeyCode.Space) && _yesRoad)
                {
                    _anim.Play("MixJumping");
                    _yesRoad = false;
                    _rg.AddForce(new Vector3(0, JumpForce, 0));
                   _anim.SetBool("isJump",true);
                }
            else
            {
                _anim.SetBool("isJump",false);
            }
        }


        //   _rg.velocity = directionVector * _speed;
        //  }
        txtHealth.text = Health.ToString();
        txtCoins.text = coins.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _yesRoad = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shipi"))
        {
            //Destroy(other.gameObject);
            //PreStartPanel.SetActive(true);
            //StartButton.SetActive(true);
            Health--;
        }
        if (other.CompareTag("Coins"))
        {
            coins++;
            Destroy(other.gameObject);
            
        }
    }

    public void StartGame()
    {
        _anim.SetBool("isStartGame",true);
        StartButton.SetActive(false);
    }
    public void PreStart()
    {
        PreStartPanel.SetActive(false);
    }

}
