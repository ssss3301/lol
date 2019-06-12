using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace lolgame
{
    public enum CommandType
    {
        CommandType_System
    };

    public enum SystemSubType
    {
        Login,
        Logout
    }
    
    [Serializable]
    public struct LoginMessage
    {
        public string account;
        public string password;
    }

    [Serializable]
    public struct LoginoutMessage
    {
        public string account;
    }

    [Serializable]
    public class NetCommand
    {
        public CommandType commandType;
        public ushort commandSubtype;
        public ushort commandID;
        public object message;

        public byte[] ToByteArray()
        {
            byte[] buffer;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                buffer = ms.GetBuffer();
            }

            return buffer;
        }
    }

}