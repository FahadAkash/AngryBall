using System;
using System.Collections.Generic;
using FlaxEngine;

namespace Game
{
    /// <summary>
    /// SceneManager Script.
    /// </summary>
    public class SceneManager : Script
    {


        public SceneReference SceneReference;
        public SceneReference ThisScene;
        public void LoadScene()
        {

            Level.ChangeSceneAsync(SceneReference.ID);
        }
        public void ThisScene_Ref()
        {
            Level.ChangeSceneAsync(ThisScene.ID);
        }
    }
}
