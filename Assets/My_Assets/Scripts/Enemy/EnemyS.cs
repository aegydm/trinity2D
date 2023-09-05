using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[SerializeField]
public class EnemyS : MonoBehaviour
{
    [SerializeField] private float enemySSpeed = 7.0f;
    [SerializeField] private int enemySHP = 1;

    private enum ESState
    {
        Rush,
        Stop,
        Back
    }


}
