using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FSMTransition
{
    public FSMDecision Decision;
    public string TrueState;
    public string FalseState;
}
