using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public ParticleSystem flameEffect;

    private Rigidbody2D rigidbodyBall;


    private void Start()
    {
        rigidbodyBall = GetComponent<Rigidbody2D>();    
    }

    private void Update()
    {
        FlameEffect();

    }

    public void FlameEffect()
    {
        if (rigidbodyBall.velocity.y < 2)
        {
            flameEffect.Play();
        }
        else
        {
            flameEffect.Stop();
        }
    }
}
