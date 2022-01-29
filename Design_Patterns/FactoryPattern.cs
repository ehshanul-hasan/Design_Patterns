using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    public class FactoryPattern
    {
        private readonly Yougurt _yougurt;

        public FactoryPattern(Yougurt yougurt)
        {
            _yougurt = yougurt;
        }
        public string GetYougurt()
        {
            var factory = _yougurt.ExecuteCreation(Actions.Sweet, 2);
            return factory.Prepare();
        }
    }

    public interface IYougurt
    {
        string Prepare();
    }

    public class SweetYougurtManager : IYougurt
    {
        private readonly double _sugar;
        public SweetYougurtManager(double sugar)
        {
            _sugar = sugar;
        }
        public string Prepare()
        {
            return $"Sweet Yougurt prepared with sweetness {_sugar}";
        }
    }

    public class SourYougurtManager : IYougurt
    {
        private readonly double _sugar;
        public SourYougurtManager(double sugar)
        {
            _sugar = sugar;
        }
        public string Prepare()
        {
            return $"Sour Yougurt prepared with sweetness {_sugar}";
        }
    }

    public abstract class YougurtFactory
    {
        public abstract IYougurt Create(double sugar);
    }

    public class SweetYougurtFactory : YougurtFactory
    {
        public override IYougurt Create(double sugar) => new SweetYougurtManager(sugar);
    }

    public class SourYougurtFactory : YougurtFactory
    {
        public override IYougurt Create(double sugar) => new SourYougurtManager(sugar);
    }

    public enum Actions
    {
        Sweet,
        Sour
    }

    public class Yougurt
    {
        private readonly Dictionary<Actions, YougurtFactory> _factories = new Dictionary<Actions, YougurtFactory>();
        public Yougurt()
        {
            foreach (Actions action in Enum.GetValues(typeof(Actions)))
            {
                var factory = (YougurtFactory)Activator.CreateInstance(Type.GetType("Design_Patterns." + Enum.GetName(typeof(Actions), action) + "YougurtFactory"));
                _factories.Add(action, factory);
            }

        }

        public IYougurt ExecuteCreation(Actions action, double sugar) => _factories[action].Create(sugar);
    }
}
