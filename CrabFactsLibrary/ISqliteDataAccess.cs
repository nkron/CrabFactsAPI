using CrabFactsLibrary.Models;
using System.Collections.Generic;

namespace CrabFactsLibrary
{
    public interface ISqliteDataAccess
    {
        List<Fact> LoadFacts();
        void AddFact(Fact fact);
    }
}