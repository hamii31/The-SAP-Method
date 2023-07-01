using System.Security.Cryptography;
using The_BCSAP_Method;

namespace The_SAP_Method
{
    //<summary>
    // Name: The SAP Method
    // Creator: Hami Ibriyamov
    //<summary>

    public class SingalisationAndAdaptationPhase
    {
        private static bool Encrypted = false;
        static void Main(string[] args)
        {
            Dictionary<int, string> sensitiveData = new Dictionary<int, string>();
            sensitiveData = ServerAdmin.GetData("CloudJumper", "123", sensitiveData);
            // For the example's sake the server administrator's username and password are given to the 
            // get method in order to retrieve a copy of the sensitive data beforehand 
            // (Simulating a logged in administrator working on the collection of data)
            
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
                        //<summary>
                        // If there is a successful identity theft attack the hacker would only have access to the 
                        // encrypted data. If there was no suspicion of an identity theft attack, the data wouldn't
                        // be encrypted in the first place.
                        if (Encrypted && LoginAttempts == 0)
                        {
                            ServerAdmin.Show(username, password);
                            Encrypted = false;
                        }
                        else
                        {
                            foreach (var index in Enumerable.Range(1, sensitiveData.Count()))
                            {
                                Console.WriteLine($"User {index}'s super secret info is {sensitiveData[index]}");
                            }
                        }
                    }
                    // else, the SAP Method signalizes for a potential security breach and encrypts the data momentarily
                    else if(LoginAttempts > 3)
                    {
                        // SIGNALIZATION PHASE
                        // <summary>
                        // In this phase the SAP Method is triggered if it deems a security breach is plausible
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
       private static void passPhraseGenerator(IDictionary<int, string> data)
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
                string encryptInfo = PreventionPhase.Encrypt(index, data[index].ToString(), passPhrase);
                encryptedPasses.Add(encryptInfo);
            }
            Console.WriteLine("Personal data successfully encrypted!");

            //Console.WriteLine(string.Join("", encryptedPasses));
            // Uncomment to see encrypted data
        }
    }
}
