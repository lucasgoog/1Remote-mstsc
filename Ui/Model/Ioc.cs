﻿using System;
using System.Collections.Generic;
using System.Linq;
using StyletIoC;

public static class IoC
{
    public static void Init(IContainer iContainer)
    {
        Instances = iContainer;
        BuildUp = iContainer.BuildUp;
    }

    public static IContainer Instances { get; private set; } = null;

    public static Action<object> BuildUp { get; private set; } = instance => throw new InvalidOperationException("IoC is not initialized");

    public static T Get<T>(string key = null) where T : class
    {
        return (T)Instances?.Get(typeof(T), key);
    }
}