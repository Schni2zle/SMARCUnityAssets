//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;

namespace RosMessageTypes.Geographic
{
    [Serializable]
    public class GeoPointStampedMsg : Message
    {
        public const string k_RosMessageName = "geographic_msgs/GeoPointStamped";
        public override string RosMessageName => k_RosMessageName;

        public HeaderMsg header;
        public GeoPointMsg position;

        public GeoPointStampedMsg()
        {
            this.header = new HeaderMsg();
            this.position = new GeoPointMsg();
        }

        public GeoPointStampedMsg(HeaderMsg header, GeoPointMsg position)
        {
            this.header = header;
            this.position = position;
        }

        public static GeoPointStampedMsg Deserialize(MessageDeserializer deserializer) => new GeoPointStampedMsg(deserializer);

        private GeoPointStampedMsg(MessageDeserializer deserializer)
        {
            this.header = HeaderMsg.Deserialize(deserializer);
            this.position = GeoPointMsg.Deserialize(deserializer);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.header);
            serializer.Write(this.position);
        }

        public override string ToString()
        {
            return "GeoPointStampedMsg: " +
            "\nheader: " + header.ToString() +
            "\nposition: " + position.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize);
        }
    }
}