using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject menuOption;
    public GameObject menuInicial;
    public GameObject options;
    public string newGameScene;

    public Dropdown resolution, quality;
    public InputField textFPS;
    public Toggle limitFPS, windowMode, vSinc, occlusion, reflex;
    public Slider music, effects, volume;
    void Start()
    {
        menuOption.SetActive(false);
        menuInicial.SetActive(true);
        options.SetActive(false);
    }
    
    void Update()
    {
        if(Input.anyKeyDown && !options.activeSelf)
        {
            menuOption.SetActive(true);
            menuInicial.SetActive(false);
        }
    }
    public void Options()
    {
        LoadConfigs();
        menuOption.SetActive(false);
        options.SetActive(true);
    }

    public void ReturnMenuInicial()
    {
        menuOption.SetActive(true);
        options.SetActive(false);
    }

    public void Save()
    {
        SaveSettings();
        ReturnMenuInicial();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(newGameScene);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    private void LoadConfigs()
    {
        try
        {
            var fileDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/MaverickGame3D/ConfigData.save";
            if(File.Exists(fileDirectory))
                return;

            var binaryFormater = new BinaryFormatter();
            var file = File.OpenRead(fileDirectory);

            var configs = (ConfigsModel)binaryFormater.Deserialize(file);
            file.Close();

            if(configs != null)
            {
                var option = resolution.options.Where(x => x.text == $"{configs.Resolution.Width}x{configs.Resolution.Height}").FirstOrDefault();
                resolution.value = resolution.options.IndexOf(option);
                quality.value = (int)configs.Quality;
                textFPS.text = configs.LimitFPS.FPS.ToString();
                windowMode.isOn = configs.WindowMode;
                vSinc.isOn = configs.VSinc;
                occlusion.isOn = configs.AmbientOclusion;
                reflex.isOn = configs.Reflex;
                volume.value = configs.Volume;
                music.value = configs.Music;
                effects.value = configs.Efects;


            }
        }
        catch (Exception ex)
        {
            return;
        }
    }
    private void SaveSettings()
    {
        var resolutionModel = new Resolution();

        switch (resolution.value)
        {
            case 0:
                resolutionModel.Width = 1920;
                resolutionModel.Height = 1080;
                break;
            case 1:
                resolutionModel.Width = 1366;
                resolutionModel.Height = 768;
                break;
            case 2:
                resolutionModel.Width = 800;
                resolutionModel.Height = 600;
                break;
        }
        
        var configs = new ConfigsModel()
        {
            AmbientOclusion = occlusion.isOn,
            VSinc = vSinc.isOn,
            Reflex = reflex.isOn,
            WindowMode = windowMode.isOn,
            Volume = volume.value,
            Music = music.value,
            Efects = effects.value,
            LimitFPS = new LimitFPS()
            {
                FPS = int.Parse(textFPS.text),
                Limit = limitFPS.isOn
            },
            Quality = (Quality)quality.value
        };

        var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/MaverickGame3D/";

        var binaryFormater = new BinaryFormatter();
        var file = File.Create(path + "ConfigData.save");

        binaryFormater.Serialize(file, configs);
        file.Close();

    }
}
