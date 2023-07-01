Name: The SAP Method 
Creator: Hami Ibriyamov 
Date: July 1st 2023
    
The Signalization Adaptation Prevention Method or SAP Method (for short) is designed to protect a collection of sensitive data from an identity theft attack by encrypting the sensitive data with a custom, semi - random generated key during a session between the server and a server admin. The copy of the decrypted data is accessible only by the authorized personel and developers, while the public copy is encrypted permanently. 

The example: 
Someone is trying to force their way to a public copy of a collection of sensitive data via an identity theft attack. After some failed attempts, the Signalization Phase is activated, which is responsible of activating the Adaptation Phase. During the Adaptation Phase, a custom key is generated and used to encrypt the sensitive data. 
The Prevention Phase is activated, during which the encryption takes place. After the data has been successfully encrypted, a decrypted copy is sent for safekeeping to an authorized personnel in order to preserve it in case of data loss, while the public copy is encrypted indefinitely, effectively preventing the attack from being successful. 


In short - Server admin requests a session with the server. A hacker tries to enter the session, pretending to be the admin. The SAP method takes action to protect the sensitive data by encrypting the requested copy indefinitely. This way, if the hacker successfully manages to enter the session, they will only be able to access the encrypted data. The original, decrypted data is sent in a second collection back to the server for safekeeping in case of data loss. 