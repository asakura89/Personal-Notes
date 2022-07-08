---
tags:
- Research
- Concept
- Thoughts
date: 2021-05-01
---

# Workflow engine

## Full-fledge workflow library

Kebutuhan dan keperluan buat belajar _Workflow engine_ ini gak mesti pake framework yang gede dan banyak fitur kaya _Actor Pattern_, _Messaging Query_, dan fitur lainnya yang dipunyai workflow framework yang gede. Cuma butuh library kecil yang bisa di-embed dimanapun.

1. [workflow core](https://github.com/danielgerlag/workflow-core)
2. [elsa](https://github.com/elsa-workflows/elsa-core) — elsa gue pertimbangin sebagai gray area antara framework yang gede dan simple library
3. [easy flows](https://github.com/j-easy/easy-flows)



## Expression engine

1. [Jint](https://github.com/sebastienros/jint) — Javascript expression engine
2. Custom expression engine — engine bikinan sendiri???



## Rule engine

Harusnya mirip-mirip sama expression engine, cuma lebih kompleks mungkin?

1. [RulesEngine](https://github.com/microsoft/RulesEngine) — Open source baru punya Microsoft
2. [easy rules](https://github.com/j-easy/easy-rules) — Java, butuh dipelajari dan di-translate ke .NET
3. [Easy Rules CSharp](https://github.com/feldrim/EasyRulesCsharp/) — Port langsung dari easy rules di atas ke .NET



## Thoughts

### Task

_Task_ bisa punya _Steps_. _Task_ itu _atomic node_ dari sebuah workflow. Kaya node dari _state machine_.  

Bisa sesimpel ini mungkin?
```C#
public enum ActionStatus {
    Info = 0,
    Warning = 1,
    Error = 2,
    Success = 3
}

public class ActionMessage {
    public ActionStatus Status { get; set; }
    public String Message { get; set; }
}

public class TaskContext {
    public IList<ActionMessage> ActionMessages { get; set; }
    public IDictionary<String, Object> PropertyBag { get; set; }
    public Boolean Cancelled { get; set; }
}

public interface ITask {
    Object Process(TaskContext ctx);
}
```



### Steps

_Steps_ adalah _sub-atomic_ task yang berantai dan bisa diatur ulang urutannya.
Contoh _Steps_ mungkin bisa kaya gini ›› [Application Pipeline](https://github.com/asakura89/Ria)  



### Common Tasks

_Common Tasks_ adalah kumpulan Task-Task yang udah pre-defined oleh library atau framework-nya. Contohnya kaya di bawah ini.  

1. Send Email — [Elsa.Activities.Email](https://github.com/elsa-workflows/elsa-core/tree/master/src/activities/Elsa.Activities.Email)
    1. Mungkin bisa di-mix dengan ini? ›› [Fluid — Liquid template engine](https://github.com/sebastienros/fluid)
    2. Mungkin bisa di-mix dengan ini? ›› [RazorLight — Independent razor renderer](https://github.com/toddams/RazorLight)
2. Http request — [Elsa.Activities.Http](https://github.com/elsa-workflows/elsa-core/tree/master/src/activities/Elsa.Activities.Http)
3. Executes Console — [Elsa.Activities.Console](https://github.com/elsa-workflows/elsa-core/tree/master/src/activities/Elsa.Activities.Console)
4. Bulk Db process
5. Executes simple Db query


