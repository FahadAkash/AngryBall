// Tromati Game Studio

using System;
using System.Collections.Generic;
using FlaxEngine;
using FlaxEngine.GUI;
namespace Game
{
    /// <summary>
    /// MenuManager Script.
    /// </summary>


    public class MenuManager : Script
    {
    public int Index ;
    public SceneManager sceneManager;
  public UIControl Button;
  public UIControl QuitButton;
        /// <inheritdoc/>
        public override void OnStart()
        {
           Button.Get<Button>().ButtonClicked += OnButtonClicked;
           QuitButton.Get<Button>().ButtonClicked += OnButtonClickedQuit;
        }
        private void OnButtonClickedQuit(Button button){
            
            

        }
        private void OnButtonClicked(Button button)
        {
            sceneManager.LoadScene();
             Debug.Log("Clicked: " + button.Text);
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
        }
    }
}
