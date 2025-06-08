using ReflexCore.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Application.RuleEngine
{
    public interface IRule
    {
        string Name { get; }
        RuleResult Evaluate(string perception, Emotion emotion, Trait traits);
    }
}
