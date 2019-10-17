using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "Enemy Data", order = 52)]
public class EnemyData : ScriptableObject
{
    [SerializeField] public int MaxHealth = 10;
    [SerializeField] public float Speed = 1.5f;
    [SerializeField] public float BulletSpeed = 3f;
    [SerializeField] public float BulletLifeDuration = 4f;
    [SerializeField] public float FireCooldown = 0.1f;
    [SerializeField] public int SpiralDegreeIncrementPerShot = 3;
    [SerializeField] public BulletPattern.Pattern Pattern =  BulletPattern.Pattern.CrossPattern;
}
