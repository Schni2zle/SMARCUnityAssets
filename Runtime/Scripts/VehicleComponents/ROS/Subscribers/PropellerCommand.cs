using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils = DefaultNamespace.Utils;

using RosMessageTypes.Smarc; // ThrusterRPM
using Propeller = VehicleComponents.Actuators.Propeller;

namespace VehicleComponents.ROS.Subscribers
{
    [RequireComponent(typeof(Propeller))]
    public class PropellerCommand : ActuatorSubscriber<ThrusterRPMMsg>
    {        
        Propeller prop;
        
        void Awake()
        {
            prop = GetComponent<Propeller>();
            if(prop == null)
            {
                Debug.Log("No propeller found!");
                return;
            }
        }

        protected override void UpdateVehicle(bool reset)
        {
            if(prop == null) return;
            if(reset)
            { 
                prop.SetRpm(0);
                return;
            }

            prop.SetRpm(ROSMsg.rpm);
        }
    }
}