using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    [SerializeField] public float Cooldown;
    [SerializeField] protected float damage;
}
