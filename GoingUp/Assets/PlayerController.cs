using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    int inputKeyIndex;

    public float jumpForce = 2.5f;
    Vector2 step;

    bool animIsPlaying;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        step = FindObjectOfType<GameManager>().step;
    }

    // Update is called once per frame
    void Update()
    {
        if (animIsPlaying)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            inputKeyIndex = 1;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            inputKeyIndex = -1;
        }
    }

    private void FixedUpdate()
    {
        if (inputKeyIndex != 0 && !animIsPlaying)
        {
            var jumpAnim = rb.DOJump(rb.position + new Vector2(step.x * inputKeyIndex, step.y), jumpForce, 1, 0.15f).OnComplete(() => { animIsPlaying = false; });
            inputKeyIndex = 0;
            animIsPlaying = jumpAnim.IsPlaying();
        }
    }
}
