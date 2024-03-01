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
    [AddRandomizerMenu("Car Placement Randomizer")]
    public class CarPlacement : Randomizer
    {
        /// <summary>
        /// The Z offset component applied to the generated layer of GameObjects
        /// </summary>
        // [Tooltip("The Z offset applied to positions of all placed objects.")]
        // public float depth;

        /// <summary>
        /// The minimum distance between all placed objects
        /// </summary>
        // [Tooltip("The minimum distance between the centers of the placed objects.")]
        // public float separationDistance = 2f;

        /// <summary>
        /// The size of the 2D area designated for object placement
        /// </summary>
        // [Tooltip("The width and height of the area in which objects will be placed. These should be positive numbers and sufficiently large in relation with the Separation Distance specified.")]
        // public Vector2 placementArea;

        [Tooltip("min and max number of cars to place per image")]
        public Vector2Int numberOfCars = new(5, 20);

        /// <summary>
        /// The list of prefabs sample and randomly place
        /// </summary>
        [Tooltip("The list of Prefabs to be placed by this Randomizer.")]
        public CategoricalParameter<GameObject> prefabs;

        public float y_height = 0.15f;

        public float x_max;
        public float x_min;
        public float z_max;
        public float z_min;

        GameObject m_Container;
        GameObjectOneWayCache m_GameObjectOneWayCache;

        /// <inheritdoc/>
        protected override void OnAwake()
        {
            m_Container = new GameObject("Foreground Objects");
            m_Container.transform.parent = scenario.transform;
            m_GameObjectOneWayCache = new GameObjectOneWayCache(
                m_Container.transform, prefabs.categories.Select(element => element.Item1).ToArray(), this);
        }

        /// <summary>
        /// Generates a foreground layer of objects at the start of each scenario iteration
        /// </summary>
        protected override void OnIterationStart()
        {
            int num_cars = Random.Range(numberOfCars.x, numberOfCars.y);
            bool street_A;
            bool inside_lane;
            float x_val = 0;
            float z_val = 0;
            int rotation;
            int iter = 0;
            int count = 0;
            bool car_is_here = false;
            while (count < num_cars && iter < num_cars * 10){
                street_A = Random.Range(0, 2) > 0;
                inside_lane = Random.Range(0, 2) > 0;
                if(street_A){ // x lane
                    if(inside_lane){
                        z_val = -4.5f;
                        rotation = 270;
                    }
                    else{
                        z_val = -5.5f;
                        rotation = 90;
                    }
                    x_val = Random.Range(x_min, x_max);
                }
                else{ // z lane
                    if(inside_lane){
                        x_val = -2;
                        rotation = 0;
                    }
                    else{
                        x_val = -3;
                        rotation = 180;
                    }
                    z_val = Random.Range(z_min, z_max);
                }
                car_is_here = Physics.CheckSphere(new Vector3(x_val, 0.5f, z_val), 0.3f, 0, QueryTriggerInteraction.Collide);
                if (!car_is_here){
                var instance = m_GameObjectOneWayCache.GetOrInstantiate(prefabs.Sample());
                instance.transform.position = new Vector3(x_val, y_height, z_val);
                instance.transform.eulerAngles = new Vector3(
                    instance.transform.eulerAngles.x,
                    rotation,
                    instance.transform.eulerAngles.z);
                count++;
                }
                else{
                    Debug.Log(new Vector3(x_val, y_height, z_val));
                    Debug.Break();
                }
                iter++; // keeping track of how many iterations are run
            }

            // var seed = SamplerState.NextRandomState();
            // var placementSamples = PoissonDiskSampling.GenerateSamples(
            //     placementArea.x, placementArea.y, separationDistance, seed);
            // var offset = new Vector3(placementArea.x, placementArea.y, 0f) * -0.5f;
            // foreach (var sample in placementSamples)
            // {
            //     var instance = m_GameObjectOneWayCache.GetOrInstantiate(prefabs.Sample());
            //     instance.transform.position = new Vector3(sample.x, sample.y, depth) + offset;
            // }
            // placementSamples.Dispose();
        }

        /// <summary>
        /// Deletes generated foreground objects after each scenario iteration is complete
        /// </summary>
        protected override void OnIterationEnd()
        {
            m_GameObjectOneWayCache.ResetAllObjects();
        }
    }
}
