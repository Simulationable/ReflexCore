# 🧠 ReflexCore: Human-Grade Reflex AI Engine (OSS + DDD + Production-Ready)

**ReflexCore** is an open-source, modular reflex AI engine built to model, interpret, and evolve human-like reflex and self-awareness in digital agents.  
Designed for mental health, AI companions, decision automation, and ethically-aligned agents — ReflexCore delivers an extensible cognitive kernel with production-grade governance and traceability.

---

## 🌟 What Makes ReflexCore Different?

- **Cognitive Layering**: Models the perception→emotion→trait→decision→action flow found in real humans.
- **Context-Isolated DDD**: Each reflex logic context (e.g. Cognitive, Tactical, Narrative) is fully separated and scalable.
- **Plugin-Ready AI**: Attach any LLM/AI backend (OpenAI, Ollama, Local) via a strict plugin interface.
- **Ethical & Consent Gatekeeping**: Built-in consent, audit, and plugin validation for safe human interaction.
- **Full Auditability**: Every state, decision, and trait mutation is traceable and immutable.
- **.NET 9 (C#)**: Cross-platform, high-performance, production-friendly.

---

## 🚀 Vision

ReflexCore aims to set a new foundation for emotionally- and ethically-aware machine reasoning.
Whether powering mental health companions, AI monitors, moderators, or research tools — ReflexCore provides the “reflex kernel” that lets AI **feel, remember, and decide like a human** (but with safeguards).

---

## 🧪 Run CLI Evaluation (Demo)

You can run the CLI demo by evaluating a reflex profile:

```bash
dotnet run --project ReflexCore.CLI -- evaluate --profile-id demo01 --situation "approaching-stranger"
```

This will process a simulated situation and return the AI's action intent (e.g. OfferSupport, AvoidConflict, etc).
Make sure dependencies are registered via CliServiceProvider and traits/emotion default config is loaded properly.

---

## 🧠 Cognitive Reflex Architecture

ReflexCore is structured as **7 human-inspired layers**:

| Layer                 | Function                                                           | Component Example               |
|-----------------------|--------------------------------------------------------------------|----------------------------------|
| 🧿 Perception Layer   | Parse input, tag context, detect tone, intent, metadata            | `PerceptionAnalyzer.cs`          |
| 💓 Emotion Analyzer   | Convert input/context to emotion scores (sadness, hope, stress)    | `EmotionAnalyzer.cs`             |
| 🧬 Trait Memory       | Adjust user’s personality & profile over time                      | `UserTrait.cs`, `TraitAdjuster.cs` |
| 🧠 Self-State         | Track fatigue, disconnection, current mood, system meta-awareness  | `SelfStateEvaluator.cs`          |
| 🎯 Reflex Rule Engine | Decide action, escalate, or seek consent based on all state        | `ReflexRuleEngine.cs`            |
| 🎙️ Action Generator  | Generate output/behavior with correct tone/personality             | `ActionGenerator.cs`             |
| 🧾 Snapshot Memory    | Store and replay state, trait, consent and action history          | `SnapshotStore.cs`               |

Each layer is independently testable, swappable, and upgradable.

---

## 🧱 System Architecture

**Project Structure & Layer Mapping:**

```
ReflexCore/
├── contexts/
│   └── Reflex.Cognitive/                  # Main context: core cognitive reflex kernel
│       ├── Domain/                        # DDD: Entities, ValueObjects, Events
│       │   └── Entities/
│       │       └── UserTrait.cs           # User trait entity (evolves with experience)
│       ├── Application/                   # CQRS Handlers + Core Reflex Layers
│       │   ├── Analyzers/
│       │   │   ├── PerceptionAnalyzer.cs  # Layer 1
│       │   │   └── EmotionAnalyzer.cs     # Layer 2
│       │   ├── Services/
│       │   │   ├── SelfStateEvaluator.cs  # Layer 4
│       │   │   └── TraitAdjuster.cs       # Trait update logic
│       │   ├── Decision/
│       │   │   └── ReflexRuleEngine.cs    # Layer 5
│       │   ├── Output/
│       │   │   └── ActionGenerator.cs     # Layer 6
│       │   ├── Replay/
│       │   │   └── ReplayEngine.cs        # For state/memory replay
│       │   └── Commands/
│       │       └── ProcessReflexCommand.cs
│       ├── API/
│       │   └── Controllers/
│       │       └── ReflexController.cs    # Minimal API (FastAPI style)
│       └── Gateway/
│           ├── IConsentVerifier.cs
│           ├── IUserProfileGateway.cs
│           └── INotificationGateway.cs
│
├── shared/
│   ├── ReflexCore.Shared/                 # DTOs, Enums, Constants
│   ├── ReflexCore.Security/               # ConsentPolicyRules.cs, PluginValidator.cs
│   ├── ReflexCore.Infrastructure/         # Persistence, PluginRegistry, EventBus
│   ├── ReflexCore.Telemetry/              # Observability, Metrics, Dashboard backend
│   └── ReflexCore.Gateway/                # Multi-context gateways
│
├── ui/
│   └── ReflexCore.ConsoleUI/              # Next.js Playground, Dashboard, ReplayViewer
│
├── tests/
│   └── ReflexCore.UnitTests/              # xUnit, Scenario DSL scripts
│
├── infra/
│   ├── docker/                            # Docker, Compose, K8s-ready
│   └── seed/                              # Data fixtures, test users, demo sessions
│
├── docs/
│   ├── architecture.md
│   ├── reflex-loop.md
│   ├── plugin-guide.md
│   └── consent-flow.md
├── .env
├── README.md
├── ROADMAP.md
└── reflexcore.sln
```

**Inline Mapping:**
- *Cognitive Reflex Layers* → `Application/Analyzers`, `Services`, `Decision`, `Output`, `Replay`
- *Consent/Plugin/Security* → `Security/`, `docs/consent-flow.md`
- *Replay, Timeline* → `Application/Replay/`, `ui/ReflexCore.ConsoleUI/ReplayViewer.tsx`
- *Orchestration* → `ReflexCore.Orchestration/`
- *Meta-Awareness* → `Self/LoopIntrospector.cs`, `SelfMonitor.cs`
- *Audit, Logging* → `Infrastructure/AuditTrailService.cs`, `Telemetry/`
- *Plugin AI* → `Infrastructure/PluginRegistry/`, `IAIResponder.cs`
- *Gateway (external)* → `Gateway/`

---

## 🧩 Advanced Features (Omega Layer)

- **Reflex Orchestration Layer**: Chain reflex actions, time-based events, multi-step workflows.
- **EventBus & Messaging**: Allow agents/subsystems to emit/receive reflex events.
- **Meta-Awareness Engine**: Self-debug, monitor internal “fatigue”, detect feedback loops.
- **Plugin Validator**: Enforce model/plugin safety, check rules, config, code signatures.
- **Consent Policy DSL**: Write enforceable consent rules in config, validate at runtime.
- **Observability Dashboard**: Track, visualize, and drill down every reflex state, memory, plugin.
- **Audit Trail**: Immutable logs, hash-sealed history for compliance and ethics.
- **Scenario DSL Runner**: Script complex agent behaviors, regression test, and share scenarios.

Each of these is mapped to a real folder and file. See **Project Structure** above.

---

## 🔌 Plugin & AI Integration

**How Plugins Work:**
- Use `IAIResponder` interface (`GetResponseAsync`)
- Register/resolve plugins at runtime using `PluginManager`
- Plug in: OpenAI, Ollama, local LLMs, custom backend
- Each plugin validated before execution (sandboxed, consent-checked)

```csharp
public interface IAIResponder
{
    Task<string> GetResponseAsync(string prompt, ReflexContext context);
}
```

---

## 🔐 Consent, Policy & External Gateway

- **Consent enforced** at all emotional/ethical risk points
- `IConsentVerifier`: Integrate custom UI or backends for consent checks
- Consent policy rules in code/config (`ConsentPolicyRules.cs`, `rules/consent.json`)
- **Gateway**: Integrate SSO, user profile, notifications (e.g. VerraGate)

---

## 🧪 Testing & Scenarios

- **xUnit tests** for all core and advanced modules
- **Scenario DSL** for agent/behavior tests (`ScenarioRunner.cs`, `ReflexScript.dsl`)
- **Replay**: Load any historical session and step through decisions, traits, actions

Example Scenario:
- User submits emotionally charged input
- ReflexCore tags, scores, and stores it
- If risk detected, consent requested
- Plugin AI generates output (if allowed)
- Every step logged, testable, replayable

---

## 🗺️ Roadmap

Full milestones, feature status, and extension plans in [ROADMAP.md](./ROADMAP.md).

Key stages:
1. Core reflex engine (MVP)
2. Consent security & plugin registry
3. Orchestration & audit
4. Meta-awareness & dashboard
5. Scenario DSL & governance

---

## 📄 License

MIT License — Free to use, modify, and distribute for personal, research, or commercial use.

---

## 📝 Citation & Contact

- ReflexCore Project, 2024-2025, OSS Release 1.0
- Maintainer: Thanakan Klangkasame
- Contact: thanakarn.klangkasame@gmail.com
- Cite as:  
  ```
  @software{reflexcore2025,
    title = {ReflexCore: Human-Grade Reflex AI Kernel},
    author = {Thanakan Klangkasame},
    year = {2025},
    url = {https://github.com/your/repo}
  }
  ```

---

## 🌐 ReflexCore Roadmap

See [ROADMAP.md](./ROADMAP.md) for activation steps, milestones, and advanced features.

---