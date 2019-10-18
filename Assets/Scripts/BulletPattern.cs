using System;
using UnityEngine;

public class BulletPattern : MonoBehaviour
{
    public enum Pattern
    {
        CrossPattern,
        XPattern,
        Spiral,
        Circle
    }

    private Vector2 kLeft = new Vector3(-1, 0);
    private Vector2 kRight = new Vector3(1, 0);
    private Vector2 kUp = new Vector3(0, 1);
    private Vector2 kDown = new Vector3(0, -1);
    private Vector2 kUpLeft = new Vector3(-1, 1);
    private Vector2 kUpRight = new Vector3(1, 1);
    private Vector2 kDownLeft = new Vector3(-1, -1);
    private Vector2 kDownRight = new Vector3(1, -1);

    [SerializeField] public SpriteRenderer Sprite = null;
    [SerializeField] private Transform Parent = null;
    [SerializeField] private GameObject BulletTemplate = null;

    private EnemyData _data = null;
    private float _timeToChangePattern = 0f;
    private float _timeSinceLastFire = 0f;
    private int _spiralRotation = 0;

    public void ResetData(EnemyData data)
    {
        _data = data;
    }

    private void Update()
    {
        if (!Sprite.isVisible)
        {
            _timeSinceLastFire = 0.5f;
            return;
        }

        _timeSinceLastFire += Time.deltaTime;
        if (_data.ChangesPattern)
        {
            _timeToChangePattern += Time.deltaTime;
            if (_timeToChangePattern > _data.ChangesPeriod)
            {
                int currentPatternIdx = (int)_data.Pattern;
                currentPatternIdx++;
                if (currentPatternIdx >= Enum.GetNames(typeof(Pattern)).Length)
                {
                    currentPatternIdx = 0;
                }

                _data.Pattern = (Pattern)currentPatternIdx;
                _timeToChangePattern = 0f;
            }
        }

        if (_timeSinceLastFire > _data.FireCooldown)
        {
            switch (_data.Pattern)
            {
                case Pattern.CrossPattern:
                {
                    FireCrossPattern();
                    break;
                }
                case Pattern.XPattern:
                {
                    FireXPattern();
                    break;
                }
                case Pattern.Spiral:
                {
                    FireSpiralPattern();
                    break;
                }
                case Pattern.Circle:
                {
                    FireCirclePattern();
                    break;
                }
            }
            _timeSinceLastFire = 0.0f;
        }
    }

    private void FireCrossPattern()
    {
        SpawnBullet(Parent.position, Parent.rotation, kLeft);
        SpawnBullet(Parent.position, Parent.rotation, kRight);
        SpawnBullet(Parent.position, Parent.rotation, kUp);
        SpawnBullet(Parent.position, Parent.rotation, kDown);
    }

    private void FireXPattern()
    {
        SpawnBullet(Parent.position, Parent.rotation, kUpLeft);
        SpawnBullet(Parent.position, Parent.rotation, kUpRight);
        SpawnBullet(Parent.position, Parent.rotation, kDownLeft);
        SpawnBullet(Parent.position, Parent.rotation, kDownRight);
    }

    private Vector2 DegToVec2(int degree)
    {
        float rad = Mathf.Deg2Rad * (float)degree;
        return new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
    }

    private void FireSpiralPattern()
    {
        SpawnBullet(Parent.position, Parent.rotation, DegToVec2(_spiralRotation));
        _spiralRotation += _data.SpiralDegreeIncrementPerShot;
    }

    private void FireCirclePattern()
    {
        for (int degree = 0; degree < 360; degree += (int)(360f / _data.ShotsPerCircle))
        {
            SpawnBullet(Parent.position, Parent.rotation, DegToVec2(degree));
        }
    }

    private void SpawnBullet(Vector3 spawnPos, Quaternion spawnRot, Vector2 direction)
    {
        GameObject bullet = Instantiate(BulletTemplate, spawnPos, spawnRot);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.AddForce(direction * _data.BulletSpeed, ForceMode2D.Impulse);
        Destroy(bullet, _data.BulletLifeDuration);
    }
}
