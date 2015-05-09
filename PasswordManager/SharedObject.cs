using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;

namespace PasswordManager
{
    // A static class for passing information among forms.
    public static class SharedObject
    {
        public static bool passwordGood { get; set; }
        public static string generatedPassword { get; set; }
        public static SecureString encryptedPassword = new SecureString();
        public static bool newCredentialAdded { get; set; }
        
    }
}
