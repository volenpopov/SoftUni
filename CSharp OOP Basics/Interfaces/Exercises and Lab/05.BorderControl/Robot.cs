﻿
public class Robot : IIdentifiable
{
    public Robot(string model, string id)
    {
        Model = model;
        Id = id;
    }
    public string Id { get; set; }
    public string Model { get; set; }
}

