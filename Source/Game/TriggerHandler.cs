using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using FlaxEngine;
using Game;
using System.Threading.Tasks;
namespace Game
{
    /// <summary>
    /// TriggerHandler Script.
    /// </summary>
    public class TriggerHandler : Script , ActionHandler
    {
        public SceneManager SceneManager;
        /// <inheritdoc/>
        /// 
        public AudioClip[] clips;
        public AudioClip[] GameStart;
        public AudioClip[] GameFinish;
        public AudioClip PigsHit;
        public RigidBody rg;
        public AudioManager AudioManager;
        public AudioSource PlayerHit;
        public AudioSource SecSource;
        public Actor PlayerTriggerActor;
        public AudioClip[] _playerdied;
        RandomStream random  = new RandomStream();
        public event EventHandler OnPlayerHIt;
        
        public override void OnStart()
        {
            PlayerTriggerActor.As<Collider>().TriggerEnter += TriggerHandler_TriggerEnter;
            // Here you can add code that needs to be called when script is created, just before the first game update
            AudioManager.SetAudioSource(PlayerHit);
             
            AudioManager.SetAudioClip(GameStart[random.RandRange(0, GameStart.Length)]);
            AudioManager.PlayAudio();
        }

        private void TriggerHandler_TriggerEnter(PhysicsColliderActor obj)
        {
            if (obj)
            {
                
                if (obj.FindScript<ObsticleTrigger>() != null)
                {

                   // Debug.Log("WallHits " + this.Actor.Parent.As<RigidBody>().AngularVelocity);
                    
                    if (Get_Magnitude(rg.AngularVelocity) >= 3.5f)
                    {

                        GetWallHits();

                    }
                }
                else if(obj.FindScript<EggTrigger>() != null)
                {
                    Debug.Log("Obsticles_Trigger" + obj);
                    rg.IsKinematic = true;
                    obj.FindScript<EggTrigger>().rg.IsKinematic = true;
                    OnPlayerHIt?.Invoke(this, EventArgs.Empty);
                    RandomStream randomStream = new RandomStream();
                    AudioManager.SetAudioClip(GameFinish[randomStream.RandRange(0, GameFinish.Length)]);
                    AudioManager.PlayAudio();
                    AudioManager.SetAudioSource(SecSource);
                    AudioManager.SetAudioClip(PigsHit);
                    AudioManager.PlayAudio();
                    Waitforscene();

                }
                else if(obj.FindScript<AngryBirdsHitHandler>() != null)
                {
                    Debug.Log("Obsticles_Trigger" + obj);
                    rg.IsKinematic = true;
                    OnPlayerHIt?.Invoke(this, EventArgs.Empty);
                    obj.FindScript<AngryBirdsHitHandler>().rg.IsKinematic = true;
                    RandomStream randomStream = new RandomStream();
                    AudioManager.SetAudioClip(_playerdied[randomStream.RandRange(0, _playerdied.Length)]);
                    AudioManager.PlayAudio();
                    
                    Gameover();
                }
            }
        }

        public float Get_Magnitude(Vector3 velocity) => Mathf.Sqrt(velocity.X * velocity.X + velocity.Y + velocity.Y + velocity.Z * velocity.Z);
     

        public void GetHit()
        {
         
         GetWallHits();
           

        }

         async Task Waitforscene()
        {
            await Task.Delay(3000);
            SceneManager.LoadScene();

        }
        async Task Gameover()
        {
            await Task.Delay(3000);
            SceneManager.ThisScene_Ref();
        }

        public void GetWallHits()
        {
            AudioManager.SetAudioSource(PlayerHit);
            AudioManager.SetAudioClip(clips[0]);
            AudioManager.PlayAudio();
        }

      
    }
}
