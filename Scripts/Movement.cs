using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    //RamenGeneration rg;
    public static Animator eat;
    public static ScoreManager score;
    //public Transform[] targets;
    public Transform[] targets;
    public float speed;
    public static int pos = 1;
    public static int HP = 3;
	// Use this for initialization
	void Start () {
        eat = GetComponent<Animator>();
        score = FindObjectOfType<ScoreManager>();
    }
	
	// Update is called once per frame
	void Update () {
        
        //RamenGeneration.eatAnimation = false;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            eat.Play("Move");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (pos > 0)
            {
                pos--;
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, targets[pos].position, step);

            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (pos < 2)
            {
                pos++;
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, targets[pos].position, step);
            }
        }
    }
}
