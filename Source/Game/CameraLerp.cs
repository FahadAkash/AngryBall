﻿using System;
using System.Collections.Generic;
using FlaxEngine;

namespace Game
{
    /// <summary>
    /// CameraLerp Script.
    /// </summary>
    public class CameraLerp : Script
    {
        public Vector3 MovePlace;
        public float speed;

        /// <inheritdoc/>
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
            if(this.Actor.Position != MovePlace)
            {
                this.Actor.Position = Vector3.Lerp(this.Actor.Position, MovePlace, speed * Time.DeltaTime);
            }
        }
    }
}
