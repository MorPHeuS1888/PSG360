using System.Collections.Generic;
using UnityEngine;

public static class GameData
{    
    public static int SelectedRoom { get; set; } = 1;
    public static int SelectedAudio { get; set; } = 1;
    public static int SelectedSkin { get; set; } = 1;
    public static int SelectedBump { get; set; } = 1;
    public static int SelectedAVFPulse { get; set; } = 1;

    public static PatientController PatientController { get; set; }
    public static PlayerController PlayerController { get; set; }
    public static Camera PlayerCamera { get; set; }

    public static int NumberOfRooms = 1;
    public static int NumberOfAudios = 3;
    public static int NumberOfSkins = 4;
    public static int NumberOfBumps = 2;
    public static int NumberOfAVFPulse = 2;

    public static Dictionary<string, int>  GamePoints = new Dictionary<string, int>();
    public static int ActionPoints = 5;

    public static void InitializeGamePoints()
    {
        GamePoints.Clear();
        GamePoints.Add("CheckTemp", 0);
        GamePoints.Add("CheckPulse", 0);
        GamePoints.Add("CheckTablet", 0);
        GamePoints.Add("CheckElevation", 0);
        GamePoints.Add("CheckPalpation", 0);
        GamePoints.Add("SkinRash", 0);
        GamePoints.Add("SkinAstenose", 0);
        GamePoints.Add("Temperature", 0);
        GamePoints.Add("Pulse", 0);
        GamePoints.Add("Elevation", 0);
        GamePoints.Add("Palpation", 0);
    }

    public static void SelectRoom()
    {
        // select a random number between 1 and NumberOfRooms, inclusive
        SelectedRoom = Random.Range(1, NumberOfRooms + 1);
    }

    public static void SelectAudio()
    {
        // select a random number between 1 and NumberOfAudios, inclusive
        SelectedAudio = Random.Range(1, NumberOfAudios + 1);
        PatientController.SetAudioClip();
    }

    public static void SelectSkin()
    {
        // select a random number between 1 and NumberOfSkins, inclusive
        SelectedSkin = Random.Range(1, NumberOfSkins + 1);
        PatientController.SetSkin();
    }

    public static void SelectBump()
    {
        // select a random number between 1 and NumberOfBumps, inclusive
        SelectedBump = 2; // Random.Range(1, NumberOfBumps + 1);
        PatientController.SetBump();
    }

    public static void SelectAVFPulse()
    {
        // select a random number between 1 and NumberOfAVFPulse, inclusive
        SelectedAVFPulse = 1; //Random.Range(1, NumberOfAVFPulse + 1);
    }
}