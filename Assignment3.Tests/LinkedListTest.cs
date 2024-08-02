using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Assignment3;
using Assignment3.Utility;

namespace Assignment3.Tests
{
    internal class LinkedListTest
    {
        private SLL<User> list; 

        [SetUp]
        public void SetUp() 
        { 
            list = new SLL<User>(); 
        }

        [Test]
        public void TestIsEmpty()
        {
            Assert.IsTrue(list.IsEmpty());
        }

        [Test]
        public void TestAppend()
        {
            User user1 = new User(1, "Lily", "dogbowl@hogmail.clom", "password");
            User user2 = new User(2, "Ruby", "smokeshow@gorgeous.beautiful", "password");
            list.Append(user1);
            list.Append(user2);
            Assert.False(list.IsEmpty());
            Assert.That(user1, Is.EqualTo(list.GetValue(0)));
            Assert.That(user2, Is.EqualTo(list.GetValue(1)));
            Assert.That(list.Count(), Is.EqualTo(2));
        }

        [Test]
        public void TestPrepend()
        {
            User user = new User(1, "Lily", "dogbowl@hogmail.clom", "password");
            list.Prepend(user);
            Assert.False(list.IsEmpty());
            Assert.That(user, Is.EqualTo(list.GetValue(0)));
            Assert.That(list.Count(), Is.EqualTo(1));
        }

        [Test]
        public void TestRemove()
        {
            User user1 = new User(1, "Lily", "dogbowl@hogmail.clom", "password");
            User user2 = new User(2, "Ruby", "smokeshow@gorgeous.beautiful", "password");
            User user3 = new User(3, "Gina", "contessa@canine.com", "password");
            list.Append(user1);
            list.Append(user2);
            list.Append(user3);
            Assert.False(list.IsEmpty());
            list.Remove(1);
            Assert.That(user1, Is.EqualTo(list.GetValue(0)));
            Assert.That(user3, Is.EqualTo(list.GetValue(1)));
            Assert.That(list.Count(), Is.EqualTo(2));
        }

        [Test]
        public void TestRemoveFirst() 
        {
            User user1 = new User(1, "Lily", "dogbowl@hogmail.clom", "password");
            User user2 = new User(2, "Ruby", "smokeshow@gorgeous.beautiful", "password");
            list.Append(user1);
            list.Append(user2);
            Assert.False(list.IsEmpty());
            list.RemoveFirst();
            Assert.That(list.GetValue(0), Is.EqualTo(user2));
            Assert.That(list.Count(), Is.EqualTo(1));
        }

        [Test]
        public void TestRemoveLast() 
        {
            User user1 = new User(1, "Lily", "dogbowl@hogmail.clom", "password");
            User user2 = new User(2, "Ruby", "smokeshow@gorgeous.beautiful", "password");
            list.Append(user1);
            list.Append(user2);
            Assert.False(list.IsEmpty());
            list.RemoveLast();
            Assert.That(user1, Is.EqualTo(list.GetValue(0)));
            Assert.That(list.Count(), Is.EqualTo(1));
        }

        [Test]
        public void TestAdd() 
        {
            User user1 = new User(1, "Lily", "dogbowl@hogmail.clom", "password");
            User user2 = new User(2, "Ruby", "smokeshow@gorgeous.beautiful", "password");
            User user3 = new User(3, "Gina", "contessa@canine.com", "password");
            list.Append(user1);
            list.Append(user2);
            list.Add(user3, 1);
            Assert.False(list.IsEmpty());
            Assert.That(user1, Is.EqualTo(list.GetValue(0)));            
            Assert.That(user3, Is.EqualTo(list.GetValue(1)));
            Assert.That(user2, Is.EqualTo(list.GetValue(2)));
            Assert.That(list.Count(), Is.EqualTo(3));
        }

        [Test]
        public void TestReplace()
        {
            User user1 = new User(1, "Lily", "dogbowl@hogmail.clom", "password");
            User user2 = new User(2, "Ruby", "smokeshow@gorgeous.beautiful", "password");            
            list.Append(user1);
            list.Replace(user2, 0);
            Assert.False(list.IsEmpty());
            Assert.That(user2, Is.EqualTo(list.GetValue(0)));
            Assert.That(list.Count(), Is.EqualTo(1));
        }

        [Test]
        public void TestGetValue()
        {
            User user = new User(1, "Lily", "dogbowl@hogmail.clom", "password");
            list.Append(user);
            Assert.False(list.IsEmpty());
            Assert.That(list.GetValue(0), Is.EqualTo(user));
        }

        [Test]
        public void TestIndexOf() 
        {
            User user1 = new User(1, "Lily", "dogbowl@hogmail.clom", "password");
            User user2 = new User(2, "Ruby", "smokeshow@gorgeous.beautiful", "password");
            list.Append(user1);
            list.Append(user2);
            Assert.False(list.IsEmpty());
            Assert.That(list.IndexOf(user1), Is.EqualTo(0));
            Assert.That(list.IndexOf(user2), Is.EqualTo(1));
        }

        [Test]
        public void TestContains()
        {
            User user = new User(1, "Lily", "dogbowl@hogmail.clom", "password");
            list.Append(user);
            Assert.False(list.IsEmpty());
            Assert.True(list.Contains(user));
        }

        [Test]
        public void TestReverse()
        {
            User user1 = new User(1, "Lily", "dogbowl@hogmail.clom", "password");
            User user2 = new User(2, "Ruby", "smokeshow@gorgeous.beautiful", "password");
            User user3 = new User(3, "Gina", "contessa@canine.com", "password");
            list.Append(user1);
            list.Append(user2);
            list.Append(user3);
            list.Reverse();
            Assert.That(list.IndexOf(user3), Is.EqualTo(0));
            Assert.That(list.IndexOf(user2), Is.EqualTo(1));
            Assert.That(list.IndexOf(user1), Is.EqualTo(2));
        }
    }
}
