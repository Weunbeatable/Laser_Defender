using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    // Config parameters
   [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlocksDestroyed = 83;
    //state variables
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] bool isAutoPlayEnabled;



    private void Awake()
        //We are using objectsOFType and not objectOfType because we are looking for many
        //objects in our game. 
        {
            int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
            if (gameStatusCount > 1)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }
    
    
    private void Start()
    {
        ScoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;   
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlocksDestroyed;
        ScoreText.text = currentScore.ToString();

    }

    public void RestartGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
    /*
     * EDIT: I'm copying the answer given to me by Nina in the GameDev.tv forum community :
" Game objects in your Hierarchy get destroyed and created during runtime. For this reason, they cannot be referenced in a component of a prefab."

And, for my further reasoning, I’ve also considered that trying to bind (in my Game Status Script) 
a reference of a different Prefab outside the scope of the one I’m working in didn’t quite
make sense, because as as Rick mentioned in his subsequent lecturit would link to something that
is specific of the current scene, hence it cannot be made as a Prefab “attribute”.
Making the whole canvas a child of the Game Status Prefab solves the problem.
     */
}
