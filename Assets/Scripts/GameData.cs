using UnityEngine;

public static class GameData
{    
    public static int SelectedRoom { get; set; } = 1;
    public static int SelectedAudio { get; set; } = 0;
    public static int SelectedSkin { get; set; } = 0;

    public static PatientController PatientController { get; set; }
    public static Camera PlayerCamera { get; set; }

    public static int NumberOfRooms = 1;
    public static int NumberOfAudios = 1;
    public static int NumberOfSkins = 1;

    public static void SelectRoom()
    {
        // select a random number between 1 and NumberOfRooms, inclusive
        SelectedRoom = Random.Range(1, NumberOfRooms + 1);
    }

    public static void SelectAudio()
    {
        // select a random number between 1 and NumberOfAudios, inclusive
        SelectedAudio = Random.Range(1, NumberOfAudios + 1);
    }

    public static void SelectSkin()
    {
        // select a random number between 1 and NumberOfSkins, inclusive
        SelectedSkin = Random.Range(1, NumberOfSkins + 1);
    }
}