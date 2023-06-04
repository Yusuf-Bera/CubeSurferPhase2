using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private HeroStackController heroStackController;
    private Vector3 direction = Vector3.back;
    private bool isStack = false;
    private RaycastHit hit;
    private HeroMovementController heroMovement;
    private GameManager _gameManager;
    public static int score;

<<<<<<< HEAD
    private void Awake()
=======
    private void Start()
>>>>>>> 77af4fa27b3f4787a2f54d9355e64b2ded9c9c53
    {
        heroStackController = GameObject.FindObjectOfType<HeroStackController>();
        heroMovement = GameObject.FindObjectOfType<HeroMovementController>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

<<<<<<< HEAD
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cube")
=======
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag=="cube")
>>>>>>> 77af4fa27b3f4787a2f54d9355e64b2ded9c9c53
        {
            if (!isStack)
            {
                isStack = !isStack;
                heroStackController.IncreaseNewBlock(gameObject);
                SetDirection();
            }
<<<<<<< HEAD
        }

        if (other.gameObject.tag == "Obstacle")
        {
            heroStackController.DecreaseBlock(gameObject);
        }

        if (other.gameObject.tag == "finish")
=======
        } 

        if(other.gameObject.tag=="Obstacle")
        {
          heroStackController.DecreaseBlock(gameObject);
        }

        if(other.gameObject.tag == "left")
        {
            heroMovement.turnLeft();
        }

        if(other.gameObject.tag == "right")
        {
            heroMovement.turnRight();
        }

        if(other.gameObject.tag == "road")
        {
            heroMovement.roadFunc(other.gameObject);
        }

        if(other.gameObject.tag == "finish")
>>>>>>> 77af4fa27b3f4787a2f54d9355e64b2ded9c9c53
        {
            heroMovement.resetSpeed();
            _gameManager.nextLevel();
        }
<<<<<<< HEAD

        /*if (other.gameObject.tag == "right")
        {
            //FindObjectOfType<CameraFollowController>().finishCameraMovement();
            heroMovement.turnRight();
        }*/
=======
>>>>>>> 77af4fa27b3f4787a2f54d9355e64b2ded9c9c53
    }

    private void SetDirection()
    {
        direction = Vector3.forward;
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 77af4fa27b3f4787a2f54d9355e64b2ded9c9c53
