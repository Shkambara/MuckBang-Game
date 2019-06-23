using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RamenGeneration : MonoBehaviour {

    public GameObject A;
    public GameObject B;
    public GameObject C;

    public GameObject[] hearts;

    public GameObject futurePosA;
    public GameObject futurePosB;
    public GameObject futurePosC;

    Transform oldPositionAtmp;
    Transform oldPositionBtmp;
    Transform oldPositionCtmp;
    //public GameObject oldPosA;
    //public GameObject oldPosB;
    //public GameObject oldPisC;

    public DeathMenu deathMenu;

    bool flagA;
    bool flagB;
    bool flagC;

    bool eatenA;
    bool eatenB;
    bool eatenC;

    private int point = 1;

    public static bool eatAnimation = false;

    bool gameProcessing;

    public float speedFlow;
    public double speed;
    public float duration;

    ScoreManager score;

    Movement m;

    GameObject removeMe;
    void Start()
    {
        Sounds.PlaySound("gong");
        score = FindObjectOfType<ScoreManager>();

        m = FindObjectOfType<Movement>();
        A.SetActive(false);
        B.SetActive(false);
        C.SetActive(false);
        flagA = false;
        flagB = false;
        flagC = false;

        gameProcessing = true;

        speed = 9.95;
        duration = 2;
    }

    // Update is called once per frame
    void Update () {
        speed -= 0.00001;
        duration -= 0.0001f;
        if (Movement.HP < 3 && Movement.HP >= 0)
            hearts[Movement.HP].SetActive(false);
        if (gameProcessing)
        {           

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Movement.eat.Play("Move");
                switch (Movement.pos)
                {
                    case 0:
                        if (eatenA || !flagA)
                        {
                            Sounds.PlaySound("hit");
                            Movement.HP--;
                        }
                        else
                        {
                            Sounds.PlaySound("eat");
                            score.AddScore(point);
                            eatenA = true;
                            StartCoroutine(animationDelay(A));
                        }
                        break;
                    case 1:
                        if (eatenB || !flagB)
                        {
                            Sounds.PlaySound("hit");
                            Movement.HP--;
                        }
                        else
                        {
                            Sounds.PlaySound("eat");
                            score.AddScore(point);
                            eatenB = true;
                            StartCoroutine(animationDelay(B));
                        }
                        break;
                    case 2:
                        if (eatenC || !flagC)
                        {
                            Sounds.PlaySound("hit");
                            Movement.HP--;
                        }
                        else
                        {
                            Sounds.PlaySound("eat");
                            score.AddScore(point);
                            eatenC = true;
                            StartCoroutine(animationDelay(C));
                        }
                        break;
                }
         

            }
            if (flagA == false)
            {
                if (UnityEngine.Random.Range(0f, 10f) > speed)
                {
                    eatenA = false;
                    flagA = true;
                    StartCoroutine(generateA());
                }
            }
            if (flagB == false)
            {

                if (UnityEngine.Random.Range(0f, 10f) > speed)
                {
                    eatenB = false;
                    flagB = true;
                    StartCoroutine(generateB());
                }
            }
            if (flagC == false)
            {

                if (UnityEngine.Random.Range(0f, 10f) > speed)
                {
                    eatenC = false;
                    flagC = true;
                    StartCoroutine(generateC());
                }
            }

            if (Movement.HP < 1)
            {
                Sounds.PlaySound("end");
                gameProcessing = false;
            }

        }
        else
        {
            score.scoreText.transform.gameObject.SetActive(false);
            score.deathScore.text = score.scoreText.text;

            deathMenu.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return)){      
                Application.LoadLevel("SampleScene");
                score.scoreText.text = 0 + "";
                score.scoreText.transform.gameObject.SetActive(true);
                Movement.HP = 3;
                A.SetActive(false);
                B.SetActive(false);
                C.SetActive(false);
                flagA = false;
                flagB = false;
                flagC = false;

                gameProcessing = true;

                speed = 9.95;
                duration = 2;
            }
        }


    }

    IEnumerator animationDelay(GameObject go)
    {
        yield return new WaitForSeconds(0.2f);
        go.SetActive(false);
    }

    IEnumerator generateA()
    {   
        
        A.SetActive(true);
        RamenAnimateA.animator.Play("RamenMoving");
        //oldPositionAtmp.position = A.transform.position; 
        A.transform.position = Vector3.MoveTowards(A.transform.position, futurePosA.transform.position, Time.deltaTime * speedFlow);
        yield return new WaitForSeconds(duration);
        if (!eatenA)
        {
            Movement.HP--;
            //A.transform.position = Vector3.MoveTowards(A.transform.position, oldPositionAtmp.position, Time.deltaTime * speedFlow);
            //RamenAnimateA.animator.Play("RamenBack");       
            //yield return new WaitForSeconds(1);
            A.SetActive(false);
            
        }
        flagA = false;
    }

    IEnumerator generateB()
    {
        B.SetActive(true);
        RamenAnimateB.animator.Play("RamenMoving");
        //oldPositionBtmp.position = B.transform.position;
        B.transform.position = Vector3.MoveTowards(B.transform.position, futurePosB.transform.position, Time.deltaTime * speedFlow);
        yield return new WaitForSeconds(duration); 
        if (!eatenB)
        {
            Movement.HP--;
           // B.transform.position = Vector3.MoveTowards(B.transform.position, oldPositionBtmp.position, Time.deltaTime * speedFlow);
            //RamenAnimateB.animator.Play("RamenBack");
            //yield return new WaitForSeconds(1);
            B.SetActive(false);
            
        }
        flagB = false;
    }

    IEnumerator generateC()
    {
        C.SetActive(true);
        RamenAnimateC.animator.Play("RamenMoving");
        //oldPositionCtmp.position = C.transform.position;
        C.transform.position = Vector3.MoveTowards(C.transform.position, futurePosC.transform.position, Time.deltaTime * speedFlow);
        yield return new WaitForSeconds(duration);
        if (!eatenC)
        {
            Movement.HP--;
            //C.transform.position = Vector3.MoveTowards(C.transform.position, oldPositionCtmp.position, Time.deltaTime * speedFlow);
           // RamenAnimateC.animator.Play("RamenBack");
            //yield return new WaitForSeconds(1);
            C.SetActive(false);
            
        }
        flagC = false;
    }

}
