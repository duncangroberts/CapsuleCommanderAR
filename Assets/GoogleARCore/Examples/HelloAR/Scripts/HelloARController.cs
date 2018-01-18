//-----------------------------------------------------------------------
// <copyright file="HelloARController.cs" company="Google">
//
// Copyright 2017 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------
/*
namespace GoogleARCore.HelloAR
{
    using System.Collections.Generic;
    using GoogleARCore;
    using UnityEngine;
    using UnityEngine.Rendering;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;
    using System.Collections;

    /// <summary>
    /// Controls the HelloAR example.
    /// </summary>
    public class CCARController : MonoBehaviour
    {
        /// <summary>
        /// The first-person camera being used to render the passthrough camera image (i.e. AR background).
        /// </summary>
        public Camera FirstPersonCamera;

        /// <summary>
        /// A prefab for tracking and visualizing detected planes.
        /// </summary>
        public GameObject TrackedPlanePrefab;

        /// <summary>
        /// A model to place when a raycast from a user touch hits a plane.
        /// </summary>
        public GameObject AndyAndroidPrefab;

        /// <summary>
        /// A gameobject parenting UI for displaying the "searching for planes" snackbar.
        /// </summary>
        public GameObject SearchingForPlaneUI;

        /// <summary>
        /// A list to hold new planes ARCore began tracking in the current frame. This object is used across
        /// the application to avoid per-frame allocations.
        /// </summary>
        private List<TrackedPlane> m_NewPlanes = new List<TrackedPlane>();

        /// <summary>
        /// A list to hold all planes ARCore is tracking in the current frame. This object is used across
        /// the application to avoid per-frame allocations.
        /// </summary>
        private List<TrackedPlane> m_AllPlanes = new List<TrackedPlane>();

        /// <summary>
        /// True if the app is in the process of quitting due to an ARCore connection error, otherwise false.
        /// </summary>
        private bool m_IsQuitting = false;

        public Camera m_firstPersonCamera;
        Rigidbody m_rb;
        public bool m_created;
        public bool firingengines;
        public bool m_placinglander;
        public bool m_placingpad;
        public bool m_landerplaced;
        public bool m_padplaced;
        public bool m_placingfinished;
        public bool m_setlander;
        public bool m_setpad;
        public bool m_placingvolcano1;
        public bool m_volcano1placed;
        public bool m_setvolcano1;
        public bool m_placingvolcano2;
        public bool m_volcano2placed;
        public bool m_setvolcano2;
        public bool m_placingring1;
        public bool m_ring1placed;
        public bool m_setring1;
        public bool m_placingring2;
        public bool m_ring2placed;
        public bool m_setring2;
        public bool m_placingstalag;
        public bool m_stalagplaced;
        public bool m_setstalag;
        public GameObject m_placelanderbutton;
        public GameObject m_placepadbutton;
        public GameObject m_startbutton;
        public GameObject m_setlanderbutton;
        public GameObject m_setpadbutton;
        public GameObject m_placevolcano1button;
        public GameObject m_setvolcano1button;
        public GameObject m_takeoffbutton;
        public GameObject m_trackedPlanePrefab;
        public GameObject m_marslanderPrefab;
        public GameObject m_stalagprefab;
        public GameObject cube;
        GameObject jettrails;
        GameObject placerlanderobject;
        GameObject landerobject;
        GameObject placerstalag;
        GameObject stalagobject;
        public GameObject m_landingpadPrefab;
        GameObject placerpad;
        GameObject padobject;
        public GameObject m_volcano1;
        GameObject placervolcano1;
        GameObject volcano1object;
        public GameObject m_volcano2;
        GameObject placervolcano2;
        GameObject volcano2object;
        bool m_createtracker;
        GameObject cubeinstance;
        public float speed;
        Ray trackerray;
        Vector3 point;
        TrackableHit hit;
        TrackableHit padhit;
        TrackableHit phonehit;
        public Slider slider;
        Vector3 down;
        GameObject kickuplocation;
        public GameObject kickupeffect;
        public GameObject stats;
        public Text fueltext;
        public Text integritytext;
        public Text landerspeedtext;
        public float fuel;
        public float integrity;
        public float landerspeed;
        bool m_caniload;
        public Slider landerscaler;
        public Slider padscaler;
        public Slider volcano1scaler;
        public Slider volcano2scaler;
        public Slider stalagscaler;
        public GameObject distanceslider;
        public GameObject landerscalerobj;
        public GameObject padscalerobj;
        public GameObject volcano1scalerobj;
        public GameObject volcano2scalerobj;
        public GameObject stalagscalerobj;
        public GameObject m_placevolcano2button;
        public GameObject m_setvolcano2button;
        public GameObject m_placestalagbuton;
        public GameObject m_setstalagbuton;
        public GameObject m_gogogobutton;
        Vector3 landerresetposition;
        public bool landerdestroyed;
        bool firstgo;

        public bool m_placingpickup;
        public bool m_pickupplaced;
        public bool m_setpickup;
        GameObject placerpickup;
        GameObject pickupobject;
        public GameObject pickupscalerobj;
        public Slider pickupscaler;
        public GameObject m_placepickupbutton;
        public GameObject m_setpickupbutton;
        public GameObject m_pickupprefab;
        bool haspickupbeenplaced;

        public bool m_placingdropoff;
        public bool m_dropoffplaced;
        public bool m_setdropoff;
        GameObject placerdropoff;
        GameObject dropoffobject;
        public GameObject dropoffscalerobj;
        public Slider dropoffscaler;
        public GameObject m_placedropoffbutton;
        public GameObject m_setdropoffbutton;
        public GameObject m_dropoffprefab;
        public GameObject m_dropoffprefabfalse;


        void Start()
        {

            firingengines = false;
            m_createtracker = false;
            speed = 0.4f;
            stats.SetActive(false);
            m_placinglander = false;
            m_placingpad = false;
            m_landerplaced = false;
            m_padplaced = false;
            m_placingfinished = false;
            m_setlander = false;
            m_setpad = false;
            fuel = 1000;
            integrity = 100;
            m_caniload = true;
            distanceslider.SetActive(false);
            padscalerobj.SetActive(false);
            volcano1scalerobj.SetActive(false);
            volcano2scalerobj.SetActive(false);
            landerdestroyed = false;
            firstgo = true;
            m_trackedPlanePrefab.SetActive(false);



        }

        /// <summary>
        /// The Unity Update() method.
        /// </summary>
        public void Update()
        {

            trackerray = m_firstPersonCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            point = trackerray.GetPoint(slider.value);



            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

            _QuitOnConnectionErrors();

            // Check that motion tracking is tracking.
            if (Frame.TrackingState != TrackingState.Tracking)
            {
                const int lostTrackingSleepTimeout = 15;
                Screen.sleepTimeout = lostTrackingSleepTimeout;
                return;
            }

            Screen.sleepTimeout = SleepTimeout.NeverSleep;

            // Iterate over planes found in this frame and instantiate corresponding GameObjects to visualize them.
            Frame.GetPlanes(m_NewPlanes, TrackableQueryFilter.New);
            for (int i = 0; i < m_NewPlanes.Count; i++)
            {
                // Instantiate a plane visualization prefab and set it to track the new plane. The transform is set to
                // the origin with an identity rotation since the mesh for our prefab is updated in Unity World
                // coordinates.
                GameObject planeObject = Instantiate(TrackedPlanePrefab, Vector3.zero, Quaternion.identity,
                    transform);
                planeObject.GetComponent<TrackedPlaneVisualizer>().Initialize(m_NewPlanes[i]);
            }

            // Disable the snackbar UI when no planes are valid.
            Frame.GetPlanes(m_AllPlanes);
            bool showSearchingUI = true;
            for (int i = 0; i < m_AllPlanes.Count; i++)
            {
                if (m_AllPlanes[i].TrackingState == TrackingState.Tracking)
                {
                    showSearchingUI = false;
                    break;
                }
            }

            SearchingForPlaneUI.SetActive(showSearchingUI);

            

            // Raycast against the location the player touched to search for planes.
            //TrackableHit hit;
            //TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinBounds | TrackableHitFlags.PlaneWithinPolygon;

            if (!m_placingfinished)
            {




                TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinBounds | TrackableHitFlags.PlaneWithinPolygon;
                TrackableHit hit;

                //start the planes mechanic


                if (m_placinglander)
                {

                    if (!m_landerplaced)
                    {

                        if (Session.Raycast(Screen.width / 2, Screen.height / 2,raycastFilter, out hit))
                        {
                            

                            // Intanstiate an Andy Android object as a child of the anchor; it's transform will now benefit
                            // from the anchor's tracking.
                            placerlanderobject = Instantiate(m_marslanderPrefab, hit.Pose.position, hit.Pose.rotation);
                            m_landerplaced = true;
                            var anchor = hit.Trackable.CreateAnchor(hit.Pose);

                            // Andy should look at the camera but still be flush with the plane.
                            //placerlanderobject.transform.LookAt(m_firstPersonCamera.transform);
                            placerlanderobject.transform.rotation = Quaternion.Euler(0.0f,
                            placerlanderobject.transform.rotation.eulerAngles.y, placerlanderobject.transform.rotation.z);

                            // Use a plane attachment component to maintain Andy's y-offset from the plane
                            // (occurs after anchor updates).
                            placerlanderobject.transform.parent = anchor.transform;
                            print("placinglander");

                        }
                    }

                    if (m_landerplaced)
                    {
                        if (!m_setlander)
                        {
                            if (Session.Raycast(Screen.width / 2, Screen.height / 2, raycastFilter, out hit))
                            {
                                placerlanderobject.transform.position = hit.Pose.position;
                                placerlanderobject.transform.LookAt(2 * placerlanderobject.transform.position - m_firstPersonCamera.transform.position);
                                placerlanderobject.transform.rotation = Quaternion.Euler(0.0f,
                                placerlanderobject.transform.rotation.eulerAngles.y, placerlanderobject.transform.rotation.z);
                                placerlanderobject.transform.localScale = new Vector3(landerscaler.value, landerscaler.value, landerscaler.value);
                                print("setting lnader");
                            }
                        }
                    }

                    if (m_setlander)
                    {
                        
                        landerobject = Instantiate(m_marslanderPrefab, placerlanderobject.transform.position, Quaternion.identity);
                        landerobject.transform.localScale = placerlanderobject.transform.localScale;
                        landerobject.transform.LookAt(m_firstPersonCamera.transform);
                        landerobject.transform.rotation = Quaternion.Euler(0.0f,
                        placerlanderobject.transform.rotation.eulerAngles.y, placerlanderobject.transform.rotation.z);
                        landerresetposition = landerobject.transform.position;
                        Destroy(placerlanderobject);
                        m_setlander = false;
                        m_placinglander = false;
                        m_landerplaced = false;
                        print("landerset");
                    }
                }

                //padplacement

                if (m_placingpad)
                {

                    if (!m_padplaced)
                    {

                        if (Session.Raycast(Screen.width / 2, Screen.height / 2, raycastFilter, out hit))
                        {
                            

                            // Intanstiate an Andy Android object as a child of the anchor; it's transform will now benefit
                            // from the anchor's tracking.
                            placerpad = Instantiate(m_landingpadPrefab, hit.Pose.position, hit.Pose.rotation);
                            m_padplaced = true;
                            var anchor = hit.Trackable.CreateAnchor(hit.Pose);

                            // Andy should look at the camera but still be flush with the plane.
                            placerpad.transform.LookAt(m_firstPersonCamera.transform);
                            placerpad.transform.rotation = Quaternion.Euler(0.0f,
                            placerpad.transform.rotation.eulerAngles.y, placerpad.transform.rotation.z);

                            // Use a plane attachment component to maintain Andy's y-offset from the plane
                            // (occurs after anchor updates).
                            placerpad.transform.parent = anchor.transform;

                        }
                    }

                    if (m_padplaced)
                    {
                        if (!m_setpad)
                        {
                            if (Session.Raycast(Screen.width / 2, Screen.height / 2, raycastFilter, out hit))
                            {
                                placerpad.transform.position = hit.Pose.position;
                                placerpad.transform.localScale = new Vector3(padscaler.value, padscaler.value, padscaler.value);
                            }
                        }
                    }

                    if (m_setpad)
                    {
                        
                        padobject = Instantiate(m_landingpadPrefab, placerpad.transform.position, Quaternion.identity);
                        padobject.transform.LookAt(m_firstPersonCamera.transform);
                        padobject.transform.localScale = placerpad.transform.localScale;
                        padobject.transform.rotation = Quaternion.Euler(0.0f,
                        placerpad.transform.rotation.eulerAngles.y, placerpad.transform.rotation.z);
                        Destroy(placerpad);
                        m_setpad = false;
                        m_placingpad = false;

                    }
                }

                //volcano1
                if (m_placingvolcano1)
                {

                    if (!m_volcano1placed)
                    {

                        if (Session.Raycast(Screen.width / 2, Screen.height / 2, raycastFilter, out hit))
                        {
                            

                            // Intanstiate an Andy Android object as a child of the anchor; it's transform will now benefit
                            // from the anchor's tracking.
                            placervolcano1 = Instantiate(m_volcano1, hit.Pose.position, hit.Pose.rotation);
                            m_volcano1placed = true;
                            var anchor = hit.Trackable.CreateAnchor(hit.Pose);


                            // Andy should look at the camera but still be flush with the plane.
                            placervolcano1.transform.LookAt(m_firstPersonCamera.transform);
                            placervolcano1.transform.rotation = Quaternion.Euler(0.0f,
                            placervolcano1.transform.rotation.eulerAngles.y, placervolcano1.transform.rotation.z);

                            // Use a plane attachment component to maintain Andy's y-offset from the plane
                            // (occurs after anchor updates).
                            placervolcano1.transform.parent = anchor.transform;

                        }
                    }

                    if (m_volcano1placed)
                    {
                        if (!m_setvolcano1)
                        {
                            if (Session.Raycast(Screen.width / 2, Screen.height / 2, raycastFilter, out hit))
                            {
                                placervolcano1.transform.position = hit.Pose.position;
                                placervolcano1.transform.localScale = new Vector3(volcano1scaler.value, volcano1scaler.value, volcano1scaler.value);
                            }
                        }
                    }

                    if (m_setvolcano1)
                    {
                        
                        volcano1object = Instantiate(m_volcano1, placervolcano1.transform.position, Quaternion.identity);
                        volcano1object.transform.LookAt(m_firstPersonCamera.transform);
                        volcano1object.transform.localScale = placervolcano1.transform.localScale;
                        volcano1object.transform.rotation = Quaternion.Euler(0.0f,
                        placervolcano1.transform.rotation.eulerAngles.y, placervolcano1.transform.rotation.z);
                        Destroy(placervolcano1);
                        m_setvolcano1 = false;
                        m_placingvolcano1 = false;
                        m_volcano1placed = false;
                    }
                }

                //volcano2
                if (m_placingvolcano2)
                {

                    if (!m_volcano2placed)
                    {

                        if (Session.Raycast(Screen.width / 2, Screen.height / 2, raycastFilter, out hit))
                        {
                            

                            // Intanstiate an Andy Android object as a child of the anchor; it's transform will now benefit
                            // from the anchor's tracking.
                            placervolcano2 = Instantiate(m_volcano2, hit.Pose.position, hit.Pose.rotation);
                            m_volcano2placed = true;
                            var anchor = hit.Trackable.CreateAnchor(hit.Pose);

                            // Andy should look at the camera but still be flush with the plane.
                            placervolcano2.transform.LookAt(m_firstPersonCamera.transform);
                            placervolcano2.transform.rotation = Quaternion.Euler(0.0f,
                            placervolcano2.transform.rotation.eulerAngles.y, placervolcano2.transform.rotation.z);

                            // Use a plane attachment component to maintain Andy's y-offset from the plane
                            // (occurs after anchor updates).
                            placervolcano2.transform.parent = anchor.transform;

                        }
                    }

                    if (m_volcano2placed)
                    {
                        if (!m_setvolcano2)
                        {
                            if (Session.Raycast(Screen.width / 2, Screen.height / 2, raycastFilter, out hit))
                            {
                                placervolcano2.transform.position = hit.Pose.position;
                                placervolcano2.transform.localScale = new Vector3(volcano2scaler.value, volcano2scaler.value, volcano2scaler.value);
                            }
                        }
                    }

                    if (m_setvolcano2)
                    {
                        
                        volcano2object = Instantiate(m_volcano2, placervolcano2.transform.position, Quaternion.identity);
                        volcano2object.transform.LookAt(m_firstPersonCamera.transform);
                        volcano2object.transform.localScale = placervolcano2.transform.localScale;
                        volcano2object.transform.rotation = Quaternion.Euler(0.0f,
                        placervolcano2.transform.rotation.eulerAngles.y, placervolcano2.transform.rotation.z);
                        Destroy(placervolcano2);
                        m_setvolcano2 = false;
                        m_placingvolcano2 = false;
                        m_volcano2placed = false;
                    }
                }

                //stalagtites
                if (m_placingstalag)
                {

                    if (!m_stalagplaced)
                    {

                        if (Session.Raycast(Screen.width / 2, Screen.height / 2, raycastFilter, out hit))
                        {
                            // Create an anchor to allow ARCore to track the hitpoint as understanding of the physical
                            // world evolves.
                            var anchor = hit.Trackable.CreateAnchor(hit.Pose);

                            // Intanstiate an Andy Android object as a child of the anchor; it's transform will now benefit
                            // from the anchor's tracking.
                            placerstalag = Instantiate(m_stalagprefab, hit.Pose.position, hit.Pose.rotation);
                            m_stalagplaced = true;


                            // Andy should look at the camera but still be flush with the plane.
                            placerstalag.transform.LookAt(m_firstPersonCamera.transform);
                            placerstalag.transform.rotation = Quaternion.Euler(0.0f,
                            placerstalag.transform.rotation.eulerAngles.y, placerstalag.transform.rotation.z);

                            // Use a plane attachment component to maintain Andy's y-offset from the plane
                            // (occurs after anchor updates).
                            placerstalag.transform.parent = anchor.transform;

                        }
                    }

                    if (m_stalagplaced)
                    {
                        if (!m_setstalag)
                        {
                            if (Session.Raycast(Screen.width / 2, Screen.height / 2, raycastFilter, out hit))
                            {
                                placerstalag.transform.position = hit.Pose.position;
                                placerstalag.transform.localScale = new Vector3(stalagscaler.value, stalagscaler.value, stalagscaler.value);
                            }
                        }
                    }

                    if (m_setstalag)
                    {
                        
                        stalagobject = Instantiate(m_stalagprefab, placerstalag.transform.position, Quaternion.identity);
                        stalagobject.transform.LookAt(m_firstPersonCamera.transform);
                        stalagobject.transform.localScale = placerstalag.transform.localScale;
                        stalagobject.transform.rotation = Quaternion.Euler(0.0f,
                        placerstalag.transform.rotation.eulerAngles.y, placerstalag.transform.rotation.z);
                        Destroy(placerstalag);
                        m_setstalag = false;
                        m_placingstalag = false;
                        m_stalagplaced = false;


                    }
                }





                //dropoff
                if (m_placingdropoff)
                {

                    if (!m_dropoffplaced)
                    {

                        if (Session.Raycast(Screen.width / 2, Screen.height / 2, raycastFilter, out hit))
                        {


                            // Intanstiate an Andy Android object as a child of the anchor; it's transform will now benefit
                            // from the anchor's tracking.
                            placerdropoff = Instantiate(m_dropoffprefabfalse, hit.Pose.position, hit.Pose.rotation);
                            m_dropoffplaced = true;

                            // Create an anchor to allow ARCore to track the hitpoint as understanding of the physical
                            // world evolves.
                            var anchor = hit.Trackable.CreateAnchor(hit.Pose);


                            // Andy should look at the camera but still be flush with the plane.
                            placerdropoff.transform.LookAt(m_firstPersonCamera.transform);
                            placerdropoff.transform.rotation = Quaternion.Euler(0.0f,
                            placerdropoff.transform.rotation.eulerAngles.y, placerdropoff.transform.rotation.z);

                            // Use a plane attachment component to maintain Andy's y-offset from the plane
                            // (occurs after anchor updates).
                            placerdropoff.transform.parent = anchor.transform;


                        }
                    }

                    if (m_dropoffplaced)
                    {
                        if (!m_setdropoff)
                        {
                            if (Session.Raycast(Screen.width / 2, Screen.height / 2, raycastFilter, out hit))
                            {
                                placerdropoff.transform.position = hit.Pose.position;
                                placerdropoff.transform.localScale = new Vector3(dropoffscaler.value, dropoffscaler.value, dropoffscaler.value);
                            }
                        }
                    }

                    if (m_setdropoff)
                    {
                        
                        dropoffobject = Instantiate(m_dropoffprefab, placerdropoff.transform.position, Quaternion.identity);
                        dropoffobject.transform.LookAt(m_firstPersonCamera.transform);
                        dropoffobject.transform.localScale = placerdropoff.transform.localScale;
                        dropoffobject.transform.rotation = Quaternion.Euler(0.0f,
                        placerdropoff.transform.rotation.eulerAngles.y, placerdropoff.transform.rotation.z);
                        Destroy(placerdropoff);
                        m_setdropoff = false;
                        m_placingdropoff = false;
                        m_dropoffplaced = false;



                    }
                }



                //dropoff
                if (m_placingpickup)
                {

                    if (!m_pickupplaced)
                    {

                        if (Session.Raycast(Screen.width / 2, Screen.height / 2, raycastFilter, out hit))
                        {
                            // Create an anchor to allow ARCore to track the hitpoint as understanding of the physical
                            // world evolves.
                            var anchor = hit.Trackable.CreateAnchor(hit.Pose);

                            // Intanstiate an Andy Android object as a child of the anchor; it's transform will now benefit
                            // from the anchor's tracking.
                            placerpickup = Instantiate(m_pickupprefab, hit.Pose.position, hit.Pose.rotation);
                            m_pickupplaced = true;


                            // Andy should look at the camera but still be flush with the plane.
                            placerpickup.transform.LookAt(m_firstPersonCamera.transform);
                            placerpickup.transform.rotation = Quaternion.Euler(0.0f,
                            placerpickup.transform.rotation.eulerAngles.y, placerpickup.transform.rotation.z);

                            // Use a plane attachment component to maintain Andy's y-offset from the plane
                            // (occurs after anchor updates).
                            placerpickup.transform.parent = anchor.transform;

                        }
                    }

                    if (m_pickupplaced)
                    {
                        if (!m_setpickup)
                        {
                            if (Session.Raycast(Screen.width / 2, Screen.height / 2, raycastFilter, out hit))
                            {
                                placerpickup.transform.position = hit.Pose.position;
                                placerpickup.transform.localScale = new Vector3(pickupscaler.value, pickupscaler.value, pickupscaler.value);
                            }
                        }
                    }

                    if (m_setpickup)
                    {
                        
                        pickupobject = Instantiate(m_pickupprefab, placerpickup.transform.position, Quaternion.identity);
                        pickupobject.transform.LookAt(m_firstPersonCamera.transform);
                        pickupobject.transform.localScale = placerpickup.transform.localScale;
                        pickupobject.transform.rotation = Quaternion.Euler(0.0f,
                        placerpickup.transform.rotation.eulerAngles.y, placerpickup.transform.rotation.z);
                        Destroy(placerpickup);
                        haspickupbeenplaced = true;
                        m_setpickup = false;
                        m_placingpickup = false;
                        m_pickupplaced = false;



                    }
                }




            }





            if (landerobject != null)
            {
                if (m_placingfinished)
                {
                    jettrails = landerobject.transform.Find("Jets").gameObject;
                    kickuplocation = landerobject.transform.Find("kickup").gameObject;
                    landerspeed = m_rb.velocity.magnitude * 100;
                    fueltext.text = "Fuel: " + fuel.ToString("F2");
                    landerspeedtext.text = "Speed: " + landerspeed.ToString("F2");
                    integritytext.text = "Integrity: " + integrity.ToString("F2");
                    stats.SetActive(true);
                    print("this is running when placing is finished but the lander isn't destroyed");

                }
            }




            if (fuel <= 0)
            {
                if (m_caniload)
                {
                    StartCoroutine(reload());
                    m_caniload = false;
                }
            }

            if (landerdestroyed)
            {
                if (m_caniload)
                {
                    integrity = 100;
                    fuel = 1000;
                    landerspeed = 0;
                    landerobject = Instantiate(m_marslanderPrefab, landerresetposition, Quaternion.identity);
                    landerobject.transform.localScale = new Vector3(landerscaler.value, landerscaler.value, landerscaler.value);
                    m_caniload = false;
                    landerdestroyed = false;
                }
            }

            if (!landerdestroyed)
            {
                m_caniload = true;
            }
        }

        /// <summary>
        /// Quit the application if there was a connection error for the ARCore session.
        /// </summary>
        private void _QuitOnConnectionErrors()
        {
            if (m_IsQuitting)
            {
                return;
            }

            // Quit if ARCore was unable to connect and give Unity some time for the toast to appear.
            if (Session.ConnectionState == SessionConnectionState.UserRejectedNeededPermission)
            {
                _ShowAndroidToastMessage("Camera permission is needed to run this application.");
                m_IsQuitting = true;
                Invoke("DoQuit", 0.5f);
            }
            else if (Session.ConnectionState == SessionConnectionState.ConnectToServiceFailed)
            {
                _ShowAndroidToastMessage("ARCore encountered a problem connecting.  Please start the app again.");
                m_IsQuitting = true;
                Invoke("DoQuit", 0.5f);
            }
        }

        /// <summary>
        /// Actually quit the application.
        /// </summary>
        private void DoQuit()
        {
            Application.Quit();
        }

        /// <summary>
        /// Show an Android toast message.
        /// </summary>
        /// <param name="message">Message string to show in the toast.</param>
        private void _ShowAndroidToastMessage(string message)
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            if (unityActivity != null)
            {
                AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
                unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity,
                        message, 0);
                    toastObject.Call("show");
                }));
            }
        }

        public void placelander()
        {
            m_placinglander = true;
            m_placelanderbutton.SetActive(false);
            landerscalerobj.SetActive(true);
            m_setlanderbutton.SetActive(true);

        }

        public void setlander()
        {
            m_setlander = true;
            m_setlanderbutton.SetActive(false);
            landerscalerobj.SetActive(false);
            m_placepadbutton.SetActive(true);

        }


        public void placepad()
        {
            m_placingpad = true;
            m_placepadbutton.SetActive(false);
            padscalerobj.SetActive(true);
            m_setpadbutton.SetActive(true);
        }

        public void setpad()
        {
            m_setpad = true;
            m_setpadbutton.SetActive(false);
            showobjectbuttons();
            padscalerobj.SetActive(false);
        }

        public void placevolcano1()
        {
            m_placingvolcano1 = true;
            removeobjectbuttons();
            m_setvolcano1button.SetActive(true);
            volcano1scalerobj.SetActive(true);
        }
        public void setvolcano1()
        {
            m_setvolcano1 = true;
            m_setvolcano1button.SetActive(false);
            showobjectbuttons();
            volcano1scalerobj.SetActive(false);
        }
        public void placevolcano2()
        {
            m_placingvolcano2 = true;
            removeobjectbuttons();
            m_setvolcano2button.SetActive(true);
            volcano2scalerobj.SetActive(true);
        }
        public void setvolcano2()
        {
            m_setvolcano2 = true;
            m_setvolcano2button.SetActive(false);
            showobjectbuttons();
            volcano2scalerobj.SetActive(false);

        }
        public void placestalag()
        {
            m_placingstalag = true;
            removeobjectbuttons();
            m_setstalagbuton.SetActive(true);
            stalagscalerobj.SetActive(true);
        }
        public void setstalag()
        {
            m_setstalag = true;
            m_setstalagbuton.SetActive(false);
            showobjectbuttons();
            stalagscalerobj.SetActive(false);

        }
        public void placepickup()
        {
            m_placingpickup = true;
            removeobjectbuttons();
            m_setpickupbutton.SetActive(true);
            pickupscalerobj.SetActive(true);
        }
        public void setpickup()
        {
            m_setpickup = true;
            m_setpickupbutton.SetActive(false);
            showobjectbuttons();
            pickupscalerobj.SetActive(false);

        }
        public void placedropoff()
        {
            m_placingdropoff = true;
            removeobjectbuttons();
            m_setdropoffbutton.SetActive(true);
            dropoffscalerobj.SetActive(true);
        }
        public void setdropoff()
        {
            m_setdropoff = true;
            m_setdropoffbutton.SetActive(false);
            showobjectbuttons();
            dropoffscalerobj.SetActive(false);

        }


        public void gogogo()
        {
            m_takeoffbutton.SetActive(true);
            m_placingfinished = true;
            distanceslider.SetActive(true);
            removeobjectbuttons();
        }




        public void startplacing()
        {
            m_startbutton.SetActive(false);
            m_placelanderbutton.SetActive(true);
        }

        public void removeobjectbuttons()
        {
            m_placevolcano1button.SetActive(false);
            m_placevolcano2button.SetActive(false);
            m_placestalagbuton.SetActive(false);
            m_gogogobutton.SetActive(false);
            m_placepickupbutton.SetActive(false);
            m_placedropoffbutton.SetActive(false);
        }
        public void showobjectbuttons()
        {
            m_placevolcano1button.SetActive(true);
            m_placevolcano2button.SetActive(true);
            m_placestalagbuton.SetActive(true);
            m_gogogobutton.SetActive(true);
            m_placedropoffbutton.SetActive(true);
            m_placepickupbutton.SetActive(true);
        }

        public void mainmenu()
        {
            SceneManager.LoadScene("Menu");
        }


        public void firethemup()
        {
            firingengines = true;
        }
        public void turnthemoff()
        {
            firingengines = false;
        }

        private void FixedUpdate()
        {
            if (landerobject != null)
            {
                if (m_placingfinished)
                {

                    if (!firingengines)
                    {

                        jettrails.SetActive(false);

                    }



                    if (firingengines)
                    {
                        if (fuel > 0)
                        {

                            m_rb = landerobject.GetComponent<Rigidbody>();
                            m_rb.isKinematic = false;
                            m_rb.AddRelativeForce(Vector3.up * 2.5f, ForceMode.Force);
                            float step = speed * Time.deltaTime;
                            //landerobject.transform.position = Vector3.MoveTowards(landerobject.transform.position, new Vector3(point.x, landerobject.transform.position.y, point.z), step);
                            jettrails.SetActive(true);
                            down = kickuplocation.transform.TransformDirection(Vector3.down);
                            RaycastHit kickhit;
                            if (Physics.Raycast(kickuplocation.transform.position, down, out kickhit, 0.5f))
                            {
                                GameObject impactGo = Instantiate(kickupeffect, kickhit.point, Quaternion.LookRotation(kickhit.normal));
                                impactGo.transform.localScale = new Vector3(landerobject.transform.localScale.x / 1.2f, landerobject.transform.localScale.y / 1.2f, landerobject.transform.localScale.z / 1.2f);
                                Destroy(impactGo, 0.3f);
                            }
                            fuel -= 0.5f;

                        }

                    }
                }
            }




        }



        public IEnumerator reload()
        {
            m_caniload = false;
            yield return new WaitForSeconds(2);
            Destroy(landerobject);
            integrity = 100;
            fuel = 1000;
            landerspeed = 0;
            landerobject = Instantiate(m_marslanderPrefab, landerresetposition, Quaternion.identity);
            landerobject.transform.localScale = new Vector3(landerscaler.value, landerscaler.value, landerscaler.value);
            landerdestroyed = false;
        }

        

    }
}
*/