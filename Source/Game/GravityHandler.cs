using System;
using System.Collections.Generic;
using FlaxEngine;

namespace Game
{
    /// <summary>
    /// GravityHandler Script.
    /// </summary>
    public class GravityHandler : Script
    {
        /// <inheritdoc/>
        /// 
        public RigidBody rg;
        private RayCastHit hit;
        private uint maxdistance;

        public Float3 OffsetDistance;
        public float Speed = 120 ;

        public override void OnStart()
        {
            // Here you can add code that needs to be called when script is created, just before the first game update
        }
        
        /// <inheritdoc/>
        public override void OnEnable()
        {
            rg.EnableGravity = true; 
            rg.EnableSimulation = true; 
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
          //  Debug.Log("Check Floor" + CheckFloor().Item2.Collider.Name + CheckFloor().Item1);
            rg.AddMovement( new Vector3(0f, CheckFloor().Item1 ? magnitude(Vector3.Zero, CheckFloor().Item2.Collider.Position) * Speed  : 0f, 0f) );
        }
        public float magnitude(Vector3 prevel, Vector3 currentvel)
        {
            return (Mathf.Sqrt(prevel.X * prevel.X + prevel.Y * prevel.Y + prevel.Z * prevel.Z)) / Time.DeltaTime;
        }
        public Tuple<bool, RayCastHit> CheckFloor()
        {
            if (Physics.RayCast(this.Actor.Position, this.Transform.Forward * OffsetDistance, out hit, maxdistance))
            {
                return Tuple.Create(true, hit);
            }
            return Tuple.Create(false, hit);
        }
    }
}
