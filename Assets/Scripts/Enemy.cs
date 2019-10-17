using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public BulletPattern Pattern = null;
    private EnemyData _data = null;
    private Vector3 _targetPos = Vector3.zero;
    private int _currentHealth = 20;
    private int _currentTragetIdx = 0;
    private float kMinDist = 0.1f;

    public void ResetData(EnemyData data)
    {
        _data = data;
        Pattern.ResetData(_data);
        _currentHealth = _data.MaxHealth;

        if (!_data.FollowsPlayer)
        {
            _targetPos = _data.MovePoints[_currentTragetIdx];
        }
    }

    public void Update()
    {
        if (IsDead)
        {
            this.enabled = false;
        }
        else
        {
            if (!_data.FollowsPlayer)
            {
                float distance = Vector2.Distance(transform.position, _targetPos);
                if (0.1f > distance)
                {
                    _currentTragetIdx++;
                    if (_currentTragetIdx >= _data.MovePoints.Count)
                    {
                        _currentTragetIdx = 0;
                    }
                    _targetPos = _data.MovePoints[_currentTragetIdx];
                }
            }

            float dist = Vector2.Distance(transform.position, _targetPos);
            if (dist >= kMinDist)
            {
                transform.position = Vector2.MoveTowards(transform.position, _targetPos, _data.Speed * Time.deltaTime);
            }
        }
    }

    public void Kill()
    {
        _currentHealth = 0;
    }

    public bool IsDead
    {
        get { return (0 >= _currentHealth); }
    }
}
