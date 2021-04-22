using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    // weaponRenderer - SpriteRenderer for gun which script is attatched to 
    // animator - Animation controller for specifc weapon attatched to script
    public SpriteRenderer weaponRenderer;
    public Animator animator;
}
