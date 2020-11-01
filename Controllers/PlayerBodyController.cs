using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using lf.common.player;
public class PlayerBodyController : Area2D
{
    
    public List<Vector2> _directions;
    public List<Vector2> _positions;
    public Vector2 _currentDirection = Vector2.Zero;
    
    private readonly int _speed = 2;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _directions = new List<Vector2>();
        _positions = new List<Vector2>();
    }

    public override void _PhysicsProcess(float delta)
    {
        if(_directions.Count > 0){
            if(this.Position == this._positions.ElementAt<Vector2>(0))
            {
                _currentDirection = _directions.ElementAt<Vector2>(0);
                RemoveFromTail();
            }
        }
        Position += _currentDirection * _speed ;
        GlobalPosition = PlayerMovementController.Repositionning(this);
    }

    private void RemoveFromTail(){
        _directions.RemoveAt(0);
        _positions.RemoveAt(0);
    }

    public void AddToTail(Vector2 headPosition, Vector2 direction){
        _positions.Add(headPosition);
        _directions.Add(direction);
    }
}
