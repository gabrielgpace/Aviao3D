using System;

[Serializable]
public class ConfigsModel
{
    public Resolution Resolution { get; set; }
    public LimitFPS LimitFPS { get; set; }
    public bool WindowMode { get; set;}
    public bool VSinc { get; set;}
    public bool AmbientOclusion { get; set;}
    public bool Reflex { get; set;}
    public Quality Quality { get; set;}
    public float Music { get; set;}
    public float Efects { get; set;}
    public float Volume { get; set;}

}
[Serializable]
public enum Quality
{
    VeryLow,
    Low,
    Medium,
    High,
    Ultra
}
public class Resolution
{
    public int Width { get; set; }
    public int Height { get; set; }
}

public class LimitFPS
{
    public bool Limit { get; set; }
    public int FPS { get; set;}
}
