using System;
using System.Collections.Generic;
using FlaxEngine;

namespace Game
{
   

    public class inputs : Script
    {
        /// <inheritdoc/>
        /// 
        public float Speed;
        public float Horizontal;
        public float Vertical;
        public Float3 verticles;
        float yaw;
        float pitch;
        public float angle;
        public TriggerHandler Trigger;
        bool gameover = false;
        Quaternion DefultOrientation;
        public override void OnStart()
        {
            DefultOrientation = Actor.Orientation;
            Trigger.OnPlayerHIt += Trigger_OnPlayerHIt;
            // Here you can add code that needs to be called when script is created, just before the first game update
        }

        private void Trigger_OnPlayerHIt(object sender, EventArgs e)
        {
            this.Actor.Orientation = DefultOrientation;
            gameover = true;
        }

        /// <inheritdoc/>
        public override void OnEnable()
        {
            // Here you can add code that needs to be called when script is enabled (eg. register for events)
        }

        /// <inheritdoc/>
        public override void OnDisable()
        {
            // Here you can add code that needs to be called when script is disabled (eg. unregister from events)
        }

        /// <inheritdoc/>
        public override void OnUpdate()
        {
            
            // Here you can add code that needs to be called every frame
            InputMouse();
           
          
        }
        public float HoriZontal()
        {
            return Input.GetAxis("Horizontal");
        }
        public float Varticle()
        {
            return Input.GetAxis("Vertical");
        }

        public void InputMouse()
        {
            if (gameover) {

                return;
            } 
            yaw = Mathf.Lerp(0, angle, Math.Abs(HoriZontal())) * Mathf.Sign(HoriZontal() * Time.DeltaTime * Speed);
           
            pitch = Mathf.LerpAngle(0, angle ,  Math.Abs(Varticle())) * Mathf.Sign(Varticle() * Time.DeltaTime * Speed );
            this.Actor.Orientation = Quaternion.Euler(Vector3.Right * yaw   + Vector3.Forward * pitch );
        }
        
    }
}
