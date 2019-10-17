﻿using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public BulletPattern Pattern = null;
    [SerializeField] public SpriteRenderer Sprite = null;
    private EnemyData _data = null;
    private Vector3 _targetPos = Vector3.zero;
    private Transform _targetTransform = null;
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
        else
        {
            _targetTransform = MechFactory.Instance.GetRandomActiveMech();
        }

        switch (_data.Colour)
        {
            case MechController.MechColour.Red:
            {
                Color col = Color.white;
                ColorUtility.TryParseHtmlString("#ed1b24ff", out col);
                Sprite.color = col;
                break;
            }
            case MechController.MechColour.Blue:
            {
                    Color col = Color.white;
                    ColorUtility.TryParseHtmlString("#2e3192ff", out col);
                    Sprite.color = col;
                    break;
            }
            case MechController.MechColour.Yellow:
            {
                    Color col = Color.white;
                    ColorUtility.TryParseHtmlString("#f2e405ff", out col);
                    Sprite.color = col;
                    break;
            }
            case MechController.MechColour.Purple:
            {
                    Color col = Color.white;
                    ColorUtility.TryParseHtmlString("#92278fff", out col);
                    Sprite.color = col;
                    break;
            }
            case MechController.MechColour.Orange:
            {
                    Color col = Color.white;
                    ColorUtility.TryParseHtmlString("#f37521ff", out col);
                    Sprite.color = col;
                    break;
            }
            case MechController.MechColour.Green:
            {
                    Color col = Color.white;
                    ColorUtility.TryParseHtmlString("#1ab359ff", out col);
                    Sprite.color = col;
                    break;
            }
            case MechController.MechColour.Rainbow:
            {
                    Color col = Color.white;
                    ColorUtility.TryParseHtmlString("#ed1b24ff", out col);
                    Sprite.color = col;
                    break;
            }
        }
    }

    private void OnEnable()
    {
        MechController.DisbandMech += DisbandMech;
        MechFactory.MergedMechs += MergeMechs;
    }

    private void OnDisable()
    {
        MechController.DisbandMech -= DisbandMech;
        MechFactory.MergedMechs -= MergeMechs;
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
                if (kMinDist > distance)
                {
                    _currentTragetIdx++;
                    if (_currentTragetIdx >= _data.MovePoints.Count)
                    {
                        _currentTragetIdx = 0;
                    }
                    _targetPos = _data.MovePoints[_currentTragetIdx];
                }
            }
            else
            {
                _targetPos = _targetTransform.position;
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

    public bool IsBoss
    {
        get { return _data.IsBoss; }
    }

    private void DisbandMech(MechController mech)
    {
        if (mech.transform == _targetTransform)
        {
            _targetTransform = MechFactory.Instance.GetRandomActiveMech();
        }
    }

    private void MergeMechs(List<Transform> oldMechs, Transform newMech)
    {
        foreach(var mech in oldMechs)
        {
            if (mech == _targetTransform)
            {
                _targetTransform = newMech;
                return;
            }
        }
    }
}
