using System;
using System.Collections.Generic;

namespace Design_Patterns.SOLID
{
    public enum EnvironmentType
    {
        Dev, QA, UAT
    }

    // Open for extension closed for modification. In this example if support & production environemnt come system will get extended not modified.
    public class OpenClosed
    {

        public readonly Environment _environment;
        public OpenClosed(Environment environment)
        {
            _environment = environment;
        }
        public string GetHost()
        {
            return _environment.GetHost();
        }

    }

    public class Environment
    {
        public virtual string GetHost()
        {
            return "localhost";
        }
    }

    public class DevEnvironment : Environment
    {
        public override string GetHost()
        {
            return "dev...";
        }
    }

    public class QAEnvironment : Environment
    {
        public override string GetHost()
        {
            return "qa...";
        }
    }
}
