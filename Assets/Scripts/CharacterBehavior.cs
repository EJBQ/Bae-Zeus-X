//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;

public abstract class CharacterBehavior : MonoBehaviour
{
	public CharacterBehavior ()
	{

	}

	public int health;

	abstract public void loseHealth();

	abstract public void setHealth(int newHealth);
}

