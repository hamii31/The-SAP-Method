Name: The SAP Method 
Creator: Hami Ibriyamov 
    
The Signalization Adaptation Prevention Method or SAP Method (for short) is designed to protect a collection of sensitive data to an attack by encrypting the sensitive data with a custom, semi - random generated key. The copy of the decrypted data is accessible only by an authorized personel, no one else can access it directly without authentication and authorization. 

The example: 
Someone is trying to force their way to a public copy of a collection of sensitive data via an identity theft attack. After some failed attempts, the Signalization Phase is activated, which is responsible of activating the Adaptation Phase. During the Adaptation Phase, a custom key is generated and used to encrypt the sensitive data. 
The Prevention Phase is activated, during which the encryption takes place. After the data has been successfully encrypted, a decrypted copy is sent to the server admin in order to preserve it in case of data loss, preventing the attack from being successful. 
