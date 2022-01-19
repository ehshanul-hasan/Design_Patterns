using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    // Building a large object step by step 

    public class BuilderPattern
    {
        public Subscription GetSubscription()
        {
            var subscription = SubscriptionBuilder.Create()
                .OfType("Syndicated")
                .WithDatasource("SQL")
                .InBITool("PowerBI")
                .Build();

            return subscription;
        }
    }
    public class SubscriptionBuilder
    {
        public static ISpecifySubscriptionType Create()
        {
            return new Impl();
        }
        private class Impl :
          ISpecifySubscriptionType,
          ISpecifyDatasource,
          ISpecifyBITool,
          IBuildSubscription
        {
            private Subscription subscription = new Subscription();

            ISpecifyDatasource ISpecifySubscriptionType.OfType(string type)
            {
                subscription.Type = type;
                return this;
            }

            public ISpecifyBITool WithDatasource(string datasource)
            {
                subscription.Datasource = datasource;
                return this;
            }

            public IBuildSubscription InBITool(string biTool)
            {
                subscription.BITool = biTool;
                return this;
            }

            Subscription IBuildSubscription.Build()
            {
                return subscription;
            }
        }
    }

    public class Subscription
    {
        public string Type;
        public string Datasource;
        public string BITool;
    }

    public interface ISpecifySubscriptionType
    {
        public ISpecifyDatasource OfType(string type);
    }

    public interface ISpecifyDatasource
    {
        public ISpecifyBITool WithDatasource(string datasource);
    }

    public interface ISpecifyBITool
    {
        public IBuildSubscription InBITool(string biTool);
    }

    public interface IBuildSubscription
    {
        public Subscription Build();
    }

}
