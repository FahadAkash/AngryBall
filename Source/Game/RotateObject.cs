using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FlaxEngine;

namespace Game
{
    /// <summary>
    /// RotateObject Script.
    /// </summary>
    public class RotateObject : Script
    {
        /// <inheritdoc/>
        /// 
        public float speed;
        public override void OnStart()
        {

            // Here you can add code that needs to be called when script is created, just before the first game update
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
            Debug.Log(this.Actor.Orientation);
            this.Actor.EulerAngles += Vector3.Up * Time.DeltaTime * speed;
            // Here you can add code that needs to be called every frame
        }
    }
}
