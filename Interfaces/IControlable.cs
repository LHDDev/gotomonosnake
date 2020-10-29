using Godot;
using System;

public interface IControlable
{
    Vector2 GetMovementVector();
    Vector2 Repositionning(KinematicBody2D player);
}
