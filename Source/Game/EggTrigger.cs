using System;
using System.Collections.Generic;
using FlaxEngine;
using Game;
namespace Game
{
    /// <summary>
    /// EggTrigger Script.
    /// </summary>
    public class EggTrigger : Script
    {
        public RigidBody rg;
        public Actor _Trigger;
        public override void OnStart()
        {
            _Trigger.As<Collider>().TriggerEnter += EggTrigger_TriggerEnter; ;
        }

        private void EggTrigger_TriggerEnter(PhysicsColliderActor obj)
        {
            
        }

       
    }
}
