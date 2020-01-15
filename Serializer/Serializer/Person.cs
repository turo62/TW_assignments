using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
using System.Text;

namespace Serializer
{
    [Serializable]
    public class Person : IDeserializationCallback, ISerializable
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfRecording;
        [NonSerialized]
        public   int SerialNo;

        public Person() { }

        public Person(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            Name = (string)info.GetValue("Name", typeof(string));
            Address = (string)info.GetValue("Address", typeof(string));
            Phone = (string)info.GetValue("Phone", typeof(string));
            DateOfRecording = (DateTime)info.GetValue("DateOfRecording", typeof(DateTime));
        }

        public Person(string myName, string myAdress, string myPhone, DateTime actDate, int serialNumber)
        {
            Name = myName;
            Address = myAdress;
            Phone = myPhone;
            DateOfRecording = DateTime.Now;
            SerialNo = serialNumber;
        }

        public override string ToString()
        {
            return "Name: " + Name + ", Address: " + Address + ", phone: " + Phone + " Date of recording: " + DateOfRecording;
        }

        public void Serialize(string output)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(output, FileMode.Create, FileAccess.Write);

                formatter.Serialize(stream, this);
                stream.Close();
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Access to {0} is denied. ", output);
            }
        }

        private void MessageBox()
        {
            throw new NotImplementedException();
        }

        public static Person Deserialize(int serialNum)
        {
            string input = @"C:\ForTrials\person" + serialNum + ".dat";
            Person objnew = new Person();
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(input, FileMode.Open, FileAccess.Read);
            objnew = (Person)formatter.Deserialize(stream);
            stream.Close();

            /*Console.WriteLine(objnew.Name);
            Console.WriteLine(objnew.Address);
            Console.WriteLine(objnew.Phone);
            Console.WriteLine(objnew.DateOfRecording);

            Console.ReadKey();*/

            return objnew;
        }

        void IDeserializationCallback.OnDeserialization(Object sender)
        {
            //age = DateTime.Now.Year - BirthDay.Year;
        }

        [SecurityPermission(SecurityAction.LinkDemand,
            Flags = SecurityPermissionFlag.SerializationFormatter)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new System.ArgumentNullException("info");
            }

            info.AddValue("Name", this.Name);
            info.AddValue("Address", this.Address);
            info.AddValue("Phone", this.Phone);
            info.AddValue("DateOfRecording", this.DateOfRecording);
        }
    }
}
