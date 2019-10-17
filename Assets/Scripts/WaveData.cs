using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave Data", menuName = "Wave Data", order = 50)]
public class WaveData : ScriptableObject
{
    [SerializeField] public List<WaveGroupData> WaveGroups = new List<WaveGroupData>();
}
