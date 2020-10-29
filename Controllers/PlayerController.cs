using Godot;
using System;
using lf.common.player;

namespace lf.snake.controllers{
    public class PlayerController : KinematicBody2D
    {
        
        private IControlable _controls;
        [Export]
        private readonly int _speed = 10000;
        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            _controls = new PlayerMovementController();
        }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
        public override void _PhysicsProcess(float delta){
            Position = _controls.Repositionning(this);

            var velocity = _controls.GetMovementVector();
            MoveAndSlide(velocity * _speed * delta);
        }

        
    }
}

