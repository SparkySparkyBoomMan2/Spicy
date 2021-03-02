using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class enemy_hit_points
{
    public static int hitPointCalculator(int amount, float amountPercent)
    {
        float multiplier = 1f - amountPercent; //input where current amount% is
        return Convert.ToInt32(amount * multiplier);
    }
}
