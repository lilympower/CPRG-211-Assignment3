using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Assignment3.Utility;

namespace Assignment3.Tests
{
    public static class SerializationHelper
    {
        /// <summary>
        /// Serializes (encodes) users
        /// </summary>
        /// <param name="users">List of users</param>
        /// <param name="fileName"></param>
        public static void SerializeUsers(ILinkedListADT<User> users, string fileName)
        {
            var userList = ConvertToList(users);
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>));
            using (FileStream stream = File.Create(fileName))
            {
                serializer.WriteObject(stream, userList);
            }
        }

        /// <summary>
        /// Deserializes (decodes) users
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>List of users</returns>
        public static ILinkedListADT<User> DeserializeUsers(string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>));
            using (FileStream stream = File.OpenRead(fileName))
            {
                var userList = (List<User>)serializer.ReadObject(stream);
                return ConvertToLinkedList(userList);
            }
        }

        private static List<User> ConvertToList(ILinkedListADT<User> list)
        {
            List<User> userList = new List<User>();
            for (int i = 0; i < list.Count(); i++)
            {
                userList.Add(list.GetValue(i));
            }
            return userList;
        }

        private static ILinkedListADT<User> ConvertToLinkedList(List<User> userList)
        {
            ILinkedListADT<User> linkedList = new SLL<User>();
            foreach (var user in userList)
            {
                linkedList.Append(user);
            }
            return linkedList;  
        }
    }
}
