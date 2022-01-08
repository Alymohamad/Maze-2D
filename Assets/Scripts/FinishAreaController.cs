using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishAreaController : MonoBehaviour
{

    public MazeRenderer mazeRendender;
    public Text winText;
    private GameObject player;




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.name = "Player";
        putFinishAreaRandomlyInMaze();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.name == "Player") {
            winText.gameObject.SetActive(true);
            Invoke("DisableWinningText", 3f);

            destroyWallsAndFinish();
            mazeRendender.DrawWalls();
            putPlayerAtStartPosition();
            putFinishAreaRandomlyInMaze();
        }

    }

    public void putPlayerAtStartPosition()
    {
        player.transform.localPosition = new Vector3(0, 1, 0);
        player.name = "Player";
    }

    private void putFinishAreaRandomlyInMaze()
    {
        var rng = new System.Random(/*seed*/);

        int x = rng.Next(3, mazeRendender.width);
        int y = rng.Next(3, mazeRendender.width);

        this.transform.localPosition = new Vector3(x, 1, y);
    }

    private void restartGame()
    {
        //Wenn button clicked einbauen
    }

    private void ShowWinningLabel()
    {

    }

    private void destroyWallsAndFinish()
    {
        foreach (Transform child in mazeRendender.transform)
        {
            if (child.tag == "Wall")
            {
                GameObject.Destroy(child.gameObject);
            }

        }
        //GameObject.Destroy(this.gameObject); Destroy Finish 
    }

    void DisableWinningText()
    {
        winText.gameObject.SetActive(false);
    }
}
