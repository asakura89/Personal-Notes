---
tags:
- CSharp
date: 2024-05-01
---

# Reactive

## Observable/State

Pertama kali tau istilah observable ini dulu pas jaman Knockout.js. Ternyata bener dong jaman Knockout.js ([The Evolution of Signals in JavaScript - DEV Community](https://dev.to/this-is-learning/the-evolution-of-signals-in-javascript-8ob)). Di modern js framework, observable ini lebih sering disebut state.

```c#
public void Run() {
    var count = new State<Int32>(0);
    Action<Int32> reaction = (Int32 stateValue) => {
        Console.WriteLine(stateValue);
    };

    count.OnChange += reaction;

    count.Value++; // prints 1
    count.Value += 25; // prints 26
    count.Value = 26; // gak nge-prints apapun karena value gak berubah dari sebelumnya
    count.Value *= 25; // prints 650
}

public class State<T> {
    T value;
    public event Action<T> OnChange;

    public State(T initial) {
        value = initial;
    }

    public T Value {
        get => value;
        set {
            if (!EqualityComparer<T>.Default.Equals(this.value, value)) {
                this.value = value;
                OnChange?.Invoke(this.value);
            }
        }
    }
}
```



## Reaction

Reaction ini ya simpelnya semua subscribed function yang jalan ketika ada observable yang berubah value-nya. Liat code di atas.



## Computed

Computed adalah observable/state yang value-nya di-compute ulang ketika dependencies-nya berubah value-nya. Nah, dependencies-nya ini harus di-track. Kalo enggak ya gak ketauan siapa yang berubah karena computed harus bisa auto-computed setiap kali dependencies-nya berubah. Gak cuma sekali jalan doang.

Berarti konsep computed ini, adalah function yang ditempel sebagai Reaction yang juga punya value ketimbang sebagai function yang triggered doang.

Kalo ngeliat gimana Knockout.js tracks dependencies-nya dia, di javascript, dia pake `this` ([Knockout : Computed Observables (knockoutjs.com)](https://knockoutjs.com/documentation/computedObservables.html#managing-this)).

Kalo di .NET bakal pake reflection. Karena di Knockout.js, `this` ini bakal jadi kunci dari auto-dependency-tracking.

```javascript
// contoh langsung dari website Knockout.js
function AppViewModel() {
    this.firstName = ko.observable('Bob');
    this.lastName = ko.observable('Smith');
    this.fullName = ko.computed(function() {
        return this.firstName() + " " + this.lastName();
    }, this); // ← nih dia pake `this` sebagai parameter kedua buat auto-tracks `firstName` sama `lastName`
}
```

versi .NET yang simple tanpa reflection mungkin bakal gini

```c#
public void Run() {
    var count = new State<Int32>(0);
    Action<Int32> reaction = (Int32 stateValue) => {
        Console.WriteLine("Value changed → " + stateValue.ToString());
    };

    count.OnChange += reaction;

    var congrats = new Computed<Int32, String>(stateValue => {
        String template = "Congratulations on your {0} wedding anniversary";
        if (stateValue == 25)
            return String.Format(template, "Silver");

        if (stateValue == 50)
            return String.Format(template, "Gold");

        if (stateValue == 60)
            return String.Format(template, "Diamond");

        if (stateValue == 70)
            return String.Format(template, "Platinum");

        return String.Empty;
    }, count);

    Action<String> computedReaction = (String stateValue) => {
        Console.WriteLine("Computed value reacting → " + stateValue.ToString());
    };

    congrats.OnChange += computedReaction;

    count.Value++;
    count.Value += 25;
    count.Value = 26;
    count.Value *= 25;
    count.Value = 60;
}

public class State<T> {
    T value;
    public event Action<T> OnChange;

    public State(T initial) {
        value = initial;
    }

    public T Value {
        get => value;
        set {
            if (!EqualityComparer<T>.Default.Equals(this.value, value)) {
                this.value = value;
                OnChange?.Invoke(this.value);
            }
        }
    }
}

public class Computed<TState1, TComputed> {
    TComputed value;
    public event Action<TComputed> OnChange;

    public Computed(Func<TState1, TComputed> computeFunction, State<TState1> dependency) {
        computeFunction = computeFunction ?? throw new ArgumentNullException(nameof(computeFunction));
        dependency.OnChange += (TState1 stateValue) => {
            TComputed recomputedValue = computeFunction.Invoke(stateValue);
            Value = recomputedValue;
        };
    }

    public TComputed Value {
        get => value;
        private set {
            if (!EqualityComparer<TComputed>.Default.Equals(this.value, value)) {
                this.value = value;
                OnChange?.Invoke(this.value);
            }
        }
    }
}
```

Output-nya

```markdown
Value changed → 1
Computed value reacting →
Value changed → 26
Value changed → 650
Value changed → 60
Computed value reacting → Congratulations on your Diamond wedding anniversary
```

Di contoh ini cuma ada 1 jenis State yang di-track sbg dependency, yaitu `TState1` di `Computed<TState1, TComputed>`. Kalo butuh beberapa buat nambahin jenis state yang mau di-track, kayanya bakal butuh nambahin `Computed` yang lain kaya `Func` ([runtime/src/libraries/System.Private.CoreLib/src/System/Function.cs at main · dotnet/runtime (github.com)](https://github.com/dotnet/runtime/blob/main/src/libraries/System.Private.CoreLib/src/System/Function.cs)).

Tapi gak bisa segampang itu. Karena class `Computed` bakal jadi ada banyak banget.

```c#
// buat 1 jenis dependency
public class Computed<TState1, TComputed> {
    TComputed value;
    public event Action<TComputed> OnChange;

    public Computed(Func<TState1, TComputed> computeFunction, State<TState1> dependency) {
        computeFunction = computeFunction ?? throw new ArgumentNullException(nameof(computeFunction));
        dependency.OnChange += (TState1 stateValue) => {
            TComputed recomputedValue = computeFunction.Invoke(stateValue);
            Value = recomputedValue;
        };
    }

    public TComputed Value {
        get => value;
        private set {
            if (!EqualityComparer<TComputed>.Default.Equals(this.value, value)) {
                this.value = value;
                OnChange?.Invoke(this.value);
            }
        }
    }
}

// buat 2 jenis dependency
public class Computed<TState1, TState2, TComputed> {
    TComputed value;
    public event Action<TComputed> OnChange;

    public Computed(Func<TState1, TState2, TComputed> computeFunction, State<TState1> dependency, State<TState2> dependency2) {
        computeFunction = computeFunction ?? throw new ArgumentNullException(nameof(computeFunction));
        dependency.OnChange += (TState1 stateValue) => {
            TComputed recomputedValue = computeFunction.Invoke(stateValue);
            Value = recomputedValue;
        };

        dependency2.OnChange += (TState2 stateValue) => {
            TComputed recomputedValue = computeFunction.Invoke(stateValue);
            Value = recomputedValue;
        };
    }

    public TComputed Value {
        get => value;
        private set {
            if (!EqualityComparer<TComputed>.Default.Equals(this.value, value)) {
                this.value = value;
                OnChange?.Invoke(this.value);
            }
        }
    }
}
```

repot kan ya? banget.

Coba kita explore beberapa workaround-nya.



### Workaround 1

```c#
public void Run() {
    var count = new State(0);
    Action<Object> reaction = (Object stateValue) => {
        Console.WriteLine("Value changed → " + stateValue.ToString());
    };

    count.OnChange += reaction;

    var stillOnMarriage = new State(false);
    Action<Object> stillOnMReaction = (Object stateValue) => {
        Console.WriteLine("Value changed → " + stateValue.ToString());
    };

    stillOnMarriage.OnChange += stillOnMReaction;

    var congrats = new Computed<String>(states => {
        if (Convert.ToBoolean(states[1].Value) == true) {
            Int32 intState = Convert.ToInt32(states[0].Value);
            String template = "Congratulations on your {0} wedding anniversary";
            if (intState == 25)
                return String.Format(template, "Silver");

            if (intState == 50)
                return String.Format(template, "Gold");

            if (intState == 60)
                return String.Format(template, "Diamond");

            if (intState == 70)
                return String.Format(template, "Platinum");
        }

        return String.Empty;
    }, count, stillOnMarriage);

    Action<String> computedReaction = (String stateValue) => {
        Console.WriteLine("Computed value reacting → " + stateValue.ToString());
    };

    congrats.OnChange += computedReaction;

    stillOnMarriage.Value = true;

    count.Value = Convert.ToInt32(count.Value) +1;
    count.Value = Convert.ToInt32(count.Value) +25;
    count.Value = 26;
    count.Value = Convert.ToInt32(count.Value) -1;
    count.Value = Convert.ToInt32(count.Value) *25;
    count.Value = 60;
}

public class State<T> {
    protected T value;
    public event Action<T> OnChange;

    public State(T initial) {
        value = initial;
    }

    public T Value {
        get => value;
        set {
            if (!EqualityComparer<T>.Default.Equals(this.value, value)) {
                this.value = value;
                OnChange?.Invoke(this.value);
            }
        }
    }
}

public class State : State<Object> {
    public State(Object initial) : base (initial) { }
}

public class Computed<TComputed> {
    TComputed value;
    public event Action<TComputed> OnChange;

    public Computed(Func<State[], TComputed> computeFunction, params State[] dependencies) {
        computeFunction = computeFunction ?? throw new ArgumentNullException(nameof(computeFunction));
        foreach (State dependency in dependencies) {
            dependency.OnChange += stateValue => {
                TComputed recomputedValue = computeFunction.Invoke(dependencies);
                Value = recomputedValue;
            };
        }
    }

    public TComputed Value {
        get => value;
        private set {
            if (!EqualityComparer<TComputed>.Default.Equals(this.value, value)) {
                this.value = value;
                OnChange?.Invoke(this.value);
            }
        }
    }
}
```

Output-nya

```markdown
Value changed → True
Computed value reacting →
Value changed → 1
Value changed → 26
Value changed → 25
Computed value reacting → Congratulations on your Silver wedding anniversary
Value changed → 625
Computed value reacting →
Value changed → 60
Computed value reacting → Congratulations on your Diamond wedding anniversary
```

kekurangannya, semua state yang jadi dependencies harus berjenis `Object` yang pada akhirnya bakal ada boxing unboxing.



### Workaround 2

```c#
public void Run() {
    var count = new State<Int32>(0);
    Action<Object> reaction = (Object stateValue) => {
        Console.WriteLine("Value changed on 1st reaction → " + stateValue.ToString());
    };

    Action<Object> reaction2 = (Object stateValue) => {
        Console.WriteLine("Value changed on 2nd reaction → " + count.TypedValue.ToString());
    };

    count.OnChange += reaction;
    count.OnChange += reaction2;

    var stillOnMarriage = new State<Boolean>(false);
    Action<Object> stillOnMReaction = (Object stateValue) => {
        Console.WriteLine("Value changed on 1st reaction → " + stateValue.ToString());
    };

    Action<Object> stillOnMReaction2 = (Object stateValue) => {
        Console.WriteLine("Value changed on 2nd reaction → " + stillOnMarriage.TypedValue.ToString());
    };

    stillOnMarriage.OnChange += stillOnMReaction;
    stillOnMarriage.OnChange += stillOnMReaction2;

    var congrats = new Computed<String>(states => {
        foreach (IState state in states)
            Console.WriteLine("States on Computed → " + state.Value.ToString());

        if (stillOnMarriage.TypedValue == true) {
            String template = "Congratulations on your {0} wedding anniversary";
            if (count.TypedValue == 25)
                return String.Format(template, "Silver");

            if (count.TypedValue == 50)
                return String.Format(template, "Gold");

            if (count.TypedValue == 60)
                return String.Format(template, "Diamond");

            if (count.TypedValue == 70)
                return String.Format(template, "Platinum");
        }

        return String.Empty;
    }, count, stillOnMarriage);

    Action<String> computedReaction = (String stateValue) => {
        Console.WriteLine("Computed value reacting → " + stateValue.ToString());
    };

    congrats.OnChange += computedReaction;

    stillOnMarriage.TypedValue = true;

    count.TypedValue = Convert.ToInt32(count.Value) +1;
    count.TypedValue += 25;
    count.TypedValue = 26;
    count.TypedValue -= 1;
    count.TypedValue *= 25;
    count.TypedValue = 60;
}

public interface IState {
    Object Value { get; }
    event Action<Object> OnChange;
}

public class State<T> : IState {
    protected T value;
    public event Action<Object> OnChange;

    public State(T initial) {
        value = initial;
    }

    public Object Value => value;

    public T TypedValue {
        get => value;
        set {
            if (!EqualityComparer<T>.Default.Equals(this.value, value)) {
                this.value = value;
                OnChange?.Invoke(this.value);
            }
        }
    }
}

public class Computed<TComputed> {
    TComputed value;
    public event Action<TComputed> OnChange;

    public Computed(Func<IState[], TComputed> computeFunction, params IState[] dependencies) {
        computeFunction = computeFunction ?? throw new ArgumentNullException(nameof(computeFunction));
        foreach (IState dependency in dependencies) {
            dependency.OnChange += stateValue => {
                TComputed recomputedValue = computeFunction.Invoke(dependencies);
                Value = recomputedValue;
            };
        }
    }

    public TComputed Value {
        get => value;
        private set {
            if (!EqualityComparer<TComputed>.Default.Equals(this.value, value)) {
                this.value = value;
                OnChange?.Invoke(this.value);
            }
        }
    }
}
```

Output-nya

```markdown
public void Run() {
    var count = new State<Int32>(0);
    Action<Object> reaction = (Object stateValue) => {
        Console.WriteLine("Value changed on 1st reaction → " + stateValue.ToString());
    };

    Action<Object> reaction2 = (Object stateValue) => {
        Console.WriteLine("Value changed on 2nd reaction → " + count.TypedValue.ToString());
    };

    count.OnChange += reaction;
    count.OnChange += reaction2;

    var stillOnMarriage = new State<Boolean>(false);
    Action<Object> stillOnMReaction = (Object stateValue) => {
        Console.WriteLine("Value changed on 1st reaction → " + stateValue.ToString());
    };

    Action<Object> stillOnMReaction2 = (Object stateValue) => {
        Console.WriteLine("Value changed on 2nd reaction → " + stillOnMarriage.TypedValue.ToString());
    };

    stillOnMarriage.OnChange += stillOnMReaction;
    stillOnMarriage.OnChange += stillOnMReaction2;

    var congrats = new Computed<String>(states => {
        foreach (IState state in states)
            Console.WriteLine("States on Computed → " + state.Value.ToString());

        if (stillOnMarriage.TypedValue == true) {
            String template = "Congratulations on your {0} wedding anniversary";
            if (count.TypedValue == 25)
                return String.Format(template, "Silver");

            if (count.TypedValue == 50)
                return String.Format(template, "Gold");

            if (count.TypedValue == 60)
                return String.Format(template, "Diamond");

            if (count.TypedValue == 70)
                return String.Format(template, "Platinum");
        }

        return String.Empty;
    }, count, stillOnMarriage);

    Action<String> computedReaction = (String stateValue) => {
        Console.WriteLine("Computed value reacting → " + stateValue.ToString());
    };

    congrats.OnChange += computedReaction;

    stillOnMarriage.TypedValue = true;

    count.TypedValue = Convert.ToInt32(count.Value) +1;
    count.TypedValue += 25;
    count.TypedValue = 26;
    count.TypedValue -= 1;
    count.TypedValue *= 25;
    count.TypedValue = 60;
}

public interface IState {
    Object Value { get; }
    event Action<Object> OnChange;
}

public class State<T> : IState {
    protected T value;
    public event Action<Object> OnChange;

    public State(T initial) {
        value = initial;
    }

    public Object Value => value;

    public T TypedValue {
        get => value;
        set {
            if (!EqualityComparer<T>.Default.Equals(this.value, value)) {
                this.value = value;
                OnChange?.Invoke(this.value);
            }
        }
    }
}

public class Computed<TComputed> {
    TComputed value;
    public event Action<TComputed> OnChange;

    public Computed(Func<IState[], TComputed> computeFunction, params IState[] dependencies) {
        computeFunction = computeFunction ?? throw new ArgumentNullException(nameof(computeFunction));
        foreach (IState dependency in dependencies) {
            dependency.OnChange += stateValue => {
                TComputed recomputedValue = computeFunction.Invoke(dependencies);
                Value = recomputedValue;
            };
        }
    }

    public TComputed Value {
        get => value;
        private set {
            if (!EqualityComparer<TComputed>.Default.Equals(this.value, value)) {
                this.value = value;
                OnChange?.Invoke(this.value);
            }
        }
    }
}
```

Well, tetep ada `Object` di `IState` dan di reaction.

Ini karena, di semua code di atas mau itu `State` mau itu `Computed`, `OnChange` dan `computedFunction` dibikin buat "nerima" atau "tau" value terbaru hasil dari perubahan state.



### Workaround 3

Kalo misal mau bodo amat sama si subscriber-nya. Mereka gak dikasih tau value terbaru, code-nya bakal gini. 

```c#
public void Run() {
    var count = new State<Int32>(0);
    Action reaction = () => {
        Console.WriteLine("Value changed on 1st reaction → " + count.Value.ToString());
    };

    count.OnChange += reaction;

    var stillOnMarriage = new State<Boolean>(false);
    Action stillOnMReaction = () => {
        Console.WriteLine("Value changed on 1st reaction → " + stillOnMarriage.Value.ToString());
    };

    stillOnMarriage.OnChange += stillOnMReaction;

    var congrats = new Computed<String>(() => {
        Console.WriteLine("States on Computed → " + count.Value.ToString());
        Console.WriteLine("States on Computed → " + stillOnMarriage.Value.ToString());

        if (stillOnMarriage.Value == true) {
            String template = "Congratulations on your {0} wedding anniversary";
            if (count.Value == 25)
                return String.Format(template, "Silver");

            if (count.Value == 50)
                return String.Format(template, "Gold");

            if (count.Value == 60)
                return String.Format(template, "Diamond");

            if (count.Value == 70)
                return String.Format(template, "Platinum");
        }

        return String.Empty;
    }, count, stillOnMarriage);

    Action computedReaction = () => {
        Console.WriteLine("Computed value reacting → " + congrats.Value);
    };

    congrats.OnChange += computedReaction;

    stillOnMarriage.Value = true;

    count.Value = Convert.ToInt32(count.Value) +1;
    count.Value += 25;
    count.Value = 26;
    count.Value -= 1;
    count.Value *= 25;
    count.Value = 60;
}

public interface IState {
    event Action OnChange;
}

public class State<T> : IState {
    protected T value;
    public event Action OnChange;

    public State(T initial) {
        value = initial;
    }

    public T Value {
        get => value;
        set {
            if (!EqualityComparer<T>.Default.Equals(this.value, value)) {
                this.value = value;
                OnChange?.Invoke();
            }
        }
    }
}

public class Computed<TComputed> {
    TComputed value;
    public event Action OnChange;

    public Computed(Func<TComputed> computeFunction, params IState[] dependencies) {
        computeFunction = computeFunction ?? throw new ArgumentNullException(nameof(computeFunction));
        foreach (IState dependency in dependencies) {
            dependency.OnChange += () => {
                TComputed recomputedValue = computeFunction.Invoke();
                Value = recomputedValue;
            };
        }
    }

    public TComputed Value {
        get => value;
        private set {
            if (!EqualityComparer<TComputed>.Default.Equals(this.value, value)) {
                this.value = value;
                OnChange?.Invoke();
            }
        }
    }
}
```

Output-nya

```markdown
Value changed on 1st reaction → True
States on Computed → 0
States on Computed → True
Computed value reacting →
Value changed on 1st reaction → 1
States on Computed → 1
States on Computed → True
Value changed on 1st reaction → 26
States on Computed → 26
States on Computed → True
Value changed on 1st reaction → 25
States on Computed → 25
States on Computed → True
Computed value reacting → Congratulations on your Silver wedding anniversary
Value changed on 1st reaction → 625
States on Computed → 625
States on Computed → True
Computed value reacting →
Value changed on 1st reaction → 60
States on Computed → 60
States on Computed → True
Computed value reacting → Congratulations on your Diamond wedding anniversary
```

Tapi jadinya mesti pake closure.

