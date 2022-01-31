using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{

    // Extending a class functionality without touching the main class

    public class DecoratorPattern
    {
        public string SaveChanges()
        {
            IRepository repositoryWithLog = new RepositoryLogger(new Repository());
            return repositoryWithLog.SaveChanges();
        }
    }

    public interface IRepository
    {
        string SaveChanges();
    }

    public class Repository : IRepository
    {
        public string SaveChanges()
        {
            return "Saving changes.";
        }
    }

    public abstract class RepositoryLoggerDecorator : IRepository
    {
        public IRepository _repository;

        public RepositoryLoggerDecorator(IRepository repository)
        {
            _repository = repository;
        }
        public virtual string SaveChanges()
        {
            return _repository.SaveChanges();
        }
    }

    public class RepositoryLogger : RepositoryLoggerDecorator
    {
        public RepositoryLogger(IRepository repository) : base(repository)
        {
        }

        public override string SaveChanges() {
            return $"{ base.SaveChanges() } with logging.";
        }
    }
}
