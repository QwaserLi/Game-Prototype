using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Living : Entity {
    
    [SerializeField]
    protected int health;
    public abstract void Damage(int damageTaken);

    public int getHealth() {
        return health;
    }

}
