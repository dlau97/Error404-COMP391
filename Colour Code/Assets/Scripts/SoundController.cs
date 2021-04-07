using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip jumpSFX, deathSFX, shootSFX, colourChangeSFX, gunCollectSFX, launchPadSFX, enemyHitSFX, checkpointSFX, collisionSFX;
    // Start is called before the first frame update
    private AudioSource source;
    void Start()
    {
        source = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayJumpSFX(){
        source.PlayOneShot(jumpSFX,0.5f);
    }
    public void PlayDeathSFX(){
        source.PlayOneShot(deathSFX,0.5f);
    }
    public void PlayShootSFX(){
        source.PlayOneShot(shootSFX,0.5f);
    }
    public void PlayColourChangeSFX(){
        source.PlayOneShot(colourChangeSFX,1f);
    }
    public void PlayGunCollectSFX(){
        source.PlayOneShot(gunCollectSFX,0.5f);
    }
    public void PlayLaunchPadSFX(){
        source.PlayOneShot(launchPadSFX,0.7f);
    }
    public void PlayEnemyHitSFX(){
        source.PlayOneShot(enemyHitSFX,2f);
    }
    public void PlayCheckpointSFX(){
        source.PlayOneShot(checkpointSFX,0.5f);
    }
    public void PlayCollisionSFX(){
        source.PlayOneShot(collisionSFX,0.5f);
    }
}
