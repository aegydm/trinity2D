using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float ghostDelay;
    private float ghostDelayTime;
    public GameObject ghost;
    public bool makeGhost;

    void Start()
    {
        this.ghostDelayTime = this.ghostDelay;
    }

    void FixedUpdate()
    {
        if (this.makeGhost)
        {
            if (this.ghostDelayTime > 0)
            {
                this.ghostDelayTime -= Time.deltaTime;
            }
            else
            {
                GameObject currentGhost = Instantiate(this.ghost, this.transform.position, this.transform.rotation);
                //Sprite currentSprite = this.GetComponent<SpriteRenderer>().sprite;
                currentGhost.transform.localScale = this.transform.localScale;
                //currentGhost.GetComponent<SpriteRenderer>().sprite = currentSprite;
                this.ghostDelayTime = this.ghostDelay;
                Destroy(currentGhost, 0.04f);
            }
        }
    }
}
