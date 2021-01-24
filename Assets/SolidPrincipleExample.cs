using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SolidPrincipleExample : MonoBehaviour
{
    void Start()
    {
        Paladin paladin = new Paladin(100);
        DamageManager damageControl = new DamageManager();
        DeathManager deathManager = new DeathManager();

        IWeapon sword = new Sword();
        IWeapon axe = new Axe();

        paladin?.EquipWeapon(sword);
        //paladin?.EquipWeapon(axe);

        damageControl.CalculateDamage(paladin, 100);
        deathManager.ControlDeath(paladin);
    }

}

public interface ICanAttack
{
    void Attack();
}

public interface ICanCharge
{
    void Charge();
}

public interface ICanCastSpell
{
    void CastSpell();
}

public abstract class Character
{
    public int Armor { get; set; }
    public int Life { get; set; }

    public abstract void TakeDamage(int damage);
}

public interface IWeapon
{
    int Damage { get; set; }
}

public class Sword : IWeapon
{
    public int Damage { get; set; }
}

public class Axe : IWeapon
{
    public int Damage { get; set; }
}


public class Paladin : Character, ICanAttack, ICanCharge
{
    private IWeapon weapon;

    public Paladin(int life)
    {
        this.Life = life;
        Debug.Log("Şovalyenin " + life + " kadar canı var");
    }

    public void EquipWeapon(IWeapon weapon)
    {
        this.weapon = weapon;
        Debug.Log("Şovalye " + weapon + " ile kuşatıldı");
        
    }

    public override void TakeDamage(int damage)
    {
        Life -= Math.Max(0, damage - Armor);
        Debug.Log("Şovalyenin " + Life + " canı kaldı..");
    }

    public void Attack(Character target)
    {
        
        if (target != null && weapon != null)
        {
            target.TakeDamage(weapon.Damage);
        }
    }

    public void Charge(Character target)
    {
        if (target != null && weapon != null)
        {
            target.TakeDamage(weapon.Damage * 2);
        }
    }

    // Düzenleme
    public void Attack()
    {
        Debug.Log("Şovalye atak yapıyor..");
    }

    public void Charge()
    {
        Debug.Log("Şovalya yakın dövüş yapıyor..");
    }
}

public class Witch : Character, ICanAttack, ICanCastSpell
{
    public int MagicProtection { get; set; }

    public Witch(int life)
    {
        this.Life = life;
    }

    public override void TakeDamage(int damage)
    {
        Life -= Math.Max(0, damage - Armor - MagicProtection);
        Debug.Log("Cadının " + Life + " canı kaldı..");
    }

    public void Attack()
    {
        Debug.Log("Cadı atak yapıyor..");
    }

    public void CastSpell()
    {
        Debug.Log("Cadı büyü yapıyor..");
    }
}

public class DamageManager
{
    public void CalculateDamage(Character character, int damage)
    {
        Debug.Log("Karakter " + damage + " puanlık hasar aldı..");
        character?.TakeDamage(damage);
        
    }
}

public class DeathManager
{
    public void ControlDeath(Character character)
    {

        if (character?.Life == 0)
        {
            Debug.Log("Karakter öldü..");
        }
        else
            return;

    }
}
