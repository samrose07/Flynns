/* This script was made by Samuel Rose at Boise State University.
 * 
 * This script is made to initiate the saving. Clearly, I was more confused by this class
 * when I originally wrote it, as demonstrated by the first comment there LOL
 * 
 * Biodigital Jazz, man
 */
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{

    //oh god. The save system. Sam, i am commenting this for you so you don't 
    //get lost again. You can do this.

        //static cuz there should only be one instance.
    public static void SavePlayer(GameManager gm)
    {

        //This method takes in something constant. Brackeys used the player, but
        /*you used the GM since it is what handles all the global stuff for the player.
         * 
         * Start by making a formatter to encrypt data.
         */
        BinaryFormatter formatter = new BinaryFormatter();

        //gotta get the path. Persistent data path is where the user puts it. You can add silly little file extensions hehe
        string path = Application.persistentDataPath + "/player.sam";

        //open up the file stream and create. DON'T FORGET TO CLOSE THIS AFTER YOU ARE DONE WITH IT.
        FileStream stream = new FileStream(path, FileMode.Create);

        //inherits the playerdata, sends GM along to get the stuff.
        PlayerData data = new PlayerData(gm);

        //serialize means save. Save at stream, using the playerdata
        formatter.Serialize(stream, data);

        //CLOSE THE DARN STREAM
        stream.Close();
       // Debug.Log("Game saved at " + path); for testing purposes.
    }

    //static because there should only be one instance.
    public static PlayerData LoadPlayer()
    {

        //find the path again, since last path was local to that method.
        string path = Application.persistentDataPath + "/player.sam";

        //check if the file even exists.
        if(File.Exists(path))
        {
            //create another formatter for decryption.
            BinaryFormatter formatter = new BinaryFormatter();

            //open up another stream DON'T FORGET TO CLOSE THIS.
            FileStream stream = new FileStream(path, FileMode.Open);

            //decrypt the data, setting data as the decryption.
            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            //CLOSE IT DAMMIT.
            stream.Close();

            //give whatever is calling this method the data you decrypted.
            return data;
        }
        else
        {
            //otherwise, nothing.
            //Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
