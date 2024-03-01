using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Samplers;
using UnityEngine.Perception.Randomization.Utilities;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.Perception.Randomization.Randomizers
{
    /// <summary>
    /// Creates a 2D layer of of evenly spaced GameObjects from a given list of prefabs
    /// </summary>
    [Serializable]
    [AddRandomizerMenu("Camera Placement Randomizer")]
    public class CameraPlacement : Randomizer
    {

        public float x_max;
        public float x_min;
        public float z_max;
        public float z_min;
        public Camera cam;
        GameObject m_Container;
        GameObjectOneWayCache m_GameObjectOneWayCache;

        /// <inheritdoc/>
        protected override void OnAwake()
        {

        }

        /// <summary>
        /// Generates a foreground layer of objects at the start of each scenario iteration
        /// </summary>
        protected override void OnIterationStart()
        {
            int street;
            int lane;
            float x_val = 0;
            float z_val = 0;
            float y_val = 0;
            int rotation; // left/right to ground
            int roll; // up/down from ground
            int y_cam_mode;
            street = Random.Range(0, 2);
            lane = Random.Range(0, 3);
            y_cam_mode = Random.Range(0, 4);
            // 0 perp to ground
            // 1 level 1, rotate
            // 2 level 2, more rotate
            // 3 parallel to ground from above
            if(y_cam_mode == 0){
                roll = 0;
                y_val = 0.3f;
            }
            else if(y_cam_mode == 1){
                roll = 24;
                y_val = 1.3f;
            }
            else if(y_cam_mode == 2){
                roll = 45;
                y_val = 3;
            }
            else { // y cam val = 3
                roll = 75;
                y_val = 7.5f;
            }

            if(street == 0){ // x lane
                if(lane == 0){ // inside
                    rotation = 180;
                    z_val = -2;
                }
                else if(lane == 1){ // middle
                    z_val = -5;
                    rotation = 90;
                    if(Random.Range(0, 2) > 0){ // flip camera 180
                        rotation = 270;
                    }
                }
                else{ // outside
                    rotation = 0;
                    z_val = -8;
                }
                x_val = Random.Range(x_min, x_max);
            }
            else{ // z lane
                if(lane == 0){ // inside
                    rotation = 90;
                    x_val = -5.5f;
                }
                else if(lane == 1){ // middle
                    rotation = 0;
                    x_val = -2.5f;
                    if(Random.Range(0, 2) > 0){ // flip camera 180
                        rotation = 180;
                    }
                }
                else{ // outside
                    rotation = 270;
                    x_val = 0.5f;
                }
                z_val = Random.Range(z_min, z_max);
            }
        cam.transform.position = new Vector3(x_val, y_val, z_val);
        cam.transform.eulerAngles = new Vector3(roll, rotation, 0);
        }

        /// <summary>
        /// Deletes generated foreground objects after each scenario iteration is complete
        /// </summary>
        protected override void OnIterationEnd()
        {
            // m_GameObjectOneWayCache.ResetAllObjects();
        }
    }
}
