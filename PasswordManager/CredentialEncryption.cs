using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace PasswordManager
{
    public class CredentialEncryption
    {
        private static SymmetricAlgorithm AESProvider;
        
        private const int ITERATION_NUMBER = 10000;
        private const int AES_BIT_SIZE = 256;
        private const int KEY_SIZE = 32;
        private const int IV_SIZE = 16;

        public CredentialEncryption()
        {
            /*database = new SQLiteDatabase();

            // Establish AES provider that uses AES 256-bit encryption
            AESProvider = new AesCryptoServiceProvider();
            AESProvider.KeySize = AES_BIT_SIZE;

            // Generate key using user's password plus the stored salt
            Rfc2898DeriveBytes deriveKey = new Rfc2898DeriveBytes(ConvertToUnsecureString(SharedObject.encryptedPassword), Convert.FromBase64String(database.SelectSalt()), ITERATION_NUMBER);
            AESProvider.Key = deriveKey.GetBytes(KEY_SIZE);

            deriveKey.Dispose();*/
        }

        public static string EncryptCredential(string plainText)
        {
            // Generate new initialization vector
            AESProvider.GenerateIV();
            
            ICryptoTransform encryptor = AESProvider.CreateEncryptor();

            // Convert string to bytes and then encrypt the byte array
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] cipherBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

            // Add IV to the beginning of the encrypted bytes
            cipherBytes = AESProvider.IV.Concat(cipherBytes).ToArray();

            return Convert.ToBase64String(cipherBytes);
        }

        public static string DecryptCredential(string cipherText)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            // Take IV from beginning of the cipher
            AESProvider.IV = cipherBytes.Take(IV_SIZE).ToArray();

            ICryptoTransform decryptor = AESProvider.CreateDecryptor();

            // Decrypt bytes after the IV
            byte[] plainBytes = decryptor.TransformFinalBlock(cipherBytes, IV_SIZE, cipherBytes.Length - IV_SIZE);

            return Encoding.UTF8.GetString(plainBytes);
        }

        public static void DeriveKey()
        {
            SQLiteDatabase database = new SQLiteDatabase();

            // Establish AES provider that uses AES 256-bit encryption
            AESProvider = new AesCryptoServiceProvider();
            AESProvider.KeySize = AES_BIT_SIZE;

            // Generate key using user's password plus the stored salt
            Rfc2898DeriveBytes deriveKey = new Rfc2898DeriveBytes(ConvertToUnsecureString(SharedObject.encryptedPassword), Convert.FromBase64String(database.SelectSalt()), ITERATION_NUMBER);
            AESProvider.Key = deriveKey.GetBytes(KEY_SIZE);

            deriveKey.Dispose();
        }

        public static string ConvertToUnsecureString(SecureString securePassword)
        {
            if (securePassword != null)
            {
                IntPtr unmanagedString = IntPtr.Zero;
                
                try
                {
                    unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                    return Marshal.PtrToStringUni(unmanagedString);
                }
                finally
                {
                    // Remove unencrypted password from memory when it's no longer needed
                    Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
                }
            }

            return "";
        }
    }
}