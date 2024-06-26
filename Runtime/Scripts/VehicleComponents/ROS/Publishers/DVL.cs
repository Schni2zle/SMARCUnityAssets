using UnityEngine;
using RosMessageTypes.Sensor;
using Unity.Robotics.Core; //Clock
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using RosMessageTypes.Smarc;
using RosMessageTypes.Std;

using SensorDVL = VehicleComponents.Sensors.DVL;

namespace VehicleComponents.ROS.Publishers
{
    [RequireComponent(typeof(SensorDVL))]
    class DVL: SensorPublisher<DVLMsg, SensorDVL>
    { 

        DVLBeamMsg[] beamMsgs;

        void Start()
        {
            ROSMsg.header.frame_id = sensor.linkName;
            beamMsgs = new DVLBeamMsg[sensor.numBeams];
            for(int i=0; i < sensor.numBeams; i++)
            {
                beamMsgs[i] = new DVLBeamMsg();
            }
            ROSMsg.beams = beamMsgs;
        }

        public override void UpdateMessage()
        {
            ROSMsg.header.stamp = new TimeStamp(Clock.time);
            
            for(int i=0;i < sensor.numBeams; i++)
            {
                ROSMsg.beams[i].range = sensor.ranges[i];
            }
            ROSMsg.velocity = sensor.velocity.To<FLU>();
            ROSMsg.altitude = sensor.altitude;
        }
    }
}