using System;
using System.Collections.Generic;

namespace Design_Patterns.SOLID
{
    public enum EnvironmentType
    {
        Dev, QA, UAT
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
    
}
