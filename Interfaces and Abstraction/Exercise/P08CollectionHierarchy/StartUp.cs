﻿using CollectionHierarchy.Core;
using CollectionHierarchy.Core.Interfaces;

namespace CollectionHierarchy;

public class StartUp
{
    public static void Main(string[] args)
    {
        IEngine engine = new Engine();
        engine.Run();

    }
}