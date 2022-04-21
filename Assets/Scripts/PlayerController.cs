using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float tileSize = 1;

    public string dialog;

    public LayerMask witchMask;
    public GameObject goal;

    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.Find("skeleton");
        goal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            Vector3 Mover = transform.position;
            Mover.x += tileSize * Input.GetAxisRaw("Horizontal");

            if (!Physics2D.OverlapCircle(Mover, 0.2f))
            {
                transform.position = Mover;
            }
        }

        if (Input.GetButtonDown("Vertical"))
        {
            Vector3 Mover = transform.position;
            Mover.y += tileSize * Input.GetAxisRaw("Vertical");

            if(!Physics2D.OverlapCircle(Mover, 0.2f))
            {
                transform.position = Mover;
            }
        }

        if(transform.position == goal.transform.position && goal.activeSelf)
        {
            int index = SceneManager.GetActiveScene().buildIndex + 1;

            if(index >= SceneManager.sceneCountInBuildSettings)
            {
                index = 0;
            }

            SceneManager.LoadScene(index);
        }

        if (Input.GetButtonDown("Jump") && (Physics2D.Raycast(transform.position, Vector2.down, tileSize, witchMask) || Physics2D.Raycast(transform.position, Vector2.up, tileSize, witchMask) || Physics2D.Raycast(transform.position, Vector2.right, tileSize, witchMask) || Physics2D.Raycast(transform.position, Vector2.left, tileSize, witchMask)))
        {
            Debug.Log(dialog);
            goal.SetActive(true);
        }
    }
}
