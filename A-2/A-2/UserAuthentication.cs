using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_2
{
    public class UserAuthentication
    {
        private string registeredUsername;
        private string registeredPassword;

        public UserAuthentication()
        {
            registeredUsername = null;
            registeredPassword = null;
        }

        public bool RegisterUser(string username, string password)
        {
            if (registeredUsername == null)
            {
                registeredUsername = username;
                registeredPassword = password;
                return true; // Registration successful
            }
            return false; // User already registered
        }

        public bool LoginUser(string username, string password)
        {
            if (username == registeredUsername && password == registeredPassword)
            {
                return true; // Login successful
            }
            return false; // Invalid username or password
        }

        public bool ResetPassword(string username, string newPassword)
        {
            if (username == registeredUsername)
            {
                registeredPassword = newPassword;
                return true; // Password reset successful
            }
            return false; // User not found
        }
    }

    [TestFixture]
    public class UserAuthenticatorTests
    {
        private UserAuthentication userAuthentication;

        [SetUp]
        public void Setup()
        {
            userAuthentication = new UserAuthentication();
        }

        [Test]
        public void TestUserRegistration()
        {
            Assert.IsTrue(userAuthentication.RegisterUser("user1", "password1"));
            Assert.IsFalse(userAuthentication.RegisterUser("user2", "password2")); // User already registered
        }

        [Test]
        public void TestUserLogin()
        {
            userAuthentication.RegisterUser("user3", "password3");

            Assert.IsTrue(userAuthentication.LoginUser("user3", "password3"));
            Assert.IsFalse(userAuthentication.LoginUser("user3", "wrongpassword")); // Invalid password
            Assert.IsFalse(userAuthentication.LoginUser("nonexistentuser", "password")); // User does not exist
        }

        [Test]
        public void TestPasswordReset()
        {
            userAuthentication.RegisterUser("user4", "password4");

            Assert.IsTrue(userAuthentication.ResetPassword("user4", "newpassword"));
            Assert.IsFalse(userAuthentication.ResetPassword("nonexistentuser", "newpassword")); // User does not exist
        }
    }
}

