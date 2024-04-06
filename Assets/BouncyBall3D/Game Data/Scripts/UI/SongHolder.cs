using UnityEngine;
using UnityEngine.UI;

public class SongHolder : MonoBehaviour
{
    [SerializeField] Song song;
    [SerializeField] Text songName;
    [SerializeField] Image[] stars = new Image[3];
    [SerializeField] Image[] sculls = new Image[5];
    [SerializeField] Color activeStars, inactiveStars;
    [SerializeField] Color activeSculls, inactiveSculls;


    public void SetSong(Song newSong)
    {
        song = newSong;
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        song.LoadData();

        for (int i = 0; i < 3; i++)
            stars[i].color = i < song.stars ? activeStars : inactiveStars;

        for (int i = 0; i < 5; i++)
            sculls[i].color = i < song.difficulty ? activeSculls : inactiveSculls;

        songName.text = song.name;
    }

    public void PlaySong()
    {
        LevelGenerator.Instance.currentSong = song;
        LevelGenerator.Instance.StartWithSong();
        UIManager.Instance.CloseMenu();
    }
}
