using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Block : MonoBehaviour
{
    // Config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    //cached reference
    Level level;

    // state variables 
    [SerializeField] int timesHit; // TODO only serialized for debug purposes. 
    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block Sprite is missing from array" + gameObject.name);
            //Debug line is in case maybe you forget to load sprites in or array is out of bounds, instead of a crash you'll get a debug message, and the name of said game object

           
        }
    }

    private void DestroyBlock()
    {
        
            PlayBlockDestroySFX();
            gameObject.SetActive(false);
            TriggerSparklesVFX();
            Destroy(gameObject);
            level.BlockDestroyed();
        

    }

    private void PlayBlockDestroySFX()
    {
       
            FindObjectOfType<GameStatus>().AddToScore();
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }

}

