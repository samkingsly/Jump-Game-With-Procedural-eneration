using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelInputSO", menuName = "ScriptObject/LevelInputSO")]
public class ProceduralLevelDesignInputObject : ScriptableObject
{
    public int TotalSteps;
    [Tooltip("Valid : 0 to 3 => 0 - Static, 1 - moveHorizontal, 2 - moveVertical, 3 moveWithButton")]
    public string stepArrangementString;
    [Tooltip("should have the same size as the above string")]
    public string stepLifeString;
}
