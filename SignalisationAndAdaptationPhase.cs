using System.Security.Cryptography;
using The_BCSAP_Algorithm;

namespace The_SAP_Algorithm
{
    //<summary>
    // Name: The SAP Algorithm 
    // Creator: Hami Ibriyamov 
    // The Signalization Adaptation Prevention Algorithm
    // or SAP Algorithm is designed to adapt a collection 
    // to outer harmful influence to the contents of said 
    // collection 
    // For example: A collection of sensitive data is hijacked 
    // and it's contents are about to be leaked. The SAP Algorithm
    // prevents that by modifying the collection to unreadable, 
    // uncrackable encryption and the algorithm itself can only 
    // decipher the encrypted data. When the SAP Algorithm encrypts 
    // the data, a key is created and sent to a specified administrator 
    // in case of permament encryption, which would lead to loss of data
    //<summary>
    public class SingalisationAndAdaptationPhase
    {
        private static bool Encrypted = false;
        static void Main(string[] args)
        {
            IDictionary<int, ServerAdmin> sensitiveData = new Dictionary<int, ServerAdmin>
            {
                {1, new ServerAdmin{ SuperSecretInfo = "Xa@fj@Sd"} },
                {2, new ServerAdmin{ SuperSecretInfo = "KSDJkk@23" } },
                {3, new ServerAdmin{ SuperSecretInfo = "S244qWES"} }
            };
            // For example's sake the "sensitive data" is public

            var LoginAttempts = 0;

            while (true)
            {
                string? command = Console.ReadLine();
                if (command?.ToLower() == "break")
                {
                    break;
                }
                if (command?.ToLower() == "show")
                {
                    if (Encrypted)
                    {
                        Console.WriteLine("To see the decrypted data, enter as a Server Admin.");
                    }
                    Console.Write("Enter Username:");
                    string? username = Console.ReadLine();

                    Console.WriteLine();

                    Console.Write("Enter Password:");
                    string? password = Console.ReadLine();
                    LoginAttempts++;

                    // if the password and username are equal to a server administrator, you get access to the data
                    if (ServerAdmin.IsAdmin(username, password)) 
                    {
                        LoginAttempts = 0;
                        // if the data was encrypted beforehand and the credentials given are correct, the data gets decrypted
                        if (Encrypted)
                        {
                            ServerAdmin.Show(username, password);
                            Encrypted = false;
                        }
                        // else, show the sensitive data to the authorized person 
                        else
                        {
                            foreach (var index in Enumerable.Range(1, sensitiveData.Count()))
                            {
                                Console.WriteLine($"User {index}'s super secret info is {sensitiveData[index].SuperSecretInfo}");
                            }
                        }
                     
                    }
                    // else, the SAP Algorithm signalizes for a potential security breach and encrypts the data momentarily
                    else if(LoginAttempts > 3)
                    {
                        // SIGNALIZATION PHASE
                        // <summary>
                        // In this phase the SAP Algorithm is triggered if it deems a security breach is plausible
                        // due to the many failed attempts to log in as a server administrator and get access to sensitive data
                        // <summary>

                        Console.WriteLine("Not correct credentials!");
                        passPhraseGenerator(sensitiveData);
                        Encrypted = true;
                    }
                    else
                    {
                        Console.WriteLine("Not correct credentials!");
                    }
                }
                else
                {
                    Console.WriteLine("Unrecognized command!");
                }
            }
        }
       private static void passPhraseGenerator(IDictionary<int, ServerAdmin> data)
       {
            // ADAPTATION PHASE
            // <summary>
            // Following immediately after the Signalization phase, the adaptation phase creates a custom password phrase
            // used in the encryption and decryption of the sensitive data. After the custom password is created, the Prevention phase ensues.
            // <summary>

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            int length = (int)Math.Pow(data.Count(), data.Count());
            var charArray = new char[length];
            for (int i = 0; i < length; i++)
            {
                int index = RandomNumberGenerator.GetInt32(chars.Length);
                charArray[i] = chars[index];
            }
            string passPhrase = new string(charArray);

            ICollection<string> encryptedPasses = new List<string>();
            foreach (int index in Enumerable.Range(1, data.Count()))
            {
                string encryptInfo = PreventionPhase.Encrypt(index, data[index].SuperSecretInfo, passPhrase);
                encryptedPasses.Add(encryptInfo);
            }
            Console.WriteLine("Personal data successfully encrypted!");
        }
    }
}
