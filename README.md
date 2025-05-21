# StreamingEncryption
This is a C# .NET Framework application that streams a file and securely stores it using System.Security.Cryptography.ProtectedData (DPAPI)

# Info
This function uses the Data Protection API (DPAPI) via System.Security.Cryptography.ProtectedData to Encrypt your data.
With this function, your data is encrypted using system information as the data's encryption key, an example is the TPM chip if supported.

# Example
In this example, we stream a file from the `url` parameter and encrypt it before it can touch memory, we then ensure it's valid. Once it's valid, we then get user input to get permission to decrypt and store this file on the disk under `filename`
