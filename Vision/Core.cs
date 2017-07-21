﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vision.Cv;

namespace Vision
{
    public abstract class Core
    {
        public static string ProjectInfromation = "Vision Project - Computer Vision via AI - Since 2017";
        public static string VersionInfromation = "0.0.1 dev";
        public static Vision.Cv.Cv Cv { get { return Vision.Cv.Cv.Context; } }
        public static Core Current { get; private set; }

        public static void Init(Core core)
        {
            Current = core;

            core.Initialize();

            Logger.Log($"Environment: Core: {Environment.ProcessorCount}");
        }

        public static void Sleep(int duration)
        {
            Current.InternalSleep(duration);
        }

        public abstract void Initialize();
        protected abstract void InternalSleep(int duration);

        protected void InitLogger(Logger.WriteMethodDelegate WriteMethod)
        {
            Logger.WriteMethod = WriteMethod;
        }

        protected void InitCv(Vision.Cv.Cv cv)
        {
            Vision.Cv.Cv.Init(cv);
        }

        protected void InitStorage(Storage storage)
        {
            Storage.Init(storage);
        }
    }
}
