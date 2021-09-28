using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Paddle : MonoBehaviour
{
    // Configuration Parameters 
    [SerializeField] float ScreenWidthInUnits = 16f;
    [SerializeField] float PaddlePositionMin = 0.89f;
    [SerializeField] float PaddlePositionMax = 14.87f;

    // cached refrences 
    GameStatus TheGameSession;
    Ball TheBall;
    // Start is called before the first frame update
    void Start()
    {
        TheGameSession = FindObjectOfType<GameStatus>();
        TheBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        // MousePostInUnits is reading the position of the mouse at all times in the game
        // (how formula is derived is) At first, we normalise the screen coordinates with Input.mousePosition.x / Screen.width. 
        // The left edge is as x = 0, and the right one at x = 1.
        // In the World Space, the right edge is not at x = 1, though, but at x = 16.For this reason, we multiply by 16.

        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), PaddlePositionMin, PaddlePositionMax);
        // same as tellingpaddle to go to
        transform.position = paddlePos;

    }

    private float GetXPos()
    {
        if (TheGameSession.IsAutoPlayEnabled())
        {
          return TheBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * ScreenWidthInUnits;
        }
    }
}
