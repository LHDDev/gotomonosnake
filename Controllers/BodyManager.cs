using Godot;
using System;
using lf.common.player;
using static Extension;
namespace lf.snake.controllers{
    public class BodyManager : Node2D
    {
        [Export]
        private readonly String _bodyScenePath ="";
        private readonly int _gap = -34;
        private IControlable _controls;
        [Export]
        private readonly int _speed = 2;
        private Vector2 _nextTailDirection = Vector2.Right;
        private Vector2 _prevTailDirection = Vector2.Right;
        private bool _isDirChange =  false;
        private Vector2 _velocity = Vector2.Right;
        private PlayerController head;
        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            _controls = new PlayerMovementController();
            head = GetChild<PlayerController>(0);
            AddTail();
            AddTail();
            AddTail();
            AddTail();
            AddTail();
        }
        
        public override void _PhysicsProcess(float delta){
            _isDirChange = false;
            
            _velocity = _controls.GetMovementVector();

            if(_prevTailDirection != _velocity){
                _prevTailDirection = _velocity;
                _isDirChange = true;
            }
            if(_isDirChange){
                foreach(var i in GetChildren()){
                    if(i is PlayerBodyController bodyController){
                        bodyController.AddToTail(head.Position, _velocity);
                    }
                }
            }

            head.Position += _velocity * _speed ;
            head.GlobalPosition = PlayerMovementController.Repositionning(head);

        }
        private void AddTail(){
            var tailInstance = SmartLoader<PlayerBodyController>(_bodyScenePath);
            var lastChild = GetChild<Node2D>(GetChildCount() -1);
            if(lastChild is PlayerBodyController prevTail){
                foreach(Vector2 delayedPos in prevTail._positions){
                    tailInstance._positions.Add(delayedPos);
                }
                foreach(Vector2 delayedDir in prevTail._directions){
                    tailInstance._directions.Add(delayedDir);
                }
                tailInstance.Position = prevTail.Position + prevTail._currentDirection * _gap;
                tailInstance._currentDirection = prevTail._currentDirection;
            }
            else{
                tailInstance.Position += lastChild.Position + _velocity *_gap;
                tailInstance._currentDirection = _velocity;
            } 
            AddChild(tailInstance);
        }
    }
}
