using UnityEngine;
using RosMessageTypes.Smarc;
using Unity.Robotics.Core; // Clock

using Propeller = VehicleComponents.Actuators.Propeller;

namespace VehicleComponents.ROS.Publishers
{
    [RequireComponent(typeof(Propeller))]
    public class PropellerFeedback: ActuatorPublisher<ThrusterFeedbackMsg>
    {
        Propeller prop;
        void Start()
        {
            prop = GetComponent<Propeller>();
            if(prop == null)
            {
                Debug.Log("No propeller found!");
                return;
            }
        }

        public override void UpdateMessage()
        {
            if(prop == null) return;

            ROSMsg.rpm.rpm = (int)prop.rpm;
            ROSMsg.header.stamp = new TimeStamp(Clock.time);
        }
    }
}