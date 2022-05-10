using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIImages : MonoBehaviour
{
    [SerializeField] RandomBehaviourEnum _behaviour;

    public RandomBehaviourEnum GetBehaviour()
    {
        return _behaviour;
    }
}
