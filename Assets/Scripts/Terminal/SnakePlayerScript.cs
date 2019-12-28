using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePlayerScript : MonoBehaviour
{


    Rigidbody2D rbody;

    float SPEED = 4.0f;

    public GameObject wallPrefab;

    Collider2D wall;

    Vector2 lastWallEnd;


    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.velocity = Vector2.right * SPEED;
        spawnWall();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)){
            rbody.velocity = Vector2.up * SPEED;
            spawnWall();
        }
        else if (Input.GetKey(KeyCode.DownArrow)){
            rbody.velocity = Vector2.down * SPEED;
            spawnWall();
        }
        else if (Input.GetKey(KeyCode.RightArrow)){
            rbody.velocity = Vector2.right * SPEED;
            spawnWall();
        }
        else if (Input.GetKey(KeyCode.LeftArrow)){
            rbody.velocity = Vector2.left * SPEED;
            spawnWall();
        }

        fitColliderBetween(wall, lastWallEnd, transform.position);
    }

    void spawnWall() {
        lastWallEnd = transform.position;

        wall = Instantiate(wallPrefab, transform.position, Quaternion.identity).GetComponent<Collider2D>();
    
    }

    void fitColliderBetween(Collider2D coll, Vector2 a, Vector2 b) {

        coll.transform.position = a + (b-a) * 0.5f;

        float distance = Vector2.Distance(a, b);

        if (a.x != b.x) {
            coll.transform.localScale = new Vector2(distance + .5f, .5f);
        }
        else {
            coll.transform.localScale = new Vector2(.5f, distance + .5f);
        }

    }

}
