using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // parameters
    [SerializeField] int Breakabblocks;

    //caches a refrence of sceneloader so we don't have to look for it everytime.
    SceneLoader sceneloader;
    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }
    public void CountBlocks()
    {
        Breakabblocks++;
    }

    public void BlockDestroyed()
    {
        Breakabblocks--;
        if(Breakabblocks <= 0)
        {
            sceneloader.LoadNextScene();
        }
    }
}
