using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimations : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        MouseMovement.movingForward += MoveForwardAnimation;
        MouseMovement.movingNone += NoAnimation;
    }

    private void MoveForwardAnimation()
    {
        anim.SetBool("Walking", true);
    }

    private void NoAnimation()
    {
        anim.SetBool("Walking", false);
    }
}
