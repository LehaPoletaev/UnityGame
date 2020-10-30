using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;

    public string[] staticDirections = { "Static N", "Static NW", "Static W", "Static SW", "Static S", "Static SE", "Static E", "Static NE" };
    public string[] runDirections = { "Run N", "Run NW", "Run W", "Run SW", "Run S", "Run SE", "Run E", "Run NE" };
    public string[] slashDirections = { "SlashUp","SlashLeft", "SlashLeft","SlashDown", "SlashDown", "SlashRight", "SlashRight", "SlashUp" };
    int lastDirection;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void setDirection(Vector2 _direction,bool attack)
    {
        string[] directionArray = null;

        if (_direction.magnitude < 0.01)
        {
            directionArray = staticDirections;
            if (attack == true)
            {
                directionArray = slashDirections;
                lastDirection = directionToIndex(_direction);
            }
        }
        else if (attack == true)
        {
            directionArray = slashDirections;
            lastDirection = directionToIndex(_direction);
        }
        else
        {
            directionArray = runDirections;
            lastDirection = directionToIndex(_direction);
        }
        anim.Play(directionArray[lastDirection]);
    }


    private int directionToIndex(Vector2 _direction )
    {
        Vector2 norDir = _direction.normalized;
        float step = 360 / 8;
        float offset = step / 2;
        float angle = Vector2.SignedAngle(Vector2.up, norDir);

        angle += offset;
        if (angle < 0)
        {
            angle += 360;
        }

        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);
    }
}
