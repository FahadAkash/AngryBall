using System;
using System.Collections.Generic;
using FlaxEngine;

namespace Game
{
    /// <summary>
    /// AngryBirdsHitHandler Script.
    /// </summary>
    public class AngryBirdsHitHandler : Script
    {
        /// <inheritdoc/>
        /// 
        public Actor _Trigger;
        public RigidBody rg;
        public TriggerHandler Trigger;
        public AudioClip[] clips;
        public AudioClip[] hitsaudio;
        public AudioManager _GameStartManager;
        public AudioSource _Souce;
        RayCastHit hit;
        public Float3 OffsetDistance;
        float maxdistance;

        public float Speed;
        public override void OnStart()
        {
            _GameStartManager.SetAudioSource(_Souce);
            RandomStream stream = new RandomStream();   
            _GameStartManager.SetAudioClip(clips[stream.RandRange(1,clips.Length)]);
            //_GameStartManager.PlayAudio();
            Trigger.OnPlayerHIt += Trigger_OnPlayerHIt;
            _Trigger.As<Collider>().TriggerEnter += AngryBirdsHitHandler_CollisionEnter;

            // Here you can add code that needs to be called when script is created, just before the first game update
        }

        private void Trigger_OnPlayerHIt(object sender, EventArgs e)
        {
            rg.AngularVelocity = Vector3.Zero;
            rg.IsKinematic = true;
           
        }

        private void AngryBirdsHitHandler_CollisionEnter(PhysicsColliderActor obj)
        {
            if (obj.FindScript<ObsticleTrigger>() != null)
            {

                // Debug.Log("WallHits " + this.Actor.Parent.As<RigidBody>().AngularVelocity);

                if (Get_Magnitude(rg.AngularVelocity) >= 5.5f)
                {

                    GetWallHits();

                }
            }
        }
        public float Get_Magnitude(Vector3 velocity) => Mathf.Sqrt(velocity.X * velocity.X + velocity.Y + velocity.Y + velocity.Z * velocity.Z);
        public void GetWallHits()
        {
            RandomStream randomStream = new RandomStream(); 

            _GameStartManager.SetAudioSource(_Souce);
            _GameStartManager.SetAudioClip(hitsaudio[randomStream.RandRange(0, hitsaudio.Length)]);
            _GameStartManager.PlayAudio();
        }
        public override void OnUpdate()
        {
           // Debug.Log("Check Floor" + CheckFloor().Item2.Collider.Name + CheckFloor().Item1);
            rg.AddForce( new Vector3(0f, CheckFloor().Item1 ? magnitude(Vector3.Zero , CheckFloor().Item2.Collider.Position) * Speed * Time.DeltaTime : 0f, 0f) , ForceMode.Impulse);
        }
        public float magnitude(Vector3 prevel , Vector3 currentvel )
        {
           return (Mathf.Sqrt(prevel.X * prevel.X + prevel.Y * prevel.Y + prevel.Z * prevel.Z)) / Time.DeltaTime;
        }
        public Tuple<bool , RayCastHit> CheckFloor()
        {
            if(Physics.RayCast(this.Actor.Position , this.Transform.Forward * OffsetDistance ,out hit  , maxdistance))
            {
                return Tuple.Create(true , hit);
            }
            return Tuple.Create(false , hit);
        }
    }
}
