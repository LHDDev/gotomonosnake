using Godot;
using System;

namespace lf.common.player{
    public class PlayerMovementController : IControlable
    {
        private const string INTPUT_MOVE_LEFT = "move_left";
        private const string INTPUT_MOVE_RIGHT = "move_right";
        private const string INTPUT_MOVE_UP = "move_up";
        private const string INTPUT_MOVE_DOWN = "move_down";

        private Vector2 _movementVector = Vector2.Right;
        public Vector2 GetMovementVector(){
            if(Input.IsActionPressed(INTPUT_MOVE_UP)){
                _movementVector = new Vector2(0,-1);
            }
            else if(Input.IsActionPressed(INTPUT_MOVE_DOWN)){
                _movementVector = new Vector2(0,1);
            }
            else if(Input.IsActionPressed(INTPUT_MOVE_RIGHT)){
                _movementVector = new Vector2(1,0);
            }
            else if(Input.IsActionPressed(INTPUT_MOVE_LEFT)){
                _movementVector = new Vector2(-1,0);
            }
            return _movementVector;
        }

        public Vector2 Repositionning(KinematicBody2D player){
            if(player.Position.x >= player.GetViewportRect().Size.x){
                return new Vector2(0,player.Position.y);
            }
            if(player.Position.x <= 0){
                return new Vector2(player.GetViewportRect().Size.x,player.Position.y);
            }
            if(player.Position.y >= player.GetViewportRect().Size.y){
                return new Vector2(player.Position.x,0);
            }
            if(player.Position.y <= 0){
                return new Vector2(player.Position.x,player.GetViewportRect().Size.y);
            }
            return player.Position;
        }
        public static Vector2 Repositionning(Area2D player){
            if(player.GlobalPosition.x >= player.GetViewportRect().Size.x){
                return new Vector2(0,player.GlobalPosition.y);
            }
            if(player.GlobalPosition.x <= 0){
                return new Vector2(player.GetViewportRect().Size.x,player.GlobalPosition.y);
            }
            if(player.GlobalPosition.y >= player.GetViewportRect().Size.y){
                return new Vector2(player.GlobalPosition.x,0);
            }
            if(player.GlobalPosition.y <= 0){
                return new Vector2(player.GlobalPosition.x,player.GetViewportRect().Size.y);
            }
            return player.GlobalPosition;
        }
    }
}

