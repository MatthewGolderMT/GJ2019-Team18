using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "Enemy Data", order = 52)]
public class EnemyData : ScriptableObject
{
    [SerializeField] public bool IsBoss = false;
    [SerializeField] public bool FollowsPlayer = true;
    [SerializeField] public List<Vector2> MovePoints = new List<Vector2>();
    [SerializeField] public bool ChangesPattern = false;
    [SerializeField] public float ChangesPeriod = 4f;
    [SerializeField] public int MaxHealth = 10;
    [SerializeField] public float Speed = 1.5f;
    [SerializeField] public float BulletSpeed = 3f;
    [SerializeField] public float BulletLifeDuration = 4f;
    [SerializeField] public float FireCooldown = 0.1f;
    [SerializeField] public int SpiralDegreeIncrementPerShot = 3;
    [SerializeField] public int ShotsPerCircle = 3;
    [SerializeField] public BulletPattern.Pattern Pattern =  BulletPattern.Pattern.CrossPattern;
    [SerializeField] public MechController.MechColour Colour = MechController.MechColour.Blue;
}
